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
using COE.Survey.Web.Helpers;
using Commons.Framework.Globalization;
using COE.Common.Localization;
using DevExpress.XtraPrinting.Native;
using System.Text.RegularExpressions;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace COE.Survey.Web
{
    [Authorize]
    public class SurveysController : BaseController<COEUoW>
    {
        public bool HasUserDisplay => UnitOfWork.UserDisplay.HasUserDisplay(UserName);

        [ModuleAuthorize("Survey", "SurveyModule")]
        [HttpGet]
        public ActionResult Index(int? moduleId)
        {


            LoadAuthorizationModuleActions("Survey", "SurveyModule");

            var isSurveyCreator = IsUserSurveyCreator();
            ViewBag.Modules = GetAllModules();
            ViewBag.AllStatus = GetSurveyStatus();


            var query = UnitOfWork.Survey.GetAll();

            if (moduleId.HasValue)
            {
                query = query.Where(a => a.ModuleId == moduleId.Value);
            }


            if (isSurveyCreator)
            {
                query = query.Where(a => a.CreatedBy == this.UserName);
            }

            var surveys = query.OrderByDescending(a => a.CreatedOn).ToList();


            foreach (var item in surveys)
            {
                var jObj = JObject.Parse(item.SurveyText);
                var imgurl = JsonHelper.GetAttributeFromJson("logo", jObj);
                item.ImageUrl = imgurl;

                item.ModuleText = CultureHelper.IsArabic ? item.SurveyModules?.ModuleTitleAr : item.SurveyModules?.ModuleTitleEn;
                item.SurveyLink = Url.Action("Answer", "Surveys", new { id = item.ID });
                item.IsActive = item.StatusId != (int)SurveyStatusEnum.Deactivated;
            }

            SurveysViewModel allItems = new SurveysViewModel { SurviesList = surveys };
            return View(allItems);
        }


        [ModuleAuthorize("Survey", "SurveyModule")]
        [HttpPost]
        public ActionResult Index(SurveysViewModel model)
        {
            LoadAuthorizationModuleActions("Survey", "SurveyModule");
            ViewBag.Modules = GetAllModules();
            ViewBag.AllStatus = GetSurveyStatus();

            var isSurveyCreator = IsUserSurveyCreator();

            IQueryable<Common.Model.Survey> surveys;
            if (model.ModuleId.HasValue)
            {
                surveys = UnitOfWork.Survey.GetByQuery(a => a.ModuleId == model.ModuleId.Value);
            }
            else
            {
                surveys = UnitOfWork.Survey.GetAll();
            }

            if (model.StatusId.HasValue)
            {
                surveys = surveys.Where(a => a.StatusId == model.StatusId.Value);
            }
            if (isSurveyCreator)
            {
                surveys = surveys.Where(a => a.CreatedBy == this.UserName);
            }

            var surveyList = surveys.ToList();
            foreach (var item in surveyList)
            {
                var jObj = JObject.Parse(item.SurveyText);
                var imgurl = JsonHelper.GetAttributeFromJson("logo", jObj);
                item.ImageUrl = imgurl;
                item.ModuleText = CultureHelper.IsArabic ? item.SurveyModules?.ModuleTitleAr : item.SurveyModules?.ModuleTitleEn;
            }

            SurveysViewModel allItems = new SurveysViewModel { SurviesList = surveyList };
            return View(allItems);
        }

        private bool IsUserSurveyCreator()
        {
            return UserManager.IsCurrentUserInRole(RolesNames.SurveyCreator)
                && !UserManager.IsCurrentUserInRole(RolesNames.SurveyApprover)
                && !UserManager.IsCurrentUserInRole(RolesNames.SurveyPublisher);
        }

        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "CreateSurvey")]
        public ActionResult Add()
        {

            ViewBag.Modules = UnitOfWork.SurveyModules.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public JsonResult UploadTemplate(SurvyJsonObject data)
        {
            try
            {
                string surveyText = data.SurveyText; string title = data.SurveyTitle;
                if (string.IsNullOrEmpty(surveyText))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.PleaseFillAllRequiredFields });
                }

                if (string.IsNullOrEmpty(title))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.PleaseEnterTitleForSurvey });
                }

                if (string.IsNullOrEmpty(surveyText))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.NoSurveyData });
                }

                var jObj = JObject.Parse(data.SurveyText);

                string logoUrl = HandleLogo(jObj);
                jObj = JsonHelper.SetAttributeFromJson("logo", logoUrl, jObj);

                var lang = JsonHelper.GetAttributeFromJson("locale", jObj);


                UnitOfWork.Survey.Add(new Common.Model.Survey
                {
                    SurveyTitle = title.Trim(),
                    StatusId = (int)SurveyStatusEnum.Draft,
                    SurveyText = jObj.ToString().Replace("\\", "\\\\"),
                    SurveyQuestion = null,
                    IsRTL = lang.ToLower().Trim() == "ar",
                    ImageUrl = logoUrl,
                    CreatedBy = UserName,
                    UpdatedBy = UserName,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                });

                int rows = UnitOfWork.Save();
                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }

        [HttpPost]
        public JsonResult PublishSurvey(string[] surveyItems)
        {
            try
            {
                if (surveyItems == null || surveyItems.Length != 8)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidData });
                }

                string title = surveyItems[0];
                string desc = surveyItems[1];
                string startDateStr = surveyItems[2];
                string endDateStr = surveyItems[3];
                string moduleIdStr = surveyItems[4];
                string surveyIdStr = surveyItems[5];
                bool allowAnon = surveyItems[6] == "true";
                bool allowMulti = surveyItems[7] == "true";




                DateTime startDate, endDate;
                int surveyId, moduleId;

                if (!int.TryParse(surveyIdStr, out surveyId))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }

                if (!int.TryParse(moduleIdStr, out moduleId) || moduleId == -1)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.PleaseSelectModule });
                }

                if (!DateTime.TryParseExact(startDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate) ||
                   !DateTime.TryParseExact(endDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.PleaseSelectValidDates });
                }

                if (string.IsNullOrEmpty(title))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.PleaseEnterTitleForSurvey });
                }


                var survey = UnitOfWork.Survey.GetById(surveyId);

                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }


                var jObj = JObject.Parse(survey.SurveyText);
                jObj = JsonHelper.SetAttributeFromJson("title", title.Trim(), jObj);
                survey.SurveyText = jObj.ToString().Replace("\\", "\\\\").Replace("\r\n", "").Replace("\n", "");

                survey.SurveyTitle = title.Trim();
                survey.StatusId = (int)SurveyStatusEnum.Published;
                survey.UpdatedBy = "Admin1";
                survey.UpdatedOn = DateTime.Now;
                survey.StartDate = startDate;
                survey.EndDate = endDate;
                survey.Description = desc;
                survey.ModuleId = moduleId;
                survey.AllowAnonymous = allowAnon;
                survey.AllowMultiple = allowMulti;


                int rows = UnitOfWork.Save();

                return Json(new { success = rows > 0 });

                //return Json(new { success = false });

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }


        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "PublishSurvey")]
        public ActionResult Publish(int? id)
        {


            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }



            var survey = UnitOfWork.Survey.GetById(id);
            ViewBag.Modules = GetAllModules();
            if (survey.StatusId.Value != (int)SurveyStatusEnum.Draft)
            {
                return RedirectToAction("Index", "Surveys");
            }


            survey.SurveyText = survey.SurveyText.Replace("\r\n", "").Replace("\n", "");
            return View(survey);
        }

        public ActionResult Edit(int? id)
        {


            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var survey = UnitOfWork.Survey.GetById(id);

            if (survey.StatusId.HasValue && (SurveyStatusEnum)survey.StatusId != SurveyStatusEnum.Draft)
            {
                return RedirectToAction("Index", "Surveys");
            }

            //if (survey.SurveyAnswer.Any())
            //{
            //    return RedirectToAction("Index", "Surveys");
            //}

            survey.SurveyText = survey.SurveyText.Replace("\r\n", "").Replace("\n", "");
            return View(survey);
        }

        public ActionResult Duplicate(int? id)
        {


            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var survey = UnitOfWork.Survey.GetById(id);

            var jObj = JObject.Parse(survey.SurveyText);

            survey.ID = 0;
            survey.SurveyTitle = "copy of " + survey.SurveyTitle;
            jObj = JsonHelper.SetAttributeFromJson("title", survey.SurveyTitle, jObj);
            survey.SurveyText = jObj.ToString().Replace("\\", "\\\\").Replace("\r\n", "").Replace("\n", "");
            return View(survey);
        }

        [HttpPost]
        public JsonResult UpdateTemplate(SurvyJsonObject data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.SurveyText))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.NoSurveyData });
                }

                var survey = UnitOfWork.Survey.GetById(data.SurveyId);
                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.NoSurveyWithGivenID });
                }

                if (!IsEditable(survey))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.SurveyCantBeEdited });
                }

                HandleSurveyAnswers(survey, data.SurveyId);

                var jObj = JObject.Parse(data.SurveyText);

                string logoUrl = HandleLogo(jObj);
                jObj = JsonHelper.SetAttributeFromJson("logo", logoUrl, jObj);

                var lang = JsonHelper.GetAttributeFromJson("locale", jObj);

                survey.SurveyTitle = data.SurveyTitle;
                survey.SurveyText = jObj.ToString().Replace("\\", "\\\\");
                survey.IsRTL = lang.ToLower().Trim() == "ar";
                survey.ImageUrl = logoUrl;

                int rows = UnitOfWork.Save();
                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = SurveysResources.ErrorOccurred });
            }
        }

        #region Update Related Methods


        private bool IsEditable(COE.Common.Model.Survey survey)
        {
            return survey.StatusId.HasValue && (SurveyStatusEnum)survey.StatusId == SurveyStatusEnum.Draft;
        }

        private void HandleSurveyAnswers(COE.Common.Model.Survey survey, int surveyId)
        {
            if (survey.SurveyAnswer.Any())
            {
                var questionAnswers = UnitOfWork.QuestionAnswer.GetByQuery(a => a.SurveyAnswer.SurveyId == surveyId).ToList();
                UnitOfWork.QuestionAnswer.Delete(questionAnswers);

                var surveyAnswers = survey.SurveyAnswer.ToList();
                UnitOfWork.SurveyAnswer.Delete(surveyAnswers);

                UnitOfWork.Save();
            }
        }

        private string HandleLogo(JObject jObj)
        {
            try
            {
                var logoBase64Str = JsonHelper.GetAttributeFromJson("logo", jObj);

                if (IsSurveyImagePathFormat(logoBase64Str))
                {
                    return logoBase64Str;
                }

                Guid newImgId = Guid.NewGuid();
                UnitOfWork.SurveyImage.Add(new SurveyImage { ID = newImgId, ImgContent = logoBase64Str, Created = DateTime.Now });
                UnitOfWork.Save();
                return Url.Action("Image", "Surveys", new { id = newImgId });
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static bool IsSurveyImagePathFormat(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string pattern = @"^/Surveys/Image/[^/]+$";
            return Regex.IsMatch(input, pattern);
        }


        #endregion

        [AllowAnonymous]
        public ActionResult Answer(int? id)
        {
            try
            {

                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (survey.AllowAnonymous.HasValue && !survey.AllowAnonymous.Value && string.IsNullOrEmpty(UserName))
                {
                    return RedirectToAction("Login", "Account", new { returnUrl = Request.Url.AbsolutePath });
                }

                if (!id.HasValue)
                {
                    return RedirectToAction("Index", "Home");
                }




                string createdBy = "unknown";
                try
                {
                    createdBy = UserName;
                    if (!string.IsNullOrEmpty(createdBy))
                    {
                        var userAnswer = UnitOfWork.SurveyAnswer.GetByQuery(a => a.CreatedBy == createdBy && a.SurveyId == id).FirstOrDefault();
                        if (userAnswer != null && survey.AllowMultiple != true)
                        {
                            return RedirectToAction("ViewAnswer", "Surveys", new { id = userAnswer.ID });
                        }
                    }
                    else
                    {
                        createdBy = Request.UserHostAddress;
                    }
                }
                catch
                {
                    createdBy = "unknown";
                }


                survey.IsActive = survey.StatusId != (int)SurveyStatusEnum.Deactivated;
                if (!survey.IsActive)
                {
                    return RedirectToAction("Expired", "Surveys", new { id = id });
                }

                //survey.SurveyText = survey.SurveyText.Insert(survey.SurveyText.Length - 1, ",\"completedHtml\":\"<p><h4>نشكركم على مشاركتكم في الإستبيان</h4></p><p>هل ترغب في إقتراح خدمات جديدة للشركة؟</p><p>للمشاركة برجاء الضفط على هذا الرابط</p>\"");
                survey.SurveyText = survey.SurveyText.Replace("\r\n", "").Replace("\n", "");
                survey.SurveyDirection = survey.IsRTL ? "rtl" : "ltr";
                if (survey.IsRTL)
                {
                    SetCulture(_cultureAr);
                }

                return View(survey);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult PublicAnswer(int? id)
        {
            try
            {


                if (!id.HasValue)
                {
                    return RedirectToAction("Index", "Home");
                }

                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                string createdBy = UserName;
                if (string.IsNullOrEmpty(createdBy))
                {
                    createdBy = Request.UserHostAddress;
                }

                if (!string.IsNullOrEmpty(createdBy))
                {
                    var userAnswer = UnitOfWork.SurveyAnswer.GetByQuery(a => a.CreatedBy == createdBy && a.SurveyId == id).FirstOrDefault();
                    if (userAnswer != null && survey.AllowMultiple != true)
                    {
                        return RedirectToAction("ViewAnswer", "Surveys", new { id = userAnswer.ID });
                    }
                }


                if (survey != null)
                {
                    survey.IsActive = survey.StatusId != (int)SurveyStatusEnum.Deactivated;
                    if (!survey.IsActive)
                    {
                        return RedirectToAction("Expired", "Surveys", new { id = id });
                    }

                    survey.SurveyText = survey.SurveyText.Replace("\n", "");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(survey);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Expired(int? id)
        {
            try
            {


                if (!id.HasValue)
                {
                    return RedirectToAction("Index", "Home");
                }

                string createdBy = UserName;
                if (string.IsNullOrEmpty(createdBy))
                {
                    createdBy = Request.UserHostAddress;
                }

                //if (!string.IsNullOrEmpty(createdBy))
                //{
                //    var userAnswer = UnitOfWork.SurveyAnswer.GetByQuery(a => a.CreatedBy == createdBy && a.SurveyId == id).FirstOrDefault();
                //    if (userAnswer != null)
                //    {
                //        //return RedirectToAction("ViewAnswer", "Surveys", new { id = userAnswer.ID });
                //    }
                //}

                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(survey);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return View();
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public JsonResult UploadAnswer(int id, string AnswerText)
        {
            try
            {

                var survey = UnitOfWork.Survey.GetById(id);
                if (survey.AllowAnonymous.HasValue && !survey.AllowAnonymous.Value && string.IsNullOrEmpty(UserName))
                {
                    return Json(new { success = false });
                }
                if (string.IsNullOrEmpty(AnswerText) || survey == null)
                {
                    return Json(new { success = false });
                }

                string createdBy = UserName;
                if (string.IsNullOrEmpty(createdBy))
                {
                    createdBy = GetClientIpAddress(Request);
                    if (string.IsNullOrEmpty(createdBy))
                    {
                        createdBy = "Anonymous";
                    }
                }

                UnitOfWork.SurveyAnswer.Add(new SurveyAnswer
                {
                    AnswerText = AnswerText,
                    QuestionAnswer = null,
                    CreatedOn = DateTime.Now,
                    SurveyId = id,
                    CreatedBy = createdBy
                });

                int rows = UnitOfWork.Save();
                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false });
            }
        }

        private Dictionary<string, string> GetChoices(string JsonContent, QuestionTypeEnum questionType)
        {
            Dictionary<string, string> choices = new Dictionary<string, string>();

            JObject jobject = JObject.Parse(JsonContent);

            if (questionType != QuestionTypeEnum.Rating)
            {
                List<JToken> options = jobject["choices"].ToList();
                var props = jobject.Properties().ToList();



                foreach (JToken option in options)
                {
                    if (option.HasValues)
                    {
                        //if (option["value"].ToString() == "other")
                        //{
                        //    option["value"] = "أخرى";
                        //}

                        choices.Add(option["value"].ToString(), option["text"].ToString());
                    }
                    else
                    {
                        choices.Add(option.ToString(), option.ToString());
                    }
                }

                if (props.Any(a => a.Name.ToString() == "hasOther"))
                {
                    if (jobject["hasOther"].ToString() == "True")
                    {
                        choices.Add("other", jobject["otherText"].ToString());
                    }
                }

            }
            else if (questionType == QuestionTypeEnum.Rating)
            {
                if (jobject["rateValues"] != null)
                {
                    List<JToken> options = jobject["rateValues"].ToList();
                    foreach (JToken option in options)
                    {
                        if (option.HasValues)
                        {
                            choices.Add(option["value"].ToString(), option["text"].ToString());
                        }
                        else
                        {
                            choices.Add(option.ToString(), option.ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        choices.Add(i.ToString(), i.ToString());
                    }
                }

            }

            return choices;
        }

        private Dictionary<string, string> GetChoices(SurveyQuestion question, out string choicesJson)
        {
            QuestionTypeEnum questionType = (QuestionTypeEnum)question.TypeId;
            choicesJson = string.Empty;

            Dictionary<string, string> separatedAnswers = new Dictionary<string, string>();
            if (questionType == QuestionTypeEnum.CheckBox || questionType == QuestionTypeEnum.RadioGroup)
            {
                choicesJson = "[";


                List<JToken> options = JObject.Parse(question.JsonContent)["choices"].ToList();
                foreach (JToken option in options)
                {
                    if (option["value"] != null)
                    {
                        choicesJson += "\"" + option["value"] + "\"" + ",";
                        separatedAnswers.Add(option["value"].ToString(), option["text"].ToString());
                    }
                    else
                    {
                        choicesJson += "\"" + option + "\"" + ",";
                        separatedAnswers.Add(option.ToString(), option.ToString());
                    }
                }

                choicesJson += "]";
                choicesJson = choicesJson.Replace(",]", "]");
            }
            else if ((QuestionTypeEnum)question.TypeId == QuestionTypeEnum.Rating)
            {
                choicesJson = "[\"1\", \"2\", \"3\", \"4\", \"5\"]";
                for (int i = 1; i <= 5; i++)
                {
                    separatedAnswers.Add(i.ToString(), i.ToString());
                }
            }


            return separatedAnswers;
        }

        private List<string> GetQuestionFinalAnswers(SurveyQuestion question)
        {
            QuestionTypeEnum questionType = (QuestionTypeEnum)question.TypeId;

            List<string> separatedAnswers = new List<string>();
            if (questionType == QuestionTypeEnum.CheckBox || questionType == QuestionTypeEnum.RadioGroup)
            {
                foreach (var answer in question.QuestionAnswer)
                {
                    var splittedAnswer = answer.AnswerText.Split(',');
                    foreach (var splt in splittedAnswer)
                    {
                        separatedAnswers.Add(splt);
                    }
                }
            }
            else
            {
                separatedAnswers.AddRange(question.QuestionAnswer.Select(a => a.AnswerText).ToList());
            }

            return separatedAnswers;
        }

        public ActionResult Result(int? id, int? PageNumber, string sqid = null)
        {
            try
            {
                //return ExportResult(id.Value);

                if (!id.HasValue)
                {
                    return RedirectToAction("Index", "Surveys");
                }



                if (!PageNumber.HasValue)
                {
                    PageNumber = 1;
                }

                var surveyItem = UnitOfWork.Survey.GetById(id);
                if (surveyItem != null)
                {

                    if (surveyItem.StatusId.HasValue && (SurveyStatusEnum)surveyItem.StatusId != SurveyStatusEnum.Approved)
                    {
                        return RedirectToAction("Index", "Surveys");
                    }


                    var answerItems = UnitOfWork.SurveyAnswer.GetByQuery(m => m.SurveyId == id).ToList().Select(a => JObject.Parse(a.AnswerText));
                    if (answerItems != null)
                    {
                        var json = JsonConvert.SerializeObject(new
                        {
                            data = answerItems
                        });

                        SurveyAllAnswers allAnswers = new SurveyAllAnswers
                        {
                            Id = id.Value,
                            AnswerItems = JsonConvert.SerializeObject(answerItems),
                            SurveyTitle = surveyItem.SurveyTitle,
                            ContentJson = surveyItem.SurveyText.Replace("\r\n", "").Replace("\n", "")
                        };


                        return View(allAnswers);
                    }

                    return View(new SurveyAllAnswers { Id = 0, ContentJson = surveyItem.SurveyText, SurveyTitle = surveyItem.SurveyText });
                }

                return View(new SurveyAllAnswers { Id = 0 });
            }
            catch (Exception)
            {
                return View(new SurveyAllAnswers { Id = 0 });
            }
        }

        public ActionResult Dashboard(int? id, int? PageNumber, string sqid = null)
        {
            try
            {
                //return ExportResult(id.Value);

                if (!id.HasValue)
                {
                    return RedirectToAction("Index", "Surveys");
                }



                if (!PageNumber.HasValue)
                {
                    PageNumber = 1;
                }

                var surveyItem = UnitOfWork.Survey.GetById(id);
                if (surveyItem != null)
                {

                    if (surveyItem.StatusId.HasValue && (SurveyStatusEnum)surveyItem.StatusId != SurveyStatusEnum.Approved)
                    {
                        return RedirectToAction("Index", "Surveys");
                    }


                    var answerItems = UnitOfWork.SurveyAnswer.GetByQuery(m => m.SurveyId == id).ToList().Select(a => JObject.Parse(a.AnswerText));
                    if (answerItems != null)
                    {
                        var json = JsonConvert.SerializeObject(new
                        {
                            data = answerItems
                        });

                        SurveyAllAnswers allAnswers = new SurveyAllAnswers
                        {
                            Id = id.Value,
                            AnswerItems = JsonConvert.SerializeObject(answerItems),
                            SurveyTitle = surveyItem.SurveyTitle,
                            ContentJson = surveyItem.SurveyText.Replace("\r\n", "").Replace("\n", "")
                        };


                        return View(allAnswers);
                    }

                    return View(new SurveyAllAnswers { Id = 0, ContentJson = surveyItem.SurveyText, SurveyTitle = surveyItem.SurveyText });
                }

                return View(new SurveyAllAnswers { Id = 0 });
            }
            catch (Exception)
            {
                return View(new SurveyAllAnswers { Id = 0 });
            }
        }

        [AllowAnonymous]
        public ActionResult ViewAnswer(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var surveyAnswer = UnitOfWork.SurveyAnswer.GetById(id);
            if (surveyAnswer != null)
            {
                surveyAnswer.AnswerText = surveyAnswer.AnswerText.Replace("\r\n", "").Replace("\n", "");
                surveyAnswer.SurveyText = surveyAnswer.Survey.SurveyText.Replace("\r\n", "").Replace("\n", "");

                if (surveyAnswer.Survey.IsRTL)
                {
                    SetCulture(_cultureAr);
                }
            }

            return View(surveyAnswer);
        }

        [HttpPost]
        public JsonResult ApproveSurvey(string idstr, int status)
        {
            try
            {
                int id;
                if (!int.TryParse(idstr, out id))
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurveyID });
                }

                if (status != 2 && status != 0)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidData });
                }

                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }

                survey.StatusId = (byte)status; // (int)SurveyStatusEnum.Approved;

                int rows = UnitOfWork.Save();

                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetSurveys(int? moduleId)
        {
            try
            {
                IQueryable<Common.Model.Survey> surveys;

                DateTime targetTime = DateTime.Now.Date;


                if (string.IsNullOrEmpty(UserName))
                {
                    surveys = UnitOfWork.Survey.GetByQuery(a => a.AllowAnonymous.Value && a.StatusId == (int)SurveyStatusEnum.Approved
                                    && targetTime >= DbFunctions.TruncateTime(a.StartDate)
                                    && targetTime <= DbFunctions.TruncateTime(a.EndDate));
                }
                else
                {
                    surveys = UnitOfWork.Survey.GetByQuery(a => a.StatusId == (int)SurveyStatusEnum.Approved
                                    && targetTime >= DbFunctions.TruncateTime(a.StartDate)
                                    && targetTime <= DbFunctions.TruncateTime(a.EndDate));
                }



                if (moduleId.HasValue)
                {
                    surveys = surveys.Where(a => a.ModuleId == moduleId.Value);
                }

                var items = surveys.Select(a => new { Key = a.ID, Value = a.SurveyTitle.Trim(), Public = a.AllowAnonymous }).ToArray();

                return Json(new { Success = true, Items = items }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }


        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "ApproveSurvey")]
        public ActionResult Approve(int? id)
        {


            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var survey = UnitOfWork.Survey.GetById(id);
            survey.ModuleText = CultureHelper.IsArabic ? survey.SurveyModules.ModuleTitleAr : survey.SurveyModules.ModuleTitleEn;
            if (survey.StatusId.Value != (int)SurveyStatusEnum.Published)
            {
                return RedirectToAction("Index", "Surveys");
            }

            return View(survey);
        }

        public List<LookupViewModel> GetAllModules()
        {
            var result = UnitOfWork.SurveyModules.GetAll().Select(a =>
                         new LookupViewModel
                         {
                             Value = a.ID,
                             Text = CultureHelper.IsArabic ? a.ModuleTitleAr : a.ModuleTitleEn
                         }).ToList(); ;

            return result;
        }

        public List<LookupViewModel> GetSurveyStatus()
        {
            List<LookupViewModel> allStatus = new List<LookupViewModel>();
            allStatus.Add(new LookupViewModel { Value = 0, Text = CultureHelper.IsArabic ? "مسودة" : "Draft" });
            allStatus.Add(new LookupViewModel { Value = 1, Text = CultureHelper.IsArabic ? "تم النشر" : "Published" });
            allStatus.Add(new LookupViewModel { Value = 2, Text = CultureHelper.IsArabic ? "تمت الموافقة" : "Approved" });
            return allStatus;
        }


        [HttpPost]
        public JsonResult UpdateSurveyStatus(int id, bool isActive)
        {
            try
            {
                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }

                survey.StatusId = (byte)(isActive ? (int)SurveyStatusEnum.Approved : (int)SurveyStatusEnum.Deactivated);

                int rows = UnitOfWork.Save();

                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }

        [HttpPost]
        public JsonResult UpdateSurveyTitle(int id, string title)
        {
            try
            {
                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }

                if (survey.SurveyTitle == title)
                {
                    return Json(new { success = true });
                }

                survey.SurveyTitle = title;
                var jObj = JObject.Parse(survey.SurveyText);
                jObj = JsonHelper.SetAttributeFromJson("title", title, jObj);


                survey.SurveyText = jObj.ToString().Replace("\\", "\\\\");

                int rows = UnitOfWork.Save();

                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }

        public string GetClientIpAddress(HttpRequestBase request)
        {
            try
            {
                var userHostAddress = request.UserHostAddress;

                // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
                // Could use TryParse instead, but I wanted to catch all exceptions
                IPAddress.Parse(userHostAddress);

                var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(xForwardedFor))
                    return userHostAddress;

                // Get a list of public ip addresses in the X_FORWARDED_FOR variable
                var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

                // If we found any, return the last one, otherwise return the user host address
                return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                // Always return all zeroes for any failure (my calling code expects it)
                return "";
            }
        }

        private bool IsPrivateIpAddress(string ipAddress)
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }


        [HttpPost]
        public ActionResult ExportResult(SurveysViewModel model)
        {
            return null;
            //try
            //{
            //    int id = model.Id;
            //    var survey = UnitOfWork.Survey.GetById(id);
            //    var questions = survey.SurveyQuestion.ToList();

            //    var answers = survey.SurveyAnswer.ToList();

            //    int questionsCount = questions.Count;
            //    int answersCount = survey.SurveyAnswer.Count;

            //    KeyValuePair<string, string>[,] surveyMatrix = new KeyValuePair<string, string>[questionsCount, answersCount + 1];

            //    for (int x = 0; x < questionsCount; x++)
            //    {
            //        int y = 0;

            //        if (string.IsNullOrEmpty(questions[x].Title))
            //        {
            //            surveyMatrix[x, y++] = new KeyValuePair<string, string>(questions[x].Name, questions[x].Name);
            //        }
            //        else
            //        {
            //            surveyMatrix[x, y++] = new KeyValuePair<string, string>(questions[x].Name, questions[x].Title);
            //        }

            //        for (int i = 0; i < answersCount; i++)
            //        {
            //            if (answers[i].QuestionAnswer.Any())
            //            {
            //                var allValues = answers[i].QuestionAnswer.Where(a => a.QuestionId == questions[x].Id).ToList();
            //                string collectedAnswer = "";
            //                foreach (var item in allValues)
            //                {
            //                    if (item.OptionId.HasValue)
            //                    {
            //                        collectedAnswer += item.QuestionOption.OptionValue + ",";
            //                    }
            //                    else
            //                    {
            //                        collectedAnswer += item.AnswerText + ",";
            //                    }
            //                }

            //                if (!string.IsNullOrEmpty(collectedAnswer))
            //                {
            //                    collectedAnswer = collectedAnswer.Substring(0, collectedAnswer.Length - 1);
            //                }

            //                surveyMatrix[x, y++] = new KeyValuePair<string, string>("", collectedAnswer);
            //            }
            //        }
            //    }


            //    var stream = new MemoryStream();
            //    var writer = new StreamWriter(stream, Encoding.UTF8);
            //    var csv = new CsvWriter(writer);


            //    csv.WriteField("Answered By");
            //    for (int i = 0; i < questionsCount; i++)
            //    {
            //        csv.WriteField(surveyMatrix[i, 0].Value);
            //    }
            //    csv.NextRecord();


            //    for (int y = 0; y < answersCount; y++)
            //    {
            //        csv.WriteField(answers[y].CreatedBy);
            //        for (int x = 0; x < questionsCount; x++)
            //        {
            //            csv.WriteField(surveyMatrix[x, y + 1].Value);
            //        }
            //        csv.NextRecord();
            //    }

            //    writer.Flush();
            //    stream.Position = 0;

            //    return File(stream, "text/csv", "SurveyResult.csv");
            //    // return itemsReport;
            //}


            ////   return File(stream, "text/csv", "Attendance_Export_" + startDate.ToShortDateString() + "_" + endDate.ToShortDateString() + ".csv");

            //catch (Exception ex)
            //{
            //    Logger.Error(ex);
            //    ViewBag.success = 0;
            //    return null;
            //}
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SetLanguage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new EmptyResult();
            }

            value = value.Trim().ToLower();
            switch (value)
            {
                case "ar":
                    SetCulture(_cultureAr);
                    break;
                default:
                    SetCulture(_cultureEn);
                    break;
            }

            HttpContext.Session["lang"] = value ?? "";
            return new EmptyResult();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Image(Guid id)
        {
            byte[] file;

            try
            {
                var img = UnitOfWork.SurveyImage.GetById(id);
                if (img != null)
                {
                    file = CustomFileUploader.ConvertBase64StringToByteArray(img.ImgContent);
                }
                else
                {
                    file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/test.jpeg"));
                }
            }
            catch (Exception ex)
            {
                file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/images/test.jpeg"));
            }

            return File(file, "image/jpeg");
        }


        [HttpPost]
        public JsonResult CheckIfHasAnswer(int id)
        {
            try
            {
                var hasAnswer = UnitOfWork.SurveyAnswer.GetByQuery(a => a.SurveyId == id).Any();
                if (hasAnswer)
                {
                    return Json(new { success = hasAnswer, errorMessage = SurveysResources.ConfirmDeleteAnswers });
                }

                return Json(new { success = hasAnswer, errorMessage = "" });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }

        [HttpPost]
        public JsonResult RevertToDraftConfirmed(int id)
        {
            try
            {
                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return Json(new { success = false, errorMessage = SurveysResources.InvalidSurvey });
                }

                HandleSurveyAnswers(survey, survey.ID);

                survey.StatusId = (byte)(int)SurveyStatusEnum.Draft;

                int rows = UnitOfWork.Save();

                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = "" });
            }
        }
    }

    public class SurvyJsonObject
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyText { get; set; }

        public bool IsRTL { get; set; }
    }
}