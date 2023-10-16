using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COE.Common.Model;
using PagedList;

namespace COE.Survey.Web.ViewModels
{
    public class SurveysViewModel
    {
        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public int? StatusId { get; set; }
        public int NumOfQuestions { get; set; }
        public string CurrentQuestion { get; set; }
        public int NumOfAnswers { get; set; }
        public List<Common.Model.Survey> SurviesList { get; set; }
        public List<SurveyAnswer> AnswersList { get; set; }
        public string SurveyStr { get; set; }
        public string ChartLabels { get; set; }
        public string ChartData { get; set; }
        public KeyValuePair<string, string>[,] SurveyMatrix { get; set; }
        public StaticPagedList<SurveyAnswer> Items { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }

    public class ChartViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ChartType { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Steps { get; set; }
        public int StepValue { get; set; }
        public string LabelValue { get; set; }
        public string UnitValue { get; set; }
        public string ChartLabels { get; set; }
        public string ChartData { get; set; }
    }


    public class ChartsViewModel
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public int ResponsesCount { get; set; }
        public List<ChartViewModel> Charts { get; set; }
    }
}