using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;
using COE.Common.Localization;
using COE.Common.Localization.Security;
using Commons.Framework.Web.Mvc.Helpers;
using System;
using COE.Common.Model.ViewModels;
using ExpressiveAnnotations.Attributes;
using System.Collections.Generic;
using Commons.Framework.Extensions;

namespace COE.Common.Model.SearchModels
{
    public class CertificateVerificationSearchModel
    {
        private string serialNumber;

        [RequiredIf(@"SerialNumber == '' || SerialNumber == null", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        public string NationalId { get; set; }

        [RequiredIf(@"NationalId == '' || NationalId == null", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SerialNumber", ResourceType = typeof(SharedResources))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        public string SerialNumber { get => serialNumber.To<int>().ToString(); set => serialNumber = value; }

        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(SharedResources))]
        public string RecaptchaResponse { get; set; }


        public List<CertificateVerificationViewModel> CertificateVerificationModel { get; set; }

    }
}
