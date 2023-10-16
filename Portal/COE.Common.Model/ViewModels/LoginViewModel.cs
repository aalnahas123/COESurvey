// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using System.ComponentModel.DataAnnotations;

    using Commons.Framework.Web.Mvc.DataAnnotations;

    using ExpressiveAnnotations.Attributes;

    using Localization;

    #endregion

    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the captcha.
        /// </summary>
        //[ValidateCaptcha(ErrorMessageResourceName = "InvalidCaptcha", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        //[RequiredIf("CaptchaRequired==true", ErrorMessageResourceName = "RequiredField", 
        //    ErrorMessageResourceType = typeof(SharedResources))]
        //[StringLength(6, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        //[DisableScripts]
        //[GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(SharedResources))]
        public string Captcha { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether captcha required.
        /// </summary>
        public bool CaptchaRequired { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the user name.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName", ResourceType = typeof(UsersMgmtResources))]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UsersMgmtResources))]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether remember me.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public ForgotPasswordViewModel ForgotPassword { get; set; }

    }
}