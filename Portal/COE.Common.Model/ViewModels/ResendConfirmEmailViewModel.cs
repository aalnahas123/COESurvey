// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResendConfirmEmailViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using System.ComponentModel.DataAnnotations;

    using Commons.Framework.Web.Mvc.DataAnnotations;

    using Localization;

    #endregion

    /// <summary>
    /// The resend confirm email view model.
    /// </summary>
    public class ResendConfirmEmailViewModel 
    {
        /// <summary>
        /// Gets or sets the captcha.
        /// </summary>
        [ValidateCaptcha(ErrorMessageResourceName = "InvalidCaptcha", ErrorMessageResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(6, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [DisableScripts]
        public string Captcha { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string Email { get; set; }
    }
}