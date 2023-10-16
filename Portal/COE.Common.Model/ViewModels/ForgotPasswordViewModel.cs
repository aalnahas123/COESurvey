// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using System.ComponentModel.DataAnnotations;


    using Commons.Framework.Web.Mvc.DataAnnotations;
    using Commons.Framework.Web.Mvc.Helpers;

    using Localization;
    using Localization.Security;
    using System;

    #endregion

    /// <summary>
    /// The forgot password view model.
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }

        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(SecurityResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        public string NationalId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "BirthDate", ResourceType = typeof(AppResources))]
        //public string BirthDate { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BirthDate", ResourceType = typeof(AppResources))]
        public DateTime BirthDate { get; set; }


        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(SharedResources))]
        public string RecaptchaResponse { get; set; }

        public int? EnrollmentId { get; set; }

        public string UserName { get; set; }

    }
}