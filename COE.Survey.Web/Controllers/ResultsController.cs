using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COE.Survey.Web.ViewModels;
using COE.Survey.BLL;
using COE.Common.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using COE.Common.Model;
using System.Globalization;
using COE.Survey.Web.Filters;
using COE.Common.BLL;
using COE.Common.Model.ViewModels;
using System.Data.Entity;
using System.Net;
using Commons.Framework.Data;
using PagedList;
using System.IO;
using CsvHelper;
using System.Text;
using COE.Survey.Web.Helpers.LookupValues;
using COE.Survey.Web.Reports;
using DevExpress.XtraReports.UI;

namespace COE.Survey.Web
{


    [Authorize]
    public class ResultsController : BaseController<COEUoW>
    {
        private ResultsMainReport _report;




        public bool HasUserDisplay => UnitOfWork.UserDisplay.HasUserDisplay(UserName);


        private int GetColumnIndexByValue(JArray array, string value)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i]["value"].ToString() == value)
                    return i + 1;
            }

            return 0;
        }


        [ModuleAuthorize("Survey", "SurveyModule")]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var survey = UnitOfWork.Survey.GetById(id);
            var questions = survey.SurveyQuestion.Where(a => a.TypeId != 13).ToList();
            var answers = survey.SurveyAnswer.ToList();
            int questionsCount = questions.Count;
            int answersCount = survey.SurveyAnswer.Count;
            string chartType = "";

            ChartsViewModel charts = new ChartsViewModel
            {
                SurveyId = survey.ID,
                ResponsesCount = answersCount,
                SurveyTitle = survey.SurveyTitle,
                Charts = new List<ChartViewModel>()
            };

            charts.Charts = new List<ChartViewModel>();

            for (int x = 0; x < questionsCount; x++)
            {
                var selectedQuestion = questions[x];
                string currentQuestion = selectedQuestion.Title?.Trim();
                var optionsValues = JsonConvert.DeserializeObject<JObject>(selectedQuestion.JsonContent);

                int max = 100;
                int min = 10;
                int steps = 10;
                int stepValue = 5;
                string labelValue = "النسبة";
                string choices = string.Empty;
                string choicesOccurrence = string.Empty;
                choices = "[";
                choicesOccurrence = "[";


                #region Matrix question
                if (selectedQuestion.TypeId == 7)
                {
                    max = 5;
                    min = 0;
                    stepValue = 1;
                    steps = 5;
                    labelValue = "التقييم";

                    var questionElements = JsonConvert.DeserializeObject<Dictionary<string, object>>(selectedQuestion.JsonContent);
                    JArray rows = questionElements["rows"] as JArray;
                    JArray columns = questionElements["columns"] as JArray;

                    List<FillingMatrix> finalResultForChart = new List<FillingMatrix>();


                    foreach (var row in rows)
                    {
                        JObject rowAsJobject = row as JObject;

                        if (rowAsJobject != null)
                        {
                            choices += "\"" + rowAsJobject["text"].ToString() + "\"" + ",";
                            finalResultForChart.Add(new FillingMatrix { Key = rowAsJobject["value"].ToString(), Value = 0, Occurance = 0 });
                        }
                        else
                        {
                            choices += "\"" + row.ToString() + "\"" + ",";
                            finalResultForChart.Add(new FillingMatrix { Key = row.ToString(), Value = 0, Occurance = 0 });
                        }


                    }

                    var qanswers = selectedQuestion.QuestionAnswer.ToList();
                    foreach (var answer in qanswers)
                    {
                        var answerValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(answer.AnswerText);
                        foreach (var answerValue in answerValues)
                        {
                            var key = answerValue.Key;
                            var value = answerValue.Value;
                            int fakeValue = GetColumnIndexByValue(columns, value.ToString());
                            var fillingMatrixItem = finalResultForChart.FirstOrDefault(a => a.Key == key);
                            fillingMatrixItem.Value = fillingMatrixItem.Value + fakeValue;
                            fillingMatrixItem.Occurance++;
                        }

                    }

                    foreach (var finalResultForChartItem in finalResultForChart)
                    {
                        //decimal thisChoiceOccurance = finalResultForChart.Count(a => a.Key == finalResultForChartItem.Key);
                        choicesOccurrence += Math.Round(((float)finalResultForChartItem.Value / (float)finalResultForChartItem.Occurance), 1) + ",";
                    }

                    choices += "]";
                    choicesOccurrence += "]";

                    choices = choices.Replace(",]", "]");
                    choicesOccurrence = choicesOccurrence.Replace(",]", "]");

                    charts.Charts.Add(new ChartViewModel
                    {
                        Id = x,
                        Title = currentQuestion,
                        ChartType = "horizontalBar",
                        ChartLabels = choices.Replace("\r", "").Replace("\n", ""),
                        ChartData = choicesOccurrence,
                        Max = max,
                        Min = min,
                        Steps = steps,
                        StepValue = stepValue,
                        LabelValue = labelValue,
                        UnitValue = ""
                    });

                    continue;
                }
                #endregion

                #region Rating question

                if (selectedQuestion.TypeId == 11)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        selectedQuestion.QuestionOption.Add(new QuestionOption { OptionKey = $"{i}", OptionValue = $"{i}" });
                    }
                }
                #endregion
                var optionsCount = selectedQuestion.QuestionOption.Count;
                if (optionsCount == 0)
                {
                    continue;
                }
                else if (optionsCount == 2)
                {
                    chartType = "pie";
                }
                else
                {
                    chartType = "horizontalBar";
                }




                var options = selectedQuestion.QuestionOption.ToList();
                var seperatedAnswers = selectedQuestion.QuestionAnswer.ToList();


                

                foreach (var option in options)
                {
                    int occurrence = seperatedAnswers.Count(a => a.AnswerText == option.OptionKey);
                    double occurrencePercent = Math.Round(((float)occurrence / (float)seperatedAnswers.Count) * 100, 2);

                    string suggested = new string(option.OptionValue.ToList().Where(c => c < 0x20 || c > 0x7E || c == ' ').ToArray()).Trim();
                    if (!string.IsNullOrEmpty(suggested))
                    {
                        option.OptionValue = suggested;
                    }


                    choices += "\"" + option.OptionValue + "\"" + ",";
                    choicesOccurrence += occurrencePercent + ",";
                }

                choices += "]";
                choicesOccurrence += "]";

                choices = choices.Replace(",]", "]");
                choicesOccurrence = choicesOccurrence.Replace(",]", "]");


                charts.Charts.Add(new ChartViewModel
                {
                    Id = x,
                    Title = currentQuestion,
                    ChartType = chartType,
                    ChartLabels = choices.Replace("\r", "").Replace("\n", ""),
                    ChartData = choicesOccurrence,
                    Max = max,
                    Min = min,
                    Steps = steps,
                    StepValue = stepValue,
                    LabelValue = labelValue,
                    UnitValue = "%"

                });
            }

            return View(charts);
        }

        private void _report_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRChart chart = _report.FindControl("xrChart1", false) as XRChart;
            if (chart != null)
            {
                chart.DataSource = GetPoints().Select(a => new { XValue = a.X, YValue = a.Y }).ToList();
            }
        }

        private List<ChartPoint> GetPoints()
        {
            var m = new List<ChartPoint>();
            m.Add(new ChartPoint { X = "Answer 1", Y = 1 });
            m.Add(new ChartPoint { X = "Answer 2 Answer 2 Answer 2 Answer 2 Answer 2 Answer 2", Y = 5 });
            m.Add(new ChartPoint { X = "Answer 2 3", Y = 3 });
            m.Add(new ChartPoint { X = "Answer 2 4", Y = 9 });
            m.Add(new ChartPoint { X = "Question 5", Y = 10 });
            return m;
        }
    }

    public class ChartPoint
    {
        public ChartPoint()
        {

        }

        public string X { get; set; }
        public int Y { get; set; }
    }

    public class FillingMatrix
    {
        public string Key;
        public int Value;
        public int Occurance;
    }
}