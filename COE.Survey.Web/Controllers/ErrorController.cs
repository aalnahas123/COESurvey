// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="SURE International Technology">
//   Copyright © 2016 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Survey.Web
{
    #region

    using BLL;
    using Common.Helper;
    using Common.Localization;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The error controller.
    /// </summary>
    public class ErrorController : BaseController<COEUoW>
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(string code)
        {
            SetCulture("en-US");

            string message;

            var isBackLinkToLogin = (code == "403" || code == "401");

            switch (code)
            {
                case "401":
                case "403":
                case "404":
                    message = SharedResources.ResourceManager.GetString($"Error{code}");
                    break;
                default:
                    message = SharedResources.UnexpectedError;
                    break;
            }

            return
                this.View(
                    new FullPageMessage
                        {
                            Message = message,
                            IsError = true,
                            BackLinkText =
                                isBackLinkToLogin ? UsersMgmtResources.Login : SharedResources.BackToMainPage,
                            BackLinkUrl = isBackLinkToLogin ? "/Account/Login/" : "/",
                            PageTitle = SharedResources.ErrorOccured,
                            Description = ""
                        });
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult UnAuthorized(string code)
        {
            SetCulture("en-US");
            return this.View();
        }
        
    }
}