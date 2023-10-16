using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(SponserContactDetailMetadata))]
    public partial class SponserContactDetail
    {
        [DataType(DataType.Upload)]
        [ValidateFileUpload]
        [Display(Name = "Logo", ResourceType = typeof(SponserResources))]
        //[RequiredIf("true", ErrorMessageResourceName = "RequiredField",
        //            ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile { get; set; }

    }
    class SponserContactDetailMetadata
    {
        [Display(Name = "Address", ResourceType = typeof(SponserResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string Address { get; set; }

        [Display(Name = "WebAddress", ResourceType = typeof(SponserResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(SponserResources))]
        public string WebAddress { get; set; }

        [Display(Name = "Location", ResourceType = typeof(SponserResources))]
        public string Location { get; set; }

        [Display(Name = "MobileNo1", ResourceType = typeof(SponserResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo1 { get; set; }

        [Display(Name = "MobileNo2", ResourceType = typeof(SponserResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo2 { get; set; }

        [Display(Name = "TelNo1", ResourceType = typeof(SponserResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string TelNo1 { get; set; }

        [Display(Name = "TelNo2", ResourceType = typeof(SponserResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string TelNo2 { get; set; }

        [Display(Name = "FaxNo", ResourceType = typeof(SponserResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string FaxNo { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "OfficialEmail", ResourceType = typeof(SponserResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string OfficialEmail { get; set; }

        [Display(Name = "SupportEmail", ResourceType = typeof(SponserResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [DataType(DataType.EmailAddress)]
        public string SupportEmail { get; set; }

        [Display(Name = "Logo", ResourceType = typeof(SponserResources))]
        [DataType(DataType.Upload)]
        public Guid? LogoAttachmentId { get; set; }

        [Display(Name = "FacebookURL", ResourceType = typeof(SponserResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(SponserResources))]
        public string FacebookURL { get; set; }

        [Display(Name = "TwitterURL", ResourceType = typeof(SponserResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(SponserResources))]
        public string TwitterURL { get; set; }
    }

}
