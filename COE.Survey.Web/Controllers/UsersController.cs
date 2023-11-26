using System.Web.Mvc;
using COE.Common.Helper;
using COE.Common.Model;
using System;
using System.Linq;
using COE.Common.Localization.Security;
using COE.Common.BLL;
using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using COE.Common.Model.ViewModels.Security;
using COE.Survey.BLL;
using UsersMgmt.ActiveDirectory;
using COE.Survey.Web.Filters;
using Commons.Framework.Globalization;
using System.Collections.Generic;
using WebGrease.Css.Extensions;
using System.Transactions;
using PagedList;
using Commons.Framework.Data;
using System.Linq.Dynamic;

namespace COE.Survey.Web
{
    [Authorize]
    [ModuleAuthorize("Survey", "SurveyModule")]
    public class UsersController : BaseController<COEUoW>
    {
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

        // GET: Show view
        //[ModuleAuthorize("Training", "Centers",ActionName ="AddCenter")]

        //[ModuleAuthorize("Survey", "User", ActionName = "New")]
        [HttpGet]
        public ActionResult Add(AccountViewModel model, int? success, string userType)
        {
            ViewBag.DisplayOnline = "";
            ViewBag.DisplayAD = "d-none";
            model.UserType = userType ?? ((int)COE.Common.Model.Enums.Enum.UserType.Online).ToString();

            if (model.UserType == ((int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString())
            {
                ViewBag.DisplayAD = "";
                ViewBag.DisplayOnline = "d-none";
            }
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
                case (int)Common.Model.Enums.Enum.SaveStaus.NotExist:
                    successMessage = SecurityResources.UserNotExist;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    ViewBag.DisplayAD = "";
                    ViewBag.DisplayOnline = "d-none";
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist:
                    successMessage = SecurityResources.UserAlreadyRegistred;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    ViewBag.DisplayAD = "";
                    ViewBag.DisplayOnline = "d-none";
                    break;
                default:
                    break;
            }
            ViewBag.SuccessMessage = successMessage;
            ModelState.Clear();
            return View(model);
        }
        // POST: Add Center
        //[ModuleAuthorize("Training", "Centers",ActionName ="AddCenter")]
        [HttpPost]
        public ActionResult Add(AccountViewModel model)
        {
            Guid newID = new Guid();

            if (model.UserType == ((int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString())
            {
                ViewBag.DisplayAD = "";
                ViewBag.DisplayOnline = "d-none";
                bool isUserExist = false;
                try
                {
                    isUserExist = AdUserAdapter.Instance.IsUserExsit(model.AccountViewModelActiveDirectory.UserName);
                    //is UserExist in active directory
                    if (isUserExist)
                    {
                        var user = UnitOfWork.UserDisplay.GetByQuery(x => x.LoginName.ToLower() == "coe\\" + model.AccountViewModelActiveDirectory.UserName.ToLower());
                        if (user.Count() > 0)
                        {
                            return RedirectToAction("Add", new
                            {
                                success = (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist,
                                userType = "1"
                            });
                        }

                    }
                    else
                    {
                        return RedirectToAction("Add", new
                        {
                            success = (int)Common.Model.Enums.Enum.SaveStaus.NotExist,
                            userType = "1"
                        });
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Add", new
                    {
                        success = (int)Common.Model.Enums.Enum.SaveStaus.NotExist,
                        userType = "1"
                    });
                }

                var userdisplay = new UserDisplay
                {
                    ID = Guid.NewGuid(),
                    AspNetUserID = null,
                    IsActive = true,
                    LoginName = model.AccountViewModelActiveDirectory.UserName.Contains("coe\\") ? model.AccountViewModelActiveDirectory.UserName : "coe\\" + model.AccountViewModelActiveDirectory.UserName,
                    DisplayName = model.AccountViewModelActiveDirectory.FullName,
                    CreatedBy = UserName,
                    UpdatedBy = UserName,
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                };
                UnitOfWork.UserDisplay.Add(userdisplay);
                UnitOfWork.Save();

                Session["Message"] = SecurityResources.UserCreatedWithAddRoleNotification;
                return RedirectToAction("Index", "Users", new
                {
                    UserType = model.UserType,
                    uid = newID
                });
            }
            else
            {
                ViewBag.DisplayOnline = "";
                ViewBag.DisplayAD = "d-none";

                ModelState.Remove("AccountViewModelActiveDirectory.FullName");
                ModelState.Remove("AccountViewModelActiveDirectory.UserName");
                ModelState.Remove("NationalId");
                ModelState.Remove("Captcha");
                ModelState.Remove("RecaptchaResponse");
                ModelState.Where(ms => ms.Key.Contains("Providers")).ForEach(p => ModelState[p.Key].Errors.Clear());

                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                var userDisplay = UnitOfWork.UserDisplay.GetByQuery(x => x.LoginName.ToLower() == model.UserName.ToLower().Trim()).FirstOrDefault();
                if (userDisplay != null)
                {
                    Header.ShowError(SecurityResources.UserNameAlreadyRegistered, true);
                    return View(model);
                }
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {

                        var applicationUser = new UsersMgmt.Model.ApplicationUser
                        {
                            FullName = model.FullName.Trim(),
                            UserName = model.UserName.Trim(),
                            PhoneNumber = model.PhoneNumber,
                            NationalId = "0000000000",
                            Email = model.Email.Trim(),
                            EmailConfirmed = true,
                            IsActive = true,
                            Password = model.Password,
                            CountryId = 1,
                            DefaultLanguageId = 1,
                            CreatedOn = DateTime.Now
                        };

                        var result =
                            UsersFacade.RegisterUser(applicationUser, null);

                        if (!result.IsValid)
                        {
                            this.ModelState.Merge(result.ModelState);
                            // Show Failed Message In New View
                            this.Header.ShowError(UsersMgmtResources.RegistrationFailed, true);
                            return View(model);
                        }
                        else
                        {


                            var userdisplay = new UserDisplay
                            {
                                ID = Guid.NewGuid(),
                                AspNetUserID = applicationUser.Id,
                                IsActive = true,
                                LoginName = applicationUser.UserName,
                                DisplayName = applicationUser.UserName,
                                CreatedBy = UserName,
                                UpdatedBy = UserName,
                                UpdatedOn = DateTime.Now,
                                CreatedOn = DateTime.Now,
                            };
                            UnitOfWork.UserDisplay.Add(userdisplay);
                            UnitOfWork.Save();
                            newID = userdisplay.ID;

                            // Show Sucess Message In New View
                            ModelState.Clear();
                        }
                        scope.Complete();
                    }

                    Session["Message"] = SecurityResources.UserCreatedWithAddRoleNotification;
                    //redirect to search page with created id
                    return RedirectToAction("Index", "Users", new
                    {
                        UserType = model.UserType,
                        uid = newID
                    });

                }
                catch (TransactionAbortedException)
                {
                    this.Header.ShowError(SharedResources.UnexpectedError, true);
                }
                return RedirectToAction("Index", "Users", new
                {
                    UserType = model.UserType,
                    uid = newID
                });
            }
        }

        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "Update")]
        [HttpGet]
        public ActionResult Edit(Guid? id, int? type, int? success)
        {
            if (id == null)
                return RedirectToAction("Index");
            TempData["type"] = type;
            string successMessage = string.Empty;
            switch (success)
            {
                case (int)Common.Model.Enums.Enum.SaveStaus.Saved:
                    successMessage = SecurityResources.UserSavedSuccessMessage;
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.Updated:
                    successMessage = SecurityResources.UserSavedSuccessMessage;
                    break;
                default:
                    break;
            }
            ViewBag.SuccessMessage = successMessage;

            //get Type
            var usd = UnitOfWork.UserDisplay.GetById(id);
            if (usd.AspNetUsers != null)
            {
                var aspUser = usd.AspNetUsers;

                ViewBag.DisplayOnline = "";
                ViewBag.DisplayAD = "d-none";

                //var UserDisplay = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == id).FirstOrDefault();

                AccountViewModelEdit model = new AccountViewModelEdit();

                model.UserName = aspUser.UserName;
                model.Email = aspUser.Email;
                model.FullName = aspUser.FullName;
                model.IsActive = aspUser.IsActive;
                model.PhoneNumber = aspUser.PhoneNumber;
                model.IsActive = aspUser.IsActive;

                return View(model);
            }
            else
            {
                ViewBag.DisplayAD = "";
                ViewBag.DisplayOnline = "d-none";

                var UserDisplay = UnitOfWork.UserDisplay.GetById(id);

                AccountViewModelEdit model = new AccountViewModelEdit();
                AccountViewModelActiveDirectory ad = new AccountViewModelActiveDirectory();
                model.AccountViewModelActiveDirectory = ad;

                model.AccountViewModelActiveDirectory.UserName = UserDisplay.LoginName.Replace("coe\\", "").Trim();
                model.AccountViewModelActiveDirectory.FullName = UserDisplay.DisplayName;
                model.AccountViewModelActiveDirectory.IsActive = true;

                return View(model);
            }
        }

        // GET: Edit Center by Id
        //[ModuleAuthorize("Training", "Centers",ActionName ="EditCenter")]
        [HttpPost]
        public ActionResult Edit(AccountViewModelEdit model, Guid? id, int? type)
        {
            try
            {
                var userDisplay = UnitOfWork.UserDisplay.GetById(id);
                var aspID = userDisplay.AspNetUserID;

                // is online user
                if (aspID != null)
                {
                    var user = UsersFacade.FindById(aspID.Value);
                    if (user != null)
                    {
                        ViewBag.DisplayOnline = "";
                        ViewBag.DisplayAD = "d-none";

                        ModelState.Remove("AccountViewModelActiveDirectory.FullName");
                        ModelState.Remove("AccountViewModelActiveDirectory.UserName");
                        ModelState.Remove("Password");
                        ModelState.Remove("ConfirmPassword");
                        ModelState.Remove("NationalId");
                        if (!this.ModelState.IsValid)
                        {
                            return this.View(model);
                        }

                        user.FullName = model.FullName.Trim();
                        user.NationalId = user.NationalId != null ? user.NationalId : "0000000000";
                        user.UserName = model.UserName.Trim();
                        user.Email = model.Email.Trim();
                        user.PhoneNumber = model.PhoneNumber;
                        userDisplay.LoginName = model.UserName.Trim();
                        userDisplay.DisplayName = model.FullName.Trim();

                        var userdisplayByName = UnitOfWork.UserDisplay.GetByQuery(x => x.LoginName.ToLower() == model.UserName.ToLower().Trim() && x.ID != userDisplay.ID).FirstOrDefault();
                        if (userdisplayByName != null)
                        {
                            Header.ShowError(SecurityResources.UserAlreadyRegistred, true);
                            return View(model);
                        }
                        var updateState = UsersFacade.UpdateUser(user);

                        if (!updateState.IsValid)
                        {
                            foreach (var error in updateState.ErrorMessages)
                            {
                                ModelState.AddModelError("error_" + error, error);
                            }

                            return View(model);
                        }

                        // DbInterception.Remove(new TemporalTableCommandTreeInterceptor());
                        UnitOfWork.UserDisplay.Update(userDisplay);
                        UnitOfWork.Save();

                        TempData["SuccessMessage"] = SecurityResources.UserSavedSuccessMessage;
                        return RedirectToAction("Edit", new
                        {
                            type = TempData["type"],
                            success = (int)Common.Model.Enums.Enum.SaveStaus.Updated
                        });
                    }
                }
                else
                {
                    userDisplay.LoginName = "coe\\" + model.AccountViewModelActiveDirectory.UserName.Trim();
                    userDisplay.DisplayName = model.AccountViewModelActiveDirectory.FullName;
                    userDisplay.IsActive = true;

                    UnitOfWork.UserDisplay.Update(userDisplay);
                    UnitOfWork.Save();

                    TempData["SuccessMessage"] = SecurityResources.UserSavedSuccessMessage;
                    return RedirectToAction("Edit", new
                    {
                        type = TempData["type"],
                        success = (int)Common.Model.Enums.Enum.SaveStaus.Updated
                    });

                }
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }


        [ModuleAuthorize("Survey", "SurveyModule", ActionName = "UserRole")]
        public ActionResult UserRole(Guid? id, int? type)
        {
            if (id == null)
            {
                return RedirectToAction("users");
            }

            TempData["type"] = type;

            // Get All Roles

            var allowedRoles = UnitOfWork.AspNetRoles.GetAllowedRoleForUser(User.Identity.Name, Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));
            var data = UnitOfWork.AspNetRoles.GetByQuery(q => allowedRoles.Contains(q.Id)).ToList();

            //get user roles

            var userRole = UnitOfWork.UserDisplay.GetByQuery(a => a.ID == id).FirstOrDefault().AspNetRoles.ToList();
            //var userRole = UnitOfWork.UserDisplay.GetById(id).AspNetRoles.ToList();
            var currentUserRoleIds = userRole.Select(x => x.Id);

            foreach (var item in data)
            {
                foreach (var userId in currentUserRoleIds)
                {
                    if (item.Id == userId)
                    {
                        item.IsSelected = true;
                    }
                }
            }
            return View(data.OrderBy(o => o.Priority.Value).ToList());
        }


        [HttpPost]
        public ActionResult UserRole(Guid? id, List<AspNetRoles> model)
        {
            Guid uid = id.Value;
            string type = TempData.Peek("type").ToString();

            //get all selected Roles
            var selectedRoles = model.Where(x => x.IsSelected == true).ToList();

            if (selectedRoles == null || selectedRoles.Count == 0)
            {
                TempData["SuccessMessage"] = SecurityResources.OneRoleMustBeSelected;
                return RedirectToAction("UserRole", "Users", new
                {
                    @type = type
                });
            }



            var selectedUser = UnitOfWork.UserDisplay.GetByQuery(a => a.ID == uid).FirstOrDefault();





            //delete all user roles
            var userRole = UnitOfWork.UserDisplay.GetByQuery(a => a.ID == uid).FirstOrDefault().AspNetRoles.ToList();
            if (userRole.Count > 0)
            {
                foreach (var item in userRole)
                {
                    selectedUser.AspNetRoles.Remove(item);
                }
                //commit delete
                UnitOfWork.Save();
            }

            using (var ctx = new Common.DAL.COEEntities())
            {
                var user = ctx.UserDisplay.FirstOrDefault(x => x.ID == uid);

                foreach (var item in selectedRoles)
                {
                    var role = ctx.AspNetRoles.Find(item.Id);
                    role.CreatedBy = UserName;
                    role.UpdatedBy = UserName;
                    role.UpdatedOn = DateTime.Now;
                    role.UserDisplay.Add(user);
                }

                try
                {
                    ctx.SaveChanges();
                    TempData["SuccessMessage"] = SecurityResources.RoleSavedSuccessMessage;
                    return RedirectToAction("UserRole", "Users", new
                    {
                        @type = type
                    });
                }
                catch (Exception)
                {
                    TempData["SuccessMessage"] = SecurityResources.ErrorOccured;
                    return RedirectToAction("UserRole", "Users", new
                    {
                        @type = type
                    });
                }
            }

        }

        [HttpPost]
        public JsonResult CheckUserExist(string userName, string userId, int userType, string email, string controller, string action)
        {
            //Check if USer Exist
            UserDisplay user = new UserDisplay();
            if (userType == (int)COE.Common.Model.Enums.Enum.UserType.Online)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    user = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == new Guid(userId) && x.IsActive == true).FirstOrDefault();
                }

                if (user == null)
                {

                    Guid AspUser = new Guid(userId);
                    user = UnitOfWork.UserDisplay.Add(new UserDisplay

                    {
                        LoginName = userName,
                        DisplayName = userName,
                        ID = Guid.NewGuid(),
                        AspNetUserID = AspUser,
                        CreatedBy = userName,
                        UpdatedOn = DateTime.Now,
                        UpdatedBy = userName,
                        IsActive = true
                    });


                    UnitOfWork.Save();
                }
            }
            else
            {
                Guid AdUserID = new Guid(userId);
                user.ID = AdUserID;
            }
            if (user.ID != null)
            {
                TempData["uid"] = user.ID;
            }
            return Json(new
            {
                success = "Success",
                Result = Url.Action(action, controller, new
                {
                    id = user.ID,
                    type = userType
                }),
                ErrorMessage = string.Empty
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActiveDeActiveUser(bool stateParam, Guid? userId)
        {
            try
            {

                var userDisplay = UnitOfWork.UserDisplay.GetById(userId);


                //AD Users

                var aspUser = userDisplay.AspNetUsers;
                if (aspUser == null)
                {

                    var userdisplay = UnitOfWork.UserDisplay.GetById(userId);
                    userdisplay.IsActive = stateParam;
                    UnitOfWork.UserDisplay.Update(userdisplay);
                    UnitOfWork.Save();
                    return Json(new
                    {
                        success = true,
                        Result = "",
                        ResultMessage = "",
                        ErrorMessage = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }

                //Online Users
                else
                {
                    var onlineUser = UnitOfWork.AspNetUsers.GetById(aspUser.Id);
                    onlineUser.IsActive = stateParam;
                    onlineUser.UserDisplay.FirstOrDefault().IsActive = stateParam;
                    UnitOfWork.AspNetUsers.Update(onlineUser);
                    UnitOfWork.Save();

                    return Json(new
                    {
                        success = true,
                        Result = "",
                        ResultMessage = "",
                        ErrorMessage = string.Empty
                    }, JsonRequestBehavior.AllowGet);


                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Result = Common.Model.Enums.Enum.SaveStaus.ItemError,
                    ErrorMessage = SecurityResources.ErrorOccured
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(Guid? userId)
        {
            try
            {

                var userDisplay = UnitOfWork.UserDisplay.GetById(userId);

                if (UnitOfWork.Survey.GetByQuery(a => a.CreatedBy == userDisplay.LoginName).Any())
                {
                    return Json(new
                    {
                        success = false,
                        Result = Common.Model.Enums.Enum.SaveStaus.ItemError,
                        ErrorMessage = SurveysResources.SurveysForUser,
                        ResultMessage = "",
                    }, JsonRequestBehavior.AllowGet);
                }

                using (var ctx = new Common.DAL.COEEntities())
                {
                    ctx.DeleteUser(userId);
                    ctx.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        Result = "",
                        ResultMessage = "",
                        ErrorMessage = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Result = Common.Model.Enums.Enum.SaveStaus.ItemError,
                    ErrorMessage = SecurityResources.ErrorOccured
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}