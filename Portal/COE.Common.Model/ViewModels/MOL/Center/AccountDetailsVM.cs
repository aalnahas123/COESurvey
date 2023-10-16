using COE.Common.Localization;
using COE.Common.Localization.Security;
using Commons.Framework.Resources;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public class AccountDetailsVM : BaseRegistrationStepVM
    {
        public AccountDetailsVM()
        {
            StepNumber = 4;
        }
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Text)]
        [Display(Name = "UserName", ResourceType = typeof(RPLResources))]
        [UserName(ErrorMessageResourceName = "UserNameErrorMessage", ErrorMessageResourceType =typeof(Messages))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
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
        [RegularExpression(@"^.{8,25}$",ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(RPLResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordNotMatchValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        // Allow only saudi mobile numbers
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiPhoneNumber")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Url(ErrorMessageResourceName = "UrlValidator", ErrorMessageResourceType = typeof(RPLResources))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "WebAddress", ResourceType = typeof(RPLResources))]
        public string WebAddress { get; set; }
    }
}