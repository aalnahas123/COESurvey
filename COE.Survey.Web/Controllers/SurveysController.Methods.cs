using COE.Common.Helper;
using COE.Common.Localization;
using COE.Common.Localization.Security;
using COE.Common.Model;
using COE.Common.Model.ViewModels;
using COE.Survey.BLL;
using COE.Survey.Web.Filters;
using COE.Survey.Web.Helpers;
using COE.Survey.Web.ViewModels;
using Commons.Framework.Data;
using Commons.Framework.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace COE.Survey.Web
{
    public partial class SurveysController
    {
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

                var newSurvey = new Common.Model.Survey
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
                };

                UnitOfWork.Survey.Add(newSurvey);
                int rows = UnitOfWork.Save();

                if (newSurvey.ID > 0)
                {
                    var added = SurveyApproversHelper.UpdateUserApprovers(UnitOfWork, newSurvey.ID, this.UserName);
                }

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
                bool isOldSurvey = UnitOfWork.SurveyApprover.GetByQuery(ex => ex.SurveyId == data.SurveyId).Count() == 0;
                if (rows > 0 && isOldSurvey)
                {
                    var added = SurveyApproversHelper.UpdateUserApprovers(UnitOfWork, data.SurveyId, this.UserName);
                }
                return Json(new { success = rows > 0 });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false, errorMessage = SurveysResources.ErrorOccurred });
            }
        }

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


                var answerToBeUploaded = new SurveyAnswer
                {
                    AnswerText = AnswerText,
                    QuestionAnswer = null,
                    CreatedOn = DateTime.Now,
                    SurveyId = id,
                    CreatedBy = createdBy
                };


                UnitOfWork.SurveyAnswer.Add(answerToBeUploaded);
                int rows = UnitOfWork.Save();

                if (rows > 0)
                {
                    if (id == 231)
                    {
                        FixUploadedAnswer(answerToBeUploaded);
                    }
                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(new { success = false });
            }
        }

        public void FixUploadedAnswer(SurveyAnswer answer)
        {
            try
            {
                var parsedAnswer = JObject.Parse(answer.AnswerText);
                var parsedAnswerId = answer.ID;

                ProcessQuestion(parsedAnswer, "question9", parsedAnswerId);
                ProcessQuestion(parsedAnswer, "question15", parsedAnswerId);
                ProcessQuestion(parsedAnswer, "question14", parsedAnswerId);

                answer.AnswerText = parsedAnswer.ToString();
                UnitOfWork.SurveyAnswer.Update(answer);
                UnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
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
            try
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
            catch (Exception ex)
            {
                return null;

            }

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SurveyFile(Guid id)
        {
            try
            {
                byte[] file;

                var surveyAttachement = UnitOfWork.SurveyAttachement.GetById(id);
                if (surveyAttachement != null)
                {
                    file = Convert.FromBase64String(surveyAttachement.FileContent);
                    return File(file, GetFileTypeFromFileName(surveyAttachement.FileName), surveyAttachement.FileName);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }


        private string GetFileTypeFromFileName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName).ToLower();

            switch (fileExtension)
            {
                case ".png":
                    return "image/png";
                case ".pdf":
                    return "application/pdf";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".pptx":
                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case ".csv":
                    return "text/csv";
                case ".doc":
                    return "application/msword";
                default:
                    return "application/octet-stream";
            }
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

        public ActionResult Index(AspNetUsersSearchModel model, int? success)
        {
            this.LoadAuthorizationModuleActions("Security", "User");


            var usersQuery = UnitOfWork.UserDisplay.GetAll();

            if (!string.IsNullOrEmpty(model.NationalId))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.NationalId.Contains(model.NationalId));
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                usersQuery = usersQuery.Where(x => x.LoginName.ToLower().Contains(model.UserName.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.UserNameOnline))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.UserName.ToLower().Contains(model.UserNameOnline.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.Email.ToLower().Contains(model.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.UserType))
            {
                if (model.UserType == "1")
                {
                    usersQuery = usersQuery.Where(x => x.AspNetUserID == null);
                }
                else if (model.UserType == "2")
                {
                    usersQuery = usersQuery.Where(x => x.AspNetUserID != null);
                }

            }

            var aspNetUsers = UnitOfWork.AspNetUsers.GetAll().Where(u => u.UserDisplay.Any());


            var users = usersQuery
            .ToList().Select(x => new AccountViewModel
            {
                NationalId = x.AspNetUsers?.NationalId ?? SecurityResources.EmptyValue,
                Email = x.AspNetUsers != null ? x.AspNetUsers.Email : x.LoginName.Replace("coe\\", "") + ".coe.com.sa",
                FullName = x.AspNetUsers != null ? x.AspNetUsers.FullName : x.DisplayName,
                UserName = x.AspNetUsers != null ? x.AspNetUsers.UserName : x.LoginName.Replace("coe\\", ""),
                PhoneNumber = x.AspNetUsers?.PhoneNumber ?? SecurityResources.EmptyValue,
                Id = x.ID,
                IsActive = x.IsActive,
                Type = x.AspNetUsers != null ? ((int)COE.Common.Model.Enums.Enum.UserType.Online) : ((int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory)
            });


            if (model != null)
            {
                var UsersList = users.AsQueryable()
                    .GetPaged(x => x.NationalId, false, model.PageNumber, BLL.AppSettings.DefaultPagerPageSize);

                model.Items = new StaticPagedList<AccountViewModel>(
                                      UsersList.ToList(),
                                      UsersList.PageNumber,
                                      UsersList.PageSize,
                                      UsersList.TotalItemCount);

                // if has request ajax we'll be load Partial View
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Users", model);
                }

                ViewBag.success = success;
            }
            return View(model);
        }


        public ActionResult Fix(int? id)
        {
            try
            {
                var survey = UnitOfWork.Survey.GetById(id);
                if (survey == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var answerIdsList = UnitOfWork.SurveyAnswer
                    .GetByQuery(m => m.SurveyId == id).Select(a => a.ID).ToArray();

                if (answerIdsList != null && answerIdsList.Any())
                {
                    for (int i = 0; i < answerIdsList.Length; i++)
                    {
                        var answerItem = UnitOfWork.SurveyAnswer.GetById(answerIdsList[i]);
                        var parsedAnswer = JObject.Parse(answerItem.AnswerText);
                        var parsedAnswerId = answerItem.ID;

                        ProcessQuestion(parsedAnswer, "question9", parsedAnswerId);
                        ProcessQuestion(parsedAnswer, "question15", parsedAnswerId);
                        ProcessQuestion(parsedAnswer, "question14", parsedAnswerId);

                        // Update the answer text with the modified JSON
                        answerItem.AnswerText = parsedAnswer.ToString();
                        UnitOfWork.SurveyAnswer.Update(answerItem);
                        UnitOfWork.Save();
                    }
                    
                    return View(); 
                }

                return View(survey);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return View();
            }
        }

        private void ProcessQuestion(JObject parsedAnswer, string questionKey, int parsedAnswerId)
        {
            if (parsedAnswer[questionKey] != null)
            {
                JArray questionArray = (JArray)parsedAnswer[questionKey];
                for (int i = 0; i < questionArray.Count; i++)
                {
                    var item = questionArray[i];
                    var content = item["content"]?.ToString();
                    var fileName = item["name"]?.ToString();
                    var fileType = item["type"]?.ToString();

                    if (content != null && fileName != null && fileType != null)
                    {
                        var base64Data = content.Split(',')[1];
                        var fileData = Convert.FromBase64String(base64Data);
                        var fileExtension = string.Empty;

                        if (fileType.Contains("png"))
                        {
                            fileExtension = "png";
                        }
                        else if (fileType.Contains("pdf"))
                        {
                            fileExtension = "pdf";
                        }
                        else if (fileType.Contains("jpg") || fileType.Contains("jpeg"))
                        {
                            fileExtension = "jpg";
                        }
                        else if (fileName.Contains("xlsx"))
                        {
                            fileExtension = "xlsx";
                        }
                        else if (fileName.Contains("docx"))
                        {
                            fileExtension = "docx";
                        }
                        else if (fileName.Contains("pptx"))
                        {
                            fileExtension = "pptx";
                        }
                        else if (fileName.Contains("csv"))
                        {
                            fileExtension = "csv";
                        }
                        else if (fileName.Contains("doc"))
                        {
                            fileExtension = "doc";
                        }
                        else
                        {

                        }


                        if (!string.IsNullOrEmpty(fileExtension))
                        {
                            var uniqueFileName = $"{parsedAnswerId}_{questionKey}_{fileName}";
                            // Save the file to the database
                            Guid newImgId = Guid.NewGuid();
                            UnitOfWork.SurveyAttachement.Add(new SurveyAttachement
                            {
                                SurveyAnswerID = parsedAnswerId,
                                ID = newImgId,
                                FileContent = base64Data,
                                Created = DateTime.Now,
                                FileName = uniqueFileName
                            });

                            var fileUrl = $"/Surveys/SurveyFile/{newImgId}";
                            questionArray[i]["content"] = fileUrl;
                        }
                    }
                }
            }
        }





    }


}