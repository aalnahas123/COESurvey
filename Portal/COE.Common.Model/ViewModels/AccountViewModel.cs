// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using System;
    using System.ComponentModel.DataAnnotations;


    using Commons.Framework.Web.Mvc.DataAnnotations;
    using Commons.Framework.Web.Mvc.Helpers;

    using Localization;
    using Localization.Security;

    #endregion

    /// <summary>
    ///     The account view model.
    /// </summary>
    public partial class AccountViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        //[System.Web.Mvc.Remote("CheckExistingEmail", "Account", HttpMethod = "POST", ErrorMessageResourceName = "ExistingEmail", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "EmailConfirm", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Email", ErrorMessageResourceName = "EmailConfirmNotMatchValidator",
        ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string EmailConfirm { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UsersMgmtResources))]
        [RegularExpression(@"^.{6,25}$",
        ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordNotMatchValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string ConfirmPassword { get; set; }


        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FullName", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [DisableScripts]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the is active.
        /// </summary>
        [Display(Name = "ActiveStatus", ResourceType = typeof(SharedResources))]
        public bool IsActive { get; set; }


        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        //[System.Web.Mvc.Remote("CheckExistingPhoneNumber", "Account", HttpMethod = "POST", ErrorMessageResourceName = "ExistingPhoneNumber", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        // Allow only saudi mobile numbers
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiPhoneNumber")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Contry", ResourceType = typeof(UsersMgmtResources))]
        public int CountryId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DefaultLanguage", ResourceType = typeof(UsersMgmtResources))]
        public int DefaultLanguageId { get; set; }

        //[MustBeTrue(ErrorMessageResourceName = "MustAcceptAgreement", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "TermsAgreement", ResourceType = typeof(UsersMgmtResources))]
        public bool IsTermsAccepted { get; set; }

        public Guid Id { get; set; }

        // New
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(UsersMgmtResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        //[RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        [RegularExpression(@"^[12]\d{9}$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiNationalId")]
        //[System.Web.Mvc.Remote("CheckExistingNationalID", "Account", HttpMethod = "POST", ErrorMessageResourceName = "ExistsingNationalID", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        //[System.Web.Mvc.Remote("CheckNationalIdValidity", "Account", HttpMethod = "POST", ErrorMessageResourceName = "NationalIDValidity", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        //[ValidateNationalID(ErrorMessageResourceType = typeof(UsersMgmtResources), ErrorMessageResourceName = "InvalidNationalID")]
        public string NationalId { get; set; }

        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(SharedResources))]
        public string RecaptchaResponse { get; set; }

        public AccountViewModelActiveDirectory AccountViewModelActiveDirectory { get; set; }

        public int? Code { get; set; }


    }

    public partial class AccountViewModelActiveDirectory
    {
        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DisplayName", ResourceType = typeof(SecurityResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [DisableScripts]
        public string FullName { get; set; }

        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the is active.
        /// </summary>
        [Display(Name = "ActiveStatus", ResourceType = typeof(SharedResources))]
        public bool IsActive { get; set; }

    }

    public partial class AccountViewModelEdit
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }

 
         /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FullName", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [DisableScripts]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the is active.
        /// </summary>
        [Display(Name = "ActiveStatus", ResourceType = typeof(SharedResources))]
        public bool IsActive { get; set; }


        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Contry", ResourceType = typeof(UsersMgmtResources))]
        public int CountryId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DefaultLanguage", ResourceType = typeof(UsersMgmtResources))]
        public int DefaultLanguageId { get; set; }

        //[MustBeTrue(ErrorMessageResourceName = "MustAcceptAgreement", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "TermsAgreement", ResourceType = typeof(UsersMgmtResources))]
        public bool IsTermsAccepted { get; set; }

        public Guid Id { get; set; }

        // New
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(SecurityResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        public string NationalId { get; set; }


        public AccountViewModelActiveDirectory AccountViewModelActiveDirectory { get; set; }

    }

    public partial class AccountViewModelUserAdmin
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Programs", ResourceType = typeof(DCSResources))]
        public int[] ProgramsIds { get; set; }
        public Guid Id { get; set; }

        public int? CityId { get; set; }

        public int? CenterId { get; set; }

        public string[] CoursesIds { get; set; }

        public string[] ProvidersIds { get; set; }
        public string[] CentersIds { get; set; }

        public int? ProviderId { get; set; }

        public int? NationalityId { get; set; }

        public bool? IsChecked { get; set; }

        public string ClassName { get; set; }

        public string GenderValue { get; set; }

        public bool IsSubstitute { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UserName", ResourceType = typeof(DCSResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UsersMgmtResources))]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,25})",
        [RegularExpression(@"^[a-zA-Z0-9?=.*[@#$%z]{6,}$",
        ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordNotMatchValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        [Display(Name = "FullName", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the full name in English.
        /// </summary>
        //[EnglishTextOnly, Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FullNameEn", ResourceType = typeof(DCSResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string FullNameEn { get; set; }

        /// <summary>
        ///     Gets or sets the is active.
        /// </summary>
        [Display(Name = "Actived", ResourceType = typeof(DCSResources))]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        //[ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        //ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DefaultLanguage", ResourceType = typeof(UsersMgmtResources))]
        public int DefaultLanguageId { get; set; }


       


        [DataType(DataType.Text)]
        [Display(Name = "Gender", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int Gender { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "SpecializationID", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int Specialization { get; set; }

       
        [Display(Name = "UserRole", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public Guid? role { get; set; }

        [Display(Name = "JobRole", ResourceType = typeof(DCSResources))]
        public Guid? JobRole { get; set; }


        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }

}