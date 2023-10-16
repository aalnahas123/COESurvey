using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using Commons.Framework.Web.Mvc.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ChangeContactViewModel
    {
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
                ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string MobileNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }

        public Guid UserId { get; set; }

    }
}
