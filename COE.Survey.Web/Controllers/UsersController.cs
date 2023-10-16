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

namespace COE.Survey.Web
{
    [Authorize]
    [ModuleAuthorize("Security", "User")]
    public class UsersController : BaseController<COEUoW>
    {

        //public ActionResult Index(AccountSearchViewModel model, int? success)
        //{
        //    var aspNetUsers = UnitOfWork.AspNetUsers.GetAll().Where(u => u.UserDisplay.Any());
        //    var users = aspNetUsers
        //    .ToList().Select(x => new AccountViewModel
        //    {
        //        NationalId = x.NationalId ?? SecurityResources.EmptyValue,
        //        Email = x.Email ?? SecurityResources.EmptyValue,
        //        FullName = x.FullName ?? SecurityResources.EmptyValue,
        //        UserName = x.UserName ?? SecurityResources.EmptyValue,
        //        PhoneNumber = x.PhoneNumber ?? SecurityResources.EmptyValue,
        //        Id = x.Id
        //    }).ToList();

        //    if (!string.IsNullOrEmpty(model.NationalID))
        //    {
        //        users = users.Where(x => x.NationalId.Contains(model.NationalID)).ToList();
        //    }
        //    if (!string.IsNullOrEmpty(model.UserName))
        //    {
        //        users = users.Where(x => x.FullName.ToLower().Contains(model.UserName.ToLower())).ToList();
        //    }

        //    if (model != null)
        //    {
        //        var UsersList = users.AsQueryable()
        //            .GetPaged(x => x.NationalId, false, model.PageNumber, AppSettings.DefaultPagerPageSize);

        //        model.Items = new StaticPagedList<AccountViewModel>(
        //                              UsersList.ToList(),
        //                              UsersList.PageNumber,
        //                              UsersList.PageSize,
        //                              UsersList.TotalItemCount);

        //        // if has request ajax we'll be load Partial View
        //        if (Request.IsAjaxRequest())
        //        {
        //            return PartialView("_Users", model);
        //        }

        //        ViewBag.success = success;
        //    }
        //    return View(model);
        //}

        // GET: Show view
        //[ModuleAuthorize("Training", "Centers",ActionName ="AddCenter")]

        [ModuleAuthorize("Security", "User", ActionName = "New")]
        [HttpGet]
        public ActionResult Add(AccountViewModel model, int? success, string userType)
        {
            ViewBag.DisplayOnline = "display:block";
            ViewBag.DisplayAD = "display:none";
            model.UserType = userType ?? ((int)COE.Common.Model.Enums.Enum.UserType.Online).ToString();

            if (model.UserType == ((int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString())
            {
                ViewBag.DisplayAD = "display:block";
                ViewBag.DisplayOnline = "display:none";
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
                    ViewBag.DisplayAD = "display:block";
                    ViewBag.DisplayOnline = "display:none";
                    break;
                case (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist:
                    successMessage = SecurityResources.UserAlreadyRegistred;
                    ViewBag.MessageType = BLL.Enum.MessageType.danger.ToString();
                    ViewBag.DisplayAD = "display:block";
                    ViewBag.DisplayOnline = "display:none";
                    break;
                default:
                    break;
            }
            ViewBag.SuccessMessage = successMessage;
            ModelState.Clear();
            GetColleges(model);
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
                ViewBag.DisplayAD = "display:block";
                ViewBag.DisplayOnline = "display:none";
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
                            return RedirectToAction("Add", new { success = (int)Common.Model.Enums.Enum.SaveStaus.AlreadyExist, userType = "1" });
                        }

                    }
                    else
                    {
                        return RedirectToAction("Add", new { success = (int)Common.Model.Enums.Enum.SaveStaus.NotExist, userType = "1" });
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Add", new { success = (int)Common.Model.Enums.Enum.SaveStaus.NotExist, userType = "1" });
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
                return RedirectToAction("Users", "Security", new { UserType = model.UserType, uid = newID });
            }
            else
            {
                ViewBag.DisplayOnline = "display:block";
                ViewBag.DisplayAD = "display:none";

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

                var selectedColleges = model.Providers?.Where(x => x.IsSelected).SelectMany(y => y.CollegeList.Where(z => z.IsSelected == true)).ToList();
                if (selectedColleges == null || selectedColleges.Count() <= 0)
                {
                    Header.ShowError(SecurityResources.SelectCollegeMsg);
                    return View(model);
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

                            //ADD SELECTED COLLEGES HERE
                            if (selectedColleges.Count() > 0)
                            {
                                List<UserCollege> obj = new List<UserCollege>();

                                //Delete All User Colleges
                                var userColleges = UnitOfWork.UserCollege.GetByQuery(x => x.UserDisplayID == userdisplay.ID).ToList();
                                UnitOfWork.UserCollege.Delete(userColleges);

                                //Save
                                UnitOfWork.Save();

                                foreach (var item in selectedColleges)
                                {
                                    UnitOfWork.UserCollege.Add(new UserCollege
                                    {
                                        CollegeID = item.ID,
                                        UserDisplayID = userdisplay.ID,
                                        CreatedBy = UserName,
                                        UpdatedBy = UserName,
                                        IsActive = true
                                    });
                                }
                                //Save
                                UnitOfWork.Save();
                            }

                            // Show Sucess Message In New View
                            ModelState.Clear();
                        }
                        scope.Complete();
                    }

                    Session["Message"] = SecurityResources.UserCreatedWithAddRoleNotification;
                    //redirect to search page with created id
                    return RedirectToAction("Users", "Security", new { UserType = model.UserType, uid = newID });

                }
                catch (TransactionAbortedException)
                {
                    this.Header.ShowError(SharedResources.UnexpectedError, true);
                }
                return RedirectToAction("Users", "Security", new { UserType = model.UserType, uid = newID });
            }
        }

        [ModuleAuthorize("Security", "User", ActionName = "Update")]
        [HttpGet]
        public ActionResult Edit(Guid? id, int? type, int? success)
        {
            if (id == null) return RedirectToAction("Index");
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
            var usd = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == id).FirstOrDefault();
            if (usd.AspNetUserID != null)
            {
                var aspUser = UnitOfWork.AspNetUsers.GetByQuery(x => x.Id == usd.AspNetUserID).FirstOrDefault();

                ViewBag.DisplayOnline = "display:block";
                ViewBag.DisplayAD = "display:none";

                var UserDisplay = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == id).FirstOrDefault();

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
                ViewBag.DisplayAD = "display:block";
                ViewBag.DisplayOnline = "display:none";

                var UserDisplay = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == id).FirstOrDefault();

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
                var userDisplay = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == id).FirstOrDefault();
                var aspID = userDisplay.AspNetUserID;

                // is online user
                if (aspID != null)
                {
                    var user = UsersFacade.FindById(aspID.Value);
                    if (user != null)
                    {
                        ViewBag.DisplayOnline = "display:block";
                        ViewBag.DisplayAD = "display:none";

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


                        return RedirectToAction("Edit", new { type = TempData["type"], success = (int)Common.Model.Enums.Enum.SaveStaus.Updated });
                    }
                }
                else
                {
                    userDisplay.LoginName = "coe\\" + model.AccountViewModelActiveDirectory.UserName.Trim();
                    userDisplay.DisplayName = model.AccountViewModelActiveDirectory.FullName;
                    userDisplay.IsActive = true;

                    UnitOfWork.UserDisplay.Update(userDisplay);
                    UnitOfWork.Save();
                    return RedirectToAction("Edit", new { type = TempData["type"], success = (int)Common.Model.Enums.Enum.SaveStaus.Updated });

                }
                return View(model);

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        private void GetColleges(AccountViewModel model)
        {
            var CurrentUserColleges = UnitOfWork.College.GetListByUserId(User.Identity.Name).Select(X => X.Value).ToList();

            //Get All Providers With Colleges
            model.Providers = UnitOfWork.Provider.GetAll().ToList();
        }
    }
}