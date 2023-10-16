// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="SURE International Technology">
//   Copyright © 2016 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Survey.Web.Controllers
{
    #region

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Commons.Framework.Extensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using UsersMgmt.Model;
    using UsersMgmt.ActiveDirectory;
    using System.Web.Security;
    using Common.Model.ViewModels;
    using Common.Localization;
    using Common.BLL;
    using Common.Helper;
    using System.Web.UI;
    using System.Text.RegularExpressions;
    using BLL;
    using Microsoft.Owin;

    #endregion


    /// <summary>
    ///     The account controller.
    /// </summary>
    public class AccountController : BaseController<COEUoW>
    {
        // Used for XSRF protection when adding external logins
        /// <summary>
        ///     The xsrf key.
        /// </summary>

        private const string XsrfKey = "XsrfId";
        private const string InvalidLoginMessageKey = "InvalidLoginMessage";

        // =========================
        // POST: /Account/LogOff
        /// <summary>
        ///     The log off.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            //return this.RedirectToAction("Login", "Account", new { area = string.Empty });
            return Json(new { Success = true, Result = string.Empty }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(AccountViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }
                bool _isValidNationalId = ValidNationalId(model.NationalId);
                int _isValidateSaudiID = ValidateSaudiID(model.NationalId); // return -1 if the nationalId is not correct, 1 for saudi nationalId OR 2 for non-saudis.

                if (!_isValidNationalId && _isValidateSaudiID == -1)
                {
                    // Show Failed Message In New View
                    this.Header.ShowError(UsersMgmtResources.NationalIDValidity);
                    return View(model);
                }
                var result =
                    UsersFacade.RegisterUser(
                        new ApplicationUser
                        {
                            FullName = model.FullName,
                            PhoneNumber = model.PhoneNumber,
                            UserName = model.NationalId,
                            NationalId = model.NationalId,
                            Email = model.Email,
                            EmailConfirmed = true,
                            Password = model.Password,
                            CountryId = model.CountryId,
                            DefaultLanguageId = model.DefaultLanguageId,
                            IsActive = true,
                        },
                        null);


                if (!result.IsValid)
                {
                    this.ModelState.Merge(result.ModelState);
                    // Show Failed Message In New View
                    //this.Header.ShowErrorWithLink(UsersMgmtResources.RegistrationFailed, true);
                    this.Header.ShowErrorWithLink(UsersMgmtResources.RegistrationFailedWithlinkRecover, Url.Action("DataRecover", "Account"), UsersMgmtResources.DataRecover);
                    return View(model);
                }
                else
                {
                    //// Show Sucess Message In New View
                    //ModelState.Clear();
                    //AccountViewModel newModel = new AccountViewModel();
                    //this.Header.ShowSuccess(UsersMgmtResources.RegistrationSuccess, true);
                    //return View(newModel);
                    this.TempData["success"] = UsersMgmtResources.RegistrationSuccess;
                    this.TempData["RegistrationSuccess"] = true;
                    this.TempData["error"] = null;
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                this.Header.ShowError(UsersMgmtResources.RegistrationFailed, true);
                return View(model);
            }
        }
        public ActionResult ConfirmEmail(Guid? userId, int? code)
        {
            if (userId.IsNullOrDefault<Guid>() || code.IsNullOrDefault<int>())
            {
                this.Header.ShowError(UsersMgmtResources.ConfirmEmailInvalidCode);
                return this.View();
            }

            var result = UsersFacade.ConfirmUserEmail(userId.Value, code.Value, false);

            if (!result.IsValid)
            {
                if (result.ErrorMessages.Contains(UsersMgmtResources.ConfirmEmailCodeExpired))
                {
                    this.Header.ShowErrorWithLink(UsersMgmtResources.CodeExpiredDate, Url.Action("ResendConfirmEmail", "Account"), UsersMgmtResources.UrlActivationTitle);
                    return this.View();
                }

                if (result.ErrorMessages.Contains(UsersMgmtResources.UserAlreadyActivated))
                {
                    this.Header.ShowErrorWithLink(UsersMgmtResources.UserAlreadyActivated, Url.Action("Login", "Account"), SharedResources.ClickHere);
                    return this.View();
                }

                this.Header.ShowErrorWithLink(result.ErrorMessages.FirstOrDefault(), Url.Action("ResendConfirmEmail", "Account"), UsersMgmtResources.UrlActivationTitle);
                return this.View();
            }

            return
                    this.ShowFullPageMessage(
                        new FullPageMessage
                        {
                            BackLinkText = UsersMgmtResources.Login,
                            BackLinkUrl = Url.Action("Login", "Account"),
                            Message = UsersMgmtResources.ConfirmEmailMsg,
                            PageTitle = UsersMgmtResources.RegisterNewUser
                        });
        }

        /// <summary>
        ///     The user activation.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [AllowAnonymous]
        public ActionResult ResendConfirmEmail()
        {
            return this.View(new ResendConfirmEmailViewModel());
        }

        /// <summary>
        /// The user activation.
        /// </summary>
        /// <param name="userActivation">
        /// The user activation.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ResendConfirmEmail(ResendConfirmEmailViewModel userActivation)
        {
            if (!this.ModelState.IsValid)
            {
                this.Header.ShowError(UsersMgmtResources.EmailValidator);
                return this.View(userActivation);
            }

            var user = this.UserManager.GetByEmail(userActivation.Email);
            if (user == null)
            {
                this.Header.ShowError(UsersMgmtResources.EmailValidator);
                return this.View(userActivation);
            }

            this.UserManager.SendValidateUserEmail(user);
            this.Header.ShowSuccess(UsersMgmtResources.SendedActivationLink);

            return this.View(userActivation);
        }

        // GET: /Account/Login
        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
        public ActionResult Login(string returnUrl)
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            FormsAuthentication.SignOut();


            if (this.TempData["success"] != null)
                this.Header.ShowSuccess(this.TempData["success"].ToString(), true);

            if (this.TempData["error"] != null)
                this.Header.ShowError(this.TempData["error"].ToString(), true);

            var user = UsersFacade.CurrentUser;

            SetCulture(_cultureAr);

            if (user != null)
            {
                if (string.IsNullOrEmpty(returnUrl))
                {
                    //return this.RedirectToAction("Index", "Home", new { returnUrl = string.Empty, area = string.Empty });
                    this.ViewBag.ReturnUrl = string.Empty;
                    return this.View();
                }
                else
                {
                    this.ViewBag.ReturnUrl = returnUrl;
                    return this.View();
                }

            }
            else
            {
                var model = new LoginViewModel { CaptchaRequired = this.UserManager.ShouldDisplayCaptcha };
                return this.View(model);
            }
        }


        // POST: /Account/Login
        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]

        #region Staging Login
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                this.ModelState.Remove("Captcha");

                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }
                SignInStatus result = SignInStatus.Failure;

                model.CaptchaRequired = this.UserManager.ShouldDisplayCaptcha;

                ApplicationUser user = this.UserManager.GetByName(model.UserName);

                if (user != null)
                {
                    UsersFacade.IsActiveDirectoryUser = false;
                    model.Email = user.Email;
                    #region Check if user is activated 
                    if (!user.IsActive)
                    {
                        // Show error not activated user
                        this.UserManager.UserAccessFailed(user.Id);
                        this.Header.ShowError(UsersMgmtResources.UserNotActivated, true);
                        return this.View(model);
                    }

                    #endregion

                    #region Check Login Status
                    // contact officers of suspended organization will be not be allowed to login 
                    // by checking their organization status

                    result = this.SignInManager.PasswordSignIn(model.UserName, model.Password, model.RememberMe, shouldLockout: false);

                    #endregion
                }

                #region Check User active directory
                if (user == null)
                {
                    UsersFacade.IsActiveDirectoryUser = true;
                    var check = AdHelper.ValidateCredentials(model.UserName, model.Password);

                    if (check)
                    {
                        //var userP = AdHelper.GetUser(model.UserName);

                        //ApplicationUser us = new ApplicationUser(userP.Surname);
                        //us.IsActive = AdHelper.IsUserExpired(userP.Surname);
                        model.UserName = AdHelper.GetPrincipalContext().Name + "\\" + model.UserName;
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        result = SignInStatus.Success;
                    }
                }
                #endregion

                switch (result)
                {
                    case SignInStatus.LockedOut:

                        return
                            this.ShowFullPageMessage(
                                new FullPageMessage
                                {
                                    BackLinkText = UsersMgmtResources.Login,
                                    BackLinkUrl = Url.Action("Login", "Account"),
                                    Message = UsersMgmtResources.UserIsLocked,
                                    PageTitle = SharedResources.Sorry,
                                    IsError = true
                                });

                    case SignInStatus.Success:

                        bool hasUserDisplay = UnitOfWork.UserDisplay.HasUserDisplay(model.UserName);

                        if (!hasUserDisplay)
                        {
                            #region Set Culture ar-SA if user is student
                            SetCulture(_cultureAr);
                            #endregion
                        }
                        else
                        {
                            #region Set Culture en-US 
                            SetCulture(_cultureEn);
                            #endregion
                        }

                        if (!string.IsNullOrEmpty(returnUrl) && this.Url.IsLocalUrl(returnUrl))
                        {
                            return this.RedirectToLocal(returnUrl);
                        }

                        return this.RedirectToAction("Index", "Surveys", new { area = "" });

                    default:
                        //this.UserManager.UserAccessFailed(user.Id);
                        this.ModelState.AddModelError(string.Empty, UsersMgmtResources.InvalidLogin);
                        this.Header.ShowError(UsersMgmtResources.InvalidLogin, true);
                        return this.View(model);

                }

                #region Check if user email is confirmed
                /* if (!user.EmailConfirmed)
                     {
                         this.UserManager.UserAccessFailed(user.Id);

                         // this.ModelState.AddModelError(string.Empty, Messages.EmailNotConfirmed);
                         this.Header.ShowWarningWithLink(
                             UsersMgmtResources.EmailNotConfirmed,
                             "/Account/ResendConfirmEmail/",
                             UsersMgmtResources.UrlActivationTitle);
                         return this.View(model);
                     }*/
                #endregion

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                this.Header.ShowError(UsersMgmtResources.InvalidLogin, true);
                return this.View(model);
            }

        }
        #endregion

        #region Production Login

        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    SignInStatus result = SignInStatus.Failure;
        //    try
        //    {
        //        this.ModelState.Remove("Captcha");

        //        if (!this.ModelState.IsValid)
        //        {
        //            return this.View(model);
        //        }

        //        // model.CaptchaRequired = this.UserManager.ShouldDisplayCaptcha;

        //        // Check if loged in user activate his account if yes login else redirect to action activation with verfication .
        //        //ActivationCode _activationCode = UsersFacade.GetCurrentUserActivation(user.Id, user.UserName);
        //        //if (activationCode != null)
        //        //{
        //        //    ViewBag.UserActivationCode = _activationCode.Code;
        //        //}

        //        ApplicationUser user = this.UserManager.FindByName(model.UserName.ToLower().Trim());

        //        if (user != null)
        //        {
        //            UsersFacade.IsActiveDirectoryUser = false;
        //            model.Email = user.Email;

        //            #region Check if user is activated 

        //            if (!user.IsActive)
        //            {
        //                // Show error not activated user
        //                this.UserManager.UserAccessFailed(user.Id);
        //                //this.Header.ShowError(UsersMgmtResources.UserNotActivated, true);
        //                TempData[InvalidLoginMessageKey] = UsersMgmtResources.UserNotActivated;
        //                return this.View(model);
        //            }

        //            #endregion

        //            #region Check Login Status

        //            // contact officers of suspended organization will be not be allowed to login 
        //            // by checking their organization status

        //            result = this.SignInManager.PasswordSignIn(model.UserName, model.Password, model.RememberMe, shouldLockout: false);

        //            #endregion
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = SignInStatus.Failure;
        //        Logger.Error(ex);
        //    }

        //    switch (result)
        //    {
        //        case SignInStatus.LockedOut:

        //            return
        //                this.ShowFullPageMessage(
        //                    new FullPageMessage
        //                    {
        //                        BackLinkText = UsersMgmtResources.Login,
        //                        BackLinkUrl = Url.Action("Login", "Account"),
        //                        Message = UsersMgmtResources.UserIsLocked,
        //                        PageTitle = SharedResources.Sorry,
        //                        IsError = true
        //                    });

        //        case SignInStatus.Success:

        //            // Set Culture ar-SA if user is student
        //            bool isStudent = !UnitOfWork.UserDisplay.HasUserDisplay(model.UserName);
        //            if (!isStudent)
        //                SetCulture(_cultureEn);
        //            else
        //                SetCulture(_cultureAr);

        //            FormsAuthentication.SetAuthCookie(model.UserName.ToLower().Trim(), false);

        //            if (!string.IsNullOrEmpty(returnUrl) && this.Url.IsLocalUrl(returnUrl))
        //            {
        //                return this.RedirectToLocal(returnUrl);
        //            }

        //            //return Redirect(Url.Action("NewApplication", "Applicants"));

        //            if (isStudent)
        //                return Redirect(Url.Action("MyProfile", "Applicants"));
        //            else
        //                return Redirect(Url.Action("CollegeDashboard", "Enrollments")); // Enrollments/CollegeDashboard

        //        //return Redirect("/Enrollment/Applicants/MyProfile");

        //        default:
        //            //this.UserManager.UserAccessFailed(user.Id);
        //            this.ModelState.AddModelError(string.Empty, UsersMgmtResources.InvalidLogin);
        //            //this.Header.ShowError(UsersMgmtResources.InvalidLogin, true);
        //            TempData[InvalidLoginMessageKey] = UsersMgmtResources.InvalidLogin;
        //            return this.View(model);

        //    }

        //    #region Check if user email is confirmed

        //    /* if (!user.EmailConfirmed)
        //         {
        //             this.UserManager.UserAccessFailed(user.Id);

        //             // this.ModelState.AddModelError(string.Empty, Messages.EmailNotConfirmed);
        //             this.Header.ShowWarningWithLink(
        //                 UsersMgmtResources.EmailNotConfirmed,
        //                 "/Account/ResendConfirmEmail/",
        //                 UsersMgmtResources.UrlActivationTitle);
        //             return this.View(model);
        //         }*/

        //    #endregion

        //}

        #endregion

        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Activate(string code)
        {
            return View();
        }

        // GET: /Account/ForgotPassword
        /// <summary>
        ///     The forgot password.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return this.View(new ForgotPasswordViewModel());
        }

        // POST: /Account/ForgotPassword
        /// <summary>
        /// The forgot password.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="System.Threading.Tasks.Task"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            // Check if action taken by not student role
            if (model.RecaptchaResponse == "IsNotValid")
                ModelState.Remove("RecaptchaResponse");
            ModelState.Remove("PhoneNumber");

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = UnitOfWork.AspNetUsers.GetByQuery(x => x.NationalId == model.NationalId).FirstOrDefault();

            if (user == null)
            {
                ModelState.Clear();
                this.Header.ShowError(UsersMgmtResources.UserHasNotProfile, true);
                return this.View(new ForgotPasswordViewModel());
            }

            // Get Student by email .

            var result = this.UserManager.SendForgotPasswordEmail(user.Id, BLL.AppSettings.ApplicationUrl);

            if (!result.IsValid)
            {
                this.ModelState.Merge(result.ModelState);
                this.Header.ShowError(result.ErrorMessages.FirstOrDefault());
                return this.View();
            }

            this.Header.ShowSuccessWithLink(string.Format(UsersMgmtResources.ForgetPasswordConfirmMsg, user.PhoneNumber.Substring(user.PhoneNumber.Length - 3, 3))
                ,
                Url.Action("Login", "Account"),
                UsersMgmtResources.Login);

            return this.View();
        }

        // GET: /Account/ResetPassword
        /// <summary>
        /// The reset password.
        /// </summary>
        /// <param name="userId">
        /// The user Id.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        public ActionResult ResetPassword(Guid? userId, int? code)
        {
            if (!code.HasValue || !userId.HasValue)
            {
                this.Header.ShowError(UsersMgmtResources.ResetPasswordInvalidCode);
                return this.View();
            }

            var validateResult = this.UserManager.ValidateCode(userId.Value, code.Value);
            if (!validateResult.IsValid)
            {
                this.ModelState.Merge(validateResult.ModelState);
                this.Header.ShowError(validateResult.ErrorMessages.FirstOrDefault());
                return this.View();
            }

            return this.View(new ResetPasswordViewModel { UserId = userId.Value });
        }

        // POST: /Account/ResetPassword
        /// <summary>
        /// The reset password.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="System.Threading.Tasks.Task"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.UserManager.ResetPassword(model.UserId.Value, model.Code.Value, model.ConfirmPassword);
            if (!result.IsValid)
            {
                this.Header.ShowError(result.ErrorMessages.FirstOrDefault());
            }

            this.TempData["success"] = UsersMgmtResources.ResetPasswordSuccessMsg;
            this.TempData["error"] = null;
            return RedirectToAction("Login", "Account");

            #region Old Message
            //return
            //    this.ShowFullPageMessage(
            //        new FullPageMessage
            //        {
            //            BackLinkText = UsersMgmtResources.Login,
            //            BackLinkUrl = "/Account/Login/",
            //            Message = UsersMgmtResources.ResetPasswordConfirmMsg,
            //            PageTitle = UsersMgmtResources.ResetPassword
            //        }); 
            #endregion
        }

        public ActionResult Details()
        {
            var user = UsersFacade.CurrentUser;

            if (user != null)
                return
                    this.View(
                        new AccountViewModel()
                        {
                            FullName = user.FullName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                        });
            this.Header.ShowItemNotFoundError();
            return this.View();
        }

        public ActionResult Edit()
        {
            var user = UsersFacade.CurrentUser;

            if (user != null)
                return
                    this.View(
                        new AccountViewModel()
                        {
                            Id = user.Id,
                            FullName = user.FullName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,

                        });
            this.Header.ShowItemNotFoundError();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountViewModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.Id.IsNullOrDefault<Guid>())
            {
                this.Header.ShowInvalidParametersError();
                return this.View(model);
            }

            var user = UsersFacade.CurrentUser;

            if (user == null)
            {
                this.Header.ShowItemNotFoundError();
                return this.View(model);
            }

            user.Email = model.Email;
            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            user.DefaultLanguageId = model.DefaultLanguageId;
            user.CountryId = model.CountryId;


            var updateResult = UsersFacade.UpdateUser(user);
            if (!updateResult.IsValid)
            {
                this.ModelState.Merge(updateResult.ModelState);
                this.Header.ShowError(updateResult.ErrorMessages.FirstOrDefault());
                return this.View(model);
            }

            this.Header.ShowSuccess(SharedResources.SavedSuccessfully);

            return this.View(model);
        }

        public ActionResult Terms()
        {
            #region Set Culture ar-SA 
            SetCulture(_cultureAr);
            #endregion

            return this.View();
        }

        public ActionResult Conditions()
        {
            #region Set Culture ar-SA 
            SetCulture(_cultureAr);
            #endregion

            return this.View();
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }


        //GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                //case SignInStatus.LockedOut:
                //    return View("Lockout");
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                //case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return RedirectToAction("Details");
            }
        }


        // GET: /Account/ForgotPassword
        /// <summary>
        ///     The forgot password.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [AllowAnonymous]
        public ActionResult DataRecover()
        {
            return this.View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DataRecover(ForgotPasswordViewModel model)
        {
            // Check if action taken by not student role
            if (model.RecaptchaResponse == "IsNotValid")
                ModelState.Remove("RecaptchaResponse");

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = UnitOfWork.AspNetUsers.GetByQuery(x => x.NationalId == model.NationalId).FirstOrDefault();

            if (user == null)
            {
                ModelState.Clear();
                this.Header.ShowError(UsersMgmtResources.UserHasNotProfile, true);
                return this.View(new ForgotPasswordViewModel());
            }

            var result = this.UserManager.SendDataRecoverNotification(user.Id, model.PhoneNumber);

            if (!result.IsValid)
            {
                this.ModelState.Merge(result.ModelState);
                this.Header.ShowError(result.ErrorMessages.FirstOrDefault());
                return this.View();
            }

            this.Header.ShowSuccessWithLink(string.Format(UsersMgmtResources.DataRecoverConfirmMsg, model.PhoneNumber.Substring(model.PhoneNumber.Length - 3, 3))
                ,
                Url.Action("Login", "Account"),
                UsersMgmtResources.Login);

            return this.View();
        }

        public ActionResult EditProfile(Guid? userId, int? code)
        {
            if (!code.HasValue || !userId.HasValue)
            {
                this.Header.ShowError(UsersMgmtResources.ResetPasswordInvalidCode);
                return this.View();
            }

            var validateResult = this.UserManager.ValidateCode(userId.Value, code.Value);

            if (!validateResult.IsValid)
            {
                this.ModelState.Merge(validateResult.ModelState);
                this.Header.ShowError(validateResult.ErrorMessages.FirstOrDefault());
                return this.View();
            }

            var user = this.UserManager.FindById(userId.Value);

            return this.View(new AccountViewModel
            {
                Id = userId.Value,
                NationalId = (user != null) ? user.NationalId : string.Empty
            });
        }

        [HttpPost]
        public ActionResult EditProfile(AccountViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                    //return RedirectToAction("EditProfile", new { userId = model.Id, code = model.Code.Value, mode = "reset" });
                }

                var user = this.UserManager.FindById(model.Id);

                if (user != null)
                {
                    user.FullName = model.FullName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.UserName = model.NationalId;
                    user.NationalId = model.NationalId;
                    user.Email = model.Email;
                    user.EmailConfirmed = true;
                    user.Password = model.Password;
                    user.CountryId = model.CountryId;
                    user.DefaultLanguageId = model.DefaultLanguageId;
                    user.IsActive = true;
                    user.UpdatedBy = model.UserName;
                    user.UpdatedOn = DateTime.Now;
                }

                var result = this.UserManager.ResetUserInfo(user, model.Code.Value);

                if (!result.IsValid)
                {
                    this.ModelState.Merge(result.ModelState);
                    this.Header.ShowError(UsersMgmtResources.RegistrationFailed, true);
                    return View(model);
                }
                else
                {
                    this.TempData["success"] = UsersMgmtResources.RegistrationSuccess;
                    this.TempData["error"] = null;
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                this.Header.ShowError(UsersMgmtResources.RegistrationFailed, true);
                return View(model);
            }
        }

        ////
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        ////
        //// GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}


        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckExistingEmail(string Email)
        {
            try
            {
                return Json(!IsEmailExists(Email));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckExistingNationalID(string NationalId)
        {
            try
            {
                return Json(!IsUserNameExists(NationalId));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckExistingPhoneNumber(string PhoneNumber)
        {
            try
            {
                return Json(!IsPhoneNumberExists(PhoneNumber));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckNationalIdValidity(string NationalId)
        {
            try
            {
                return Json(!IsValidNationalId(NationalId));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        private bool IsEmailExists(string email) => UserManager.GetByEmail(email) != null;
        private bool IsUserNameExists(string userName) => UserManager.GetByName(userName) != null;
        private bool IsPhoneNumberExists(string phoneNumber) => UserManager.FindByPhoneNumber(phoneNumber) != null;
        private bool IsValidNationalId(string nationalId) => ValidNationalId(nationalId);
        private bool IsValidSaudiID(string nationalId) => ValidateSaudiID(nationalId) == 1;

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                //context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }


        ///// <summary>
        ///// The login.
        ///// </summary>
        ///// <param name="returnUrl">
        ///// The return url.
        ///// </param>
        ///// <returns>
        ///// The <see cref="ActionResult"/>.
        ///// </returns>
        //[AllowAnonymous]
        //[ActionName("Login")]
        //public ActionResult LoginGet(LoginViewModel model)
        //{
        //    //var user = UsersFacade.CurrentUserProfile();
        //    //if (user != null)
        //    //{
        //    //    if (!string.IsNullOrEmpty(model.ReturnUrl) && this.Url.IsLocalUrl(model.ReturnUrl))
        //    //    {
        //    //        return this.RedirectToLocal(model.ReturnUrl);
        //    //    }

        //    //    return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        //    //}

        //    //if (this.Session["AccessFailedCount"] != null)
        //    //{
        //    //    model.AccessFailedCount = (int)this.Session["AccessFailedCount"];
        //    //}

        //    //model.CaptchaRequired = model.AccessFailedCount >= AppSettings.MaxLoginAttemptsBeforeCaptcha;
        //    //this.ModelState.Clear();
        //    return this.View(model);
        //}

        ///// <summary>
        ///// The login.
        ///// </summary>
        ///// <param name="model">
        ///// The model.
        ///// </param>
        ///// <param name="returnUrl">
        ///// The return url.
        ///// </param>
        ///// <returns>
        ///// The <see cref="ActionResult"/>.
        ///// </returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //[SubmitButtonSelector(Name = "Login")]
        //public ActionResult Login(LoginViewModel model)
        //{
        //    //if (this.Session["AccessFailedCount"] != null)
        //    //{
        //    //    model.AccessFailedCount = (int)this.Session["AccessFailedCount"];
        //    //}

        //    //model.CaptchaRequired = model.AccessFailedCount >= AppSettings.MaxLoginAttemptsBeforeCaptcha;

        //    //if (!this.ModelState.IsValid)
        //    //{
        //    //    return this.View(model);
        //    //}

        //    //// Check if username is exsit and valid
        //    //if (!AdHelper.IsUserExisiting(model.UserName))
        //    //{
        //    //    this.Header.ShowError(Messages.InvalidLogin, true);
        //    //    this.Session["AccessFailedCount"] = ++model.AccessFailedCount;
        //    //    return this.View(model);
        //    //}

        //    //// Check if username Active
        //    //if (!AdHelper.IsAccountEnabled(model.UserName))
        //    //{
        //    //    this.Header.ShowError(UserManagementResources.UserNotActivated, true);
        //    //    this.Session["AccessFailedCount"] = ++model.AccessFailedCount;
        //    //    return this.View(model);
        //    //}
        //    //// Check if username is Exist at Database
        //    //if (!this.UnitOfWork.UserProfiles.IsUserNameExist(model.UserName))
        //    //{
        //    //    this.Header.ShowError(Messages.InvalidLogin, true);
        //    //    this.Session["AccessFailedCount"] = ++model.AccessFailedCount;
        //    //    return this.View(model);
        //    //}

        //    //// Check if username is active account
        //    //if (!AdHelper.ValidateCredentials(model.UserName, model.Password))
        //    //{
        //    //    this.Header.ShowError(Messages.InvalidLogin, true);
        //    //    this.Session["AccessFailedCount"] = ++model.AccessFailedCount;
        //    //    return this.View(model);
        //    //}

        //    //var activationCode = this.UnitOfWork.ActivationCodes.DbSet.Where(a => a.UserName == model.UserName).OrderBy(a => a.SentDateTime).FirstOrDefault();
        //    //if (activationCode != null)
        //    //{
        //    //    model.SendCodeAttemptCount = activationCode.AttemptCount;
        //    //}

        //    //if (model.SendCodeAttemptCount >= 5)
        //    //{
        //    //    UsersFacade.SendLoginUnlockCode(model.UserName);
        //    //    return
        //    //        this.ShowFullPageMessage(
        //    //            new FullPageMessage
        //    //            {
        //    //                BackLinkText = UserManagementResources.Login,
        //    //                BackLinkUrl = "/Account/Login/",
        //    //                PageTitle = Messages.ErrorOccured,
        //    //                Message = Messages.SendCodeMax,
        //    //                IsError = true
        //    //            });
        //    //}


        //    //UsersFacade.SendLoginVerficationCode(model.UserName);

        //    //this.Session["UserName"] = model.UserName;
        //    //this.Session["AttemptCount"] = model.SendCodeAttemptCount;
        //    //model.IsSendCodeView = true;
        //    return this.View(model);

        //}


        public bool ValidNationalId(string nationalId)
        {
            int[] ids = Array.ConvertAll(nationalId.ToCharArray(), c => (int)Char.GetNumericValue(c));
            int[] calcIds = new int[9];
            int calcSumation = 0;
            int roundDecimal = 0;
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 1:
                        calcIds[0] = calcId(ids[0]);
                        break;
                    case 2://
                        calcIds[1] = ids[1];
                        break;
                    case 3:
                        calcIds[2] = calcId(ids[2]);
                        break;
                    case 4://
                        calcIds[3] = ids[3];
                        break;
                    case 5:
                        calcIds[4] = calcId(ids[4]);
                        break;
                    case 6://
                        calcIds[5] = ids[5];
                        break;
                    case 7:
                        calcIds[6] = calcId(ids[6]);
                        break;
                    case 8://
                        calcIds[7] = ids[7];
                        break;
                    case 9:
                        calcIds[8] = calcId(ids[8]);
                        break;
                    default:
                        break;
                }
            }

            calcSumation = calcIds.Sum();
            roundDecimal = calcSumation;
            //if (calcSumation.ToString().Substring(1, 1) != "0")
            //    roundDecimal = Convert.ToInt32(calcSumation.ToString().Substring(0, 1) + "0") + 10;

            try
            {
                if (calcSumation.ToString().Substring(1, 1) != "0")// This throws ArgumentOutOfRangeException.
                    roundDecimal = Convert.ToInt32(calcSumation.ToString().Substring(0, 1) + "0") + 10;
            }
            catch (ArgumentOutOfRangeException e)
            {
                roundDecimal = Convert.ToInt32(calcSumation.ToString().Substring(0, 1) + "0") + 10;
            }

            return (roundDecimal - calcSumation) == ids[9];
        }

        public int ValidateSaudiID(string nationalId)
        {
            nationalId = nationalId.Trim();
            if (!Regex.IsMatch(nationalId, @"[0-9]+"))
            {
                return -1;
            }
            if (nationalId.Length != 10)
            {
                return -1;
            }
            int type = (int)(nationalId[0] - '0');
            if (type != 2 && type != 1)
            {
                return -1;
            }
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    string ZFOdd = ((int)(nationalId[i] - '0') * 2).ToString().PadLeft(2, '0');
                    sum += (int)(ZFOdd[0] - '0') + (int)(ZFOdd[1] - '0');
                }
                else
                {
                    sum += (int)(nationalId[i] - '0');
                }
            }

            return (sum % 10 != 0) ? -1 : type;
            // return -1 if the nationalId is not correct, 1 for saudi nationalId OR 2 for non-saudis.

        }

        private int calcId(int id)
        {
            int calc = 0;
            if (id * 2 > 9)
            {
                calc = ((id * 2) - 9);
            }
            else
            {
                calc = (id * 2);
            }

            return calc;
        }


    }
}