using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(ProviderContactDetailMetadata))]

    public partial class ProviderContactDetail
    {
        [DataType(DataType.Upload)]
        [ValidateFileUpload]
        [Display(Name = "Logo", ResourceType = typeof(ProviderResources))]
        //[RequiredIf("true", ErrorMessageResourceName = "RequiredField",
        //            ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile { get; set; }

    }
    class ProviderContactDetailMetadata
    {
        [Display(Name = "Address", ResourceType = typeof(ProviderResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string Address { get; set; }

        [Display(Name = "WebAddress", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(ProviderResources))]
        public string WebAddress { get; set; }

        [Display(Name = "Location", ResourceType = typeof(ProviderResources))]
        public string Location { get; set; }

        [Display(Name = "MobileNo1", ResourceType = typeof(ProviderResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo1 { get; set; }

        [Display(Name = "MobileNo2", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo2 { get; set; }

        [Display(Name = "TelNo1", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string TelNo1 { get; set; }

        [Display(Name = "TelNo2", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string TelNo2 { get; set; }

        [Display(Name = "FaxNo", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string FaxNo { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "OfficialEmail", ResourceType = typeof(ProviderResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string OfficialEmail { get; set; }

        [Display(Name = "SupportEmail", ResourceType = typeof(ProviderResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [DataType(DataType.EmailAddress)]
        public string SupportEmail { get; set; }

        [Display(Name = "Logo", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.Upload)]
        public Guid? LogoAttachmentId { get; set; }

        [Display(Name = "FacebookURL", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(ProviderResources))]
        public string FacebookURL { get; set; }

        [Display(Name = "TwitterURL", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.Url, ErrorMessageResourceName = "InvalidUrl", ErrorMessageResourceType = typeof(ProviderResources))]
        public string TwitterURL { get; set; }
    }

}
