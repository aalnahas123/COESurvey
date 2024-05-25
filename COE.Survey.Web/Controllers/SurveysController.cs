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
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using COE.Survey.Web.ViewModels;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using Microsoft.AspNet.Identity;
using DevExpress.Xpo.DB.Helpers;

namespace COE.Survey.Web
{
    [Authorize]
    public partial class SurveysController : BaseController<COEUoW>
    {
        public bool HasUserDisplay => UnitOfWork.UserDisplay.HasUserDisplay(UserName);

        [ModuleAuthorize("Survey", "SurveyModule")]
        [HttpGet]
        public ActionResult Index(int? moduleId, string msg)
        {
            LoadAuthorizationModuleActions("Survey", "SurveyModule");

            var isSurveyAdmin = IsUserSurveyAdmin();

            ViewBag.Modules = GetAllModules();
            ViewBag.AllStatus = GetSurveyStatus();

            //var test = SurveyApproversHelper.UpdateUserApprovers(UnitOfWork, 28, this.UserName);


            var userSurveysToApprove = UnitOfWork.SurveyApprover.GetByQuery(a => a.ApproverUsername == this.UserName).Select(a => a.SurveyId).ToArray();
            var userSurveysToView = UnitOfWork.SurveyViewer.GetByQuery(a => a.ViewerUsername == this.UserName.Replace("coe\\", "")).Select(a => a.SurveyId).ToArray();
            var query = UnitOfWork.Survey.GetAll();

            if (moduleId.HasValue)
            {
                query = query.Where(a => a.ModuleId == moduleId.Value);
            }

            if (!isSurveyAdmin)
            {
                if (IsUserSurveyCreator() || IsUserSurveyApproval() || IsUserSurveyPublisher())
                {
                    query = query.Where(a => a.CreatedBy == this.UserName || userSurveysToApprove.Contains(a.ID) || userSurveysToView.Contains(a.ID));
                }
            }

            var surveys = query.OrderByDescending(a => a.CreatedOn).ToList();

            foreach (var item in surveys)
            {

                // No need for it 
                //try
                //{
                //    var jObj = JObject.Parse(item.SurveyText);
                //    var imgurl = JsonHelper.GetAttributeFromJson("logo", jObj);
                //    item.ImageUrl = imgurl;
                //}
                //catch
                //{


                //}


                item.ModuleText = CultureHelper.IsArabic ? item.SurveyModules?.ModuleTitleAr : item.SurveyModules?.ModuleTitleEn;
                item.SurveyLink = Url.Action("Answer", "Surveys", new { id = item.ID });
                item.IsActive = item.StatusId != (int)SurveyStatusEnum.Deactivated;
            }

            SurveysViewModel allItems = new SurveysViewModel { SurviesList = surveys, ErrorMsg = msg };
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


        [ModuleAuthorize("Survey", "SurveyModule")]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var survey = UnitOfWork.Survey.GetById(id);
            survey.SurveyText = survey.SurveyText.Replace("\r\n", "").Replace("\n", "");


            if (survey.StatusId.HasValue && (SurveyStatusEnum)survey.StatusId != SurveyStatusEnum.Draft)
            {
                return RedirectToAction("Index", "Surveys");
            }

            var isSurveyAdmin = IsUserSurveyAdmin();
            if (isSurveyAdmin)
            {
                return View(survey);
            }


            if (IsUserSurveyCreator() || IsUserSurveyApproval() || IsUserSurveyPublisher())
            {
                var isViewerWithEdit = UnitOfWork.SurveyViewer.GetByQuery(a => a.SurveyId == id && a.ViewerUsername == this.UserName && a.CanEdit == true).Any();
                if (!isViewerWithEdit)
                {
                    return RedirectToAction("Index", "Surveys", new { msg = SharedResources.UnauthorizedAccess });
                }

                return View(survey);
            }

            return RedirectToAction("Index", "Surveys", new { msg = SharedResources.UnauthorizedAccess });
        }



        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "CreateSurvey")]
        public ActionResult Add()
        {

            ViewBag.Modules = UnitOfWork.SurveyModules.GetAll().ToList();
            return View();
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

        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "CreateSurvey")]
        public ActionResult SurveyUsers(SurveyUsersViewModel model, int? id, int? success, string SelectedUserName, string SelectedUserCanEdit, string action)
        {
            this.LoadAuthorizationModuleActions("Security", "User");

            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Surveys");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var survey = UnitOfWork.Survey.GetById(id);
            if (survey == null)
            {
                return RedirectToAction("Index", "Surveys");
            }


            string currentSurveyCreator = IsUserSurveyAdmin() ? survey.CreatedBy.Replace("coe\\", "") : UserName; // in case admin is editing 

            survey.ModuleText = CultureHelper.IsArabic ? survey.SurveyModules?.ModuleTitleAr : survey.SurveyModules?.ModuleTitleEn;
            model.currentSurvey = survey;

            switch (action)
            {
                case "search":
                default:
                    break;
                case "add":
                    SurveyViewersHelper.AddUserViewer(UnitOfWork, survey.ID, currentSurveyCreator, SelectedUserName, SelectedUserCanEdit == "true");
                    break;
                case "edit":
                    SurveyViewersHelper.UpdateUserViewer(UnitOfWork, survey.ID, currentSurveyCreator, SelectedUserName, SelectedUserCanEdit == "true");
                    break;
                case "delete":
                    SurveyViewersHelper.DeleteUserViewer(UnitOfWork, survey.ID, currentSurveyCreator, SelectedUserName, SelectedUserCanEdit == "true");
                    break;
            }

            var surveyusers = UnitOfWork.SurveyViewer.GetByQuery(a => a.SurveyId == id).ToList();
            model.currentSurvetyUsers = surveyusers;

            var usersQuery = UnitOfWork.UserDisplay.GetAll();

            if (!string.IsNullOrEmpty(model.users.NationalId))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.NationalId.Contains(model.users.NationalId));
            }

            if (!string.IsNullOrEmpty(model.users.UserName))
            {
                usersQuery = usersQuery.Where(x => x.LoginName.ToLower().Contains(model.users.UserName.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.users.UserNameOnline))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.UserName.ToLower().Contains(model.users.UserNameOnline.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.users.Email))
            {
                usersQuery = usersQuery.Where(x => x.AspNetUserID != null && x.AspNetUsers.Email.ToLower().Contains(model.users.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.users.UserType))
            {
                if (model.users.UserType == "1")
                {
                    usersQuery = usersQuery.Where(x => x.AspNetUserID == null);
                }
                else if (model.users.UserType == "2")
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


            if (surveyusers.Any())
            {
                users = users.Where(a => !surveyusers.Any(b => b.ViewerUsername == a.UserName));
            }


            if (model != null)
            {
                var UsersList = users.AsQueryable()
                    .GetPaged(x => x.NationalId, false, model.users.PageNumber, BLL.AppSettings.DefaultPagerPageSize);

                model.users.Items = new StaticPagedList<AccountViewModel>(
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




            return View(model);
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