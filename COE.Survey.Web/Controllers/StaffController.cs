using System.Web.Mvc;
using COE.Common.Helper;
using COE.Common.Model;
using System;
using System.Linq;
using COE.Common.Localization.Security;
using COE.Common.BLL;
using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using Commons.Framework.Data;
using PagedList;
using UsersMgmt;
using COE.Survey.BLL;
using System.Collections.Generic;
using Commons.Framework.Notifications;
using COE.Survey.Web.Filters;
using Commons.Framework.Resources;

namespace COE.Survey.Web.Controllers
{
    [Authorize]
    [ModuleAuthorize("Security", "Staff")]
    public class StaffController : BaseController<COEUoW>
    {
        [ModuleAuthorize("Security", "Staff", ActionName = "Search")]
        public ActionResult Index(StaffSearchViewModel model, int? success)
        {
            this.LoadAuthorizationModuleActions("Security", "Staff");
            string successMessage = string.Empty;
            ViewBag.MessageType = BLL.Enum.MessageType.success.ToString();

            switch (success)
            {
                case (int)Common.Model.Enums.Enum.SaveStaus.Saved:
                    successMessage = SecurityResources.StaffMemberSavedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.Updated:
                    successMessage = SecurityResources.StaffMemberUpdatedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.ItemError:
                    successMessage = SecurityResources.ErrorOccured;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.Deleted:
                    successMessage = SecurityResources.StaffMemberDeletedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist:
                    successMessage = SecurityResources.UserAlreadyRegistred;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.UserNameAlreadyRegistered:
                    successMessage = SecurityResources.UserNameAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.EmailAlreadyRegistered:
                    successMessage = SecurityResources.EmailAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.PhoneNumberAlreadyRegistered:
                    successMessage = SecurityResources.PhoneNumberAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;

                case (int)Common.Model.Enums.Enum.SaveStaus.DeleteError:
                    successMessage = SecurityResources.ErrorMessageCannotDelete;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;

                default:
                    break;
            }
            ViewBag.SuccessMessage = successMessage;

            return View(model);
        }

        [ModuleAuthorize("Security", "Staff", ActionName = "New")]
        [HttpGet]
        public ActionResult Add(int? success)
        {

            string successMessage = string.Empty;
            ViewBag.MessageType = BLL.Enum.MessageType.success.ToString();

            switch (success)
            {
                case (int)Common.Model.Enums.Enum.SaveStaus.Saved:
                    successMessage = SecurityResources.UserSavedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.Updated:
                    successMessage = SecurityResources.UserSavedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.UserNameAlreadyRegistered:
                    successMessage = SecurityResources.UserNameAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.EmailAlreadyRegistered:
                    successMessage = SecurityResources.EmailAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.PhoneNumberAlreadyRegistered:
                    successMessage = SecurityResources.PhoneNumberAlreadyRegistered;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    break;
                default:
                    break;
            }

            ViewBag.SuccessMessage = successMessage;
            return View();
        }

        [HttpPost]
        public ActionResult Add(CollegeStaff model)
        {
            if (!this.ModelState.IsValid)
            {
                if (model.TypeID == 1)
                {
                    ViewBag.AdminTitleDisplay = "display:block";
                }
                if (model.TypeID == 2)
                {
                    ViewBag.LevelDisplay = "display:block";
                }
                return this.View(model);
            }

            var staffUser = new CollegeStaff
            {
                ID = model.ID,
                Name = model.Name.Trim(),
                Email = model.Email.Trim(),
                Phone = model.Phone,
                EffectiveDate = model.EffectiveDate,
                LeaveDate = model.LeaveDate,
                CollegeID = model.CollegeID,
                TypeID = model.TypeID,
                AdminTitle = model.AdminTitle,
                VisaTypeID = model.VisaTypeID,
                NationalityID = model.NationalityID,
                QualificationID = model.QualificationID,
                SpesializationID = model.SpesializationID,
                LeaveReasonID = model.LeaveReasonID,
                JobTypeID = model.JobTypeID,
                LastQualificationDate = model.LastQualificationDate,
                Gender = model.Gender,
                LevelID = model.TypeID == 2 ? model.LevelID : null,
                IsUser = false,
                CreatedBy = UserName,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            var result = this.UnitOfWork.CollegeStaff.Save(staffUser);
            if (result != 1)
            {
                string Message = string.Empty;
                if (result == (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist)
                {
                    Message = SecurityResources.UserNameAlreadyRegistered;
                }
                if (result == (int)Common.Model.Enums.Enum.SaveStaus.ItemError)
                {
                    Message = SharedResources.UnexpectedError;
                }
                Header.ShowError(Message, true);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Staff", new { Success = result });
            }
        }

        [ModuleAuthorize("Security", "Staff", ActionName = "Update")]
        [HttpGet]
        public ActionResult Edit(int? id, int? success)
        {
            try
            {
                if (id == 0) return RedirectToAction("Index");
                ViewBag.LevelDisplay = "display:none";
                ViewBag.AdminTitleDisplay = "display:none";

                //get collegeStaff by Id
                var collegeStaff = UnitOfWork.CollegeStaff.GetById(id);

                if (collegeStaff.TypeID == 1)
                {
                    ViewBag.AdminTitleDisplay = "display:block";
                }
                if (collegeStaff.TypeID == 2)
                {
                    ViewBag.LevelDisplay = "display:block";
                }
                return View(collegeStaff);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ViewBag.success = (byte)Common.Model.Enums.Enum.RowStaus.Warning;
                return View();
            }

        }

        [HttpPost]
        public ActionResult Edit(CollegeStaff model, int id = 0)
        {
            try
            {
                if (id == 0) return View(model);

                //get City by Id
                var collegeStaff = UnitOfWork.CollegeStaff.GetById(id);

                // edit item 
                collegeStaff.Name = model.Name.Trim();
                collegeStaff.Email = model.Email.Trim();
                collegeStaff.Phone = model.Phone;
                collegeStaff.EffectiveDate = model.EffectiveDate;
                collegeStaff.LeaveDate = model.LeaveDate;
                collegeStaff.CollegeID = model.CollegeID;
                collegeStaff.TypeID = model.TypeID;
                collegeStaff.AdminTitle = model.AdminTitle;
                collegeStaff.VisaTypeID = model.VisaTypeID;
                collegeStaff.QualificationID = model.QualificationID;
                collegeStaff.SpesializationID = model.SpesializationID;
                collegeStaff.NationalityID = model.NationalityID;
                collegeStaff.Gender = model.Gender;
                collegeStaff.JobTypeID = model.JobTypeID;
                collegeStaff.LastQualificationDate = model.LastQualificationDate;
                collegeStaff.LeaveReasonID = model.LeaveReasonID;

                collegeStaff.LevelID = model.TypeID == 2 ? model.LevelID : null;
                collegeStaff.UpdatedBy = UserName;

                UnitOfWork.CollegeStaff.Update(collegeStaff);

                //update user with phone number
                if (!string.IsNullOrEmpty(collegeStaff.Phone))
                {
                    var aspUser = UnitOfWork.AspNetUsers.GetByQuery(x => x.Email == collegeStaff.Email).FirstOrDefault();
                    if (aspUser != null)
                    {
                        aspUser.PhoneNumber = collegeStaff.Phone.Trim();
                        UnitOfWork.AspNetUsers.Update(aspUser);
                    }
                }

                UnitOfWork.Save();
                return RedirectToAction("Index", new { success = (int)Common.Model.Enums.Enum.SaveStaus.Updated });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ViewBag.success = (int)Common.Model.Enums.Enum.SaveStaus.ItemError;
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(int? staffId)
        {
            try
            {
                UnitOfWork.CollegeStaff.DeleteById(staffId);
                UnitOfWork.Save();
                return Json(new { success = true, Result = Common.Model.Enums.Enum.SaveStaus.Deleted, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.DeleteError, ErrorMessage = string.Format(SecurityResources.ErrorMessageCannotDelete, "member") }, JsonRequestBehavior.AllowGet);
            }
        }

        [ModuleAuthorize("Security", "Staff", ActionName = "CreateUser")]
        [HttpPost]
        public JsonResult CreateAspUser(int? id)
        {

            try
            {
                var collegestaff = UnitOfWork.CollegeStaff.GetById(id);


                //add data to aspnet user
                var applicationUser = new UsersMgmt.Model.ApplicationUser
                {
                    FullName = collegestaff.Name.Trim(),
                    UserName = collegestaff.Email.Trim(),
                    PhoneNumber = collegestaff.Phone,
                    NationalId = "0000000000",
                    Email = collegestaff.Email,
                    EmailConfirmed = true,
                    IsActive = true,
                    Password = Commons.Framework.Extensions.StringExtensions.RandomString(6),
                    CountryId = 1,
                    DefaultLanguageId = 1
                };

                var result =
                    UsersFacade.RegisterUser(applicationUser, null);

                if (!result.IsValid)
                {
                    this.ModelState.Merge(result.ModelState);
                    // Show Failed Message In New View
                    this.Header.ShowError(UsersMgmtResources.RegistrationFailed, true);
                    if (result.ModelState.Keys.Where(x => x == "UserName").Any())
                    {
                        return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.UserNameAlreadyRegistered, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
                    }

                    if (result.ModelState.Keys.Where(x => x == "Email").Any())
                    {
                        return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.EmailAlreadyRegistered, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
                    }

                    if (result.ModelState.Keys.Where(x => x == "PhoneNumber").Any())
                    {
                        return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.PhoneNumberAlreadyRegistered, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.AlreadyExist, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    //add data to user display
                    var userdisplay = new UserDisplay
                    {
                        ID = Guid.NewGuid(),
                        AspNetUserID = applicationUser.Id,
                        IsActive = true,
                        LoginName = applicationUser.UserName.Trim(),
                        DisplayName = applicationUser.UserName.Trim(),
                        CreatedBy = UserName,
                        UpdatedBy = UserName,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = DateTime.Now
                    };

                    //add data to user colleges
                    userdisplay.UserCollege.Add(new UserCollege
                    {
                        UserDisplayID = userdisplay.ID,
                        CollegeID = collegestaff.CollegeID.Value,
                        CreatedBy = UserName,
                        UpdatedBy = UserName,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = DateTime.Now
                    });

                    UnitOfWork.UserDisplay.Add(userdisplay);

                    //flag the user as AspUser
                    collegestaff.IsUser = true;
                    UnitOfWork.CollegeStaff.Update(collegestaff);

                    UnitOfWork.Save();

                    Session["Message"] = SecurityResources.UserCreatedWithAddRoleNotification;

                    return Json(new { success = true, Result = userdisplay.ID, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                //Error Message
                return Json(new { success = false, Result = Common.Model.Enums.Enum.SaveStaus.ItemError, ErrorMessage = SecurityResources.ErrorOccured }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}