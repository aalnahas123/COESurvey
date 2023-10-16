using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(CollegeContactDetailMetadata))]
    public partial class CollegeContactDetail
    {
        [DataType(DataType.Upload)]
        [ValidateFileUpload]
        [Display(Name = "Logo", ResourceType = typeof(ProviderResources))]
        //[RequiredIf("true", ErrorMessageResourceName = "RequiredField",
        //            ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile { get; set; }

    }
    class CollegeContactDetailMetadata
    {
        [Display(Name = "Address", ResourceType = typeof(ContractManagmentResources))]
        public string Address { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WebAddress", ResourceType = typeof(ContractManagmentResources))]
        [Url(ErrorMessageResourceName = "Invalid_Url", ErrorMessageResourceType = typeof(AppResources))]
        public string WebAddress { get; set; }

        [Display(Name = "Location", ResourceType = typeof(ContractManagmentResources))]
        public string Location { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "MobileNo1", ResourceType = typeof(ContractManagmentResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
            ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo1 { get; set; }

        [Display(Name = "MobileNo2", ResourceType = typeof(ContractManagmentResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
            ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string MobileNo2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidTelNumber",
            ErrorMessageResourceType = typeof(ContractManagmentResources), NumberType = NumberType.FIXED_LINE_OR_MOBILE, CountryCode = "SA")]
        [Display(Name = "TelNo1", ResourceType = typeof(ContractManagmentResources))]
        public string TelNo1 { get; set; }

        [Display(Name = "TelNo2", ResourceType = typeof(ContractManagmentResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidTelNumber",
            ErrorMessageResourceType = typeof(ContractManagmentResources), NumberType = NumberType.FIXED_LINE, CountryCode = "SA")]
        public string TelNo2 { get; set; }

        [Display(Name = "FaxNo", ResourceType = typeof(ContractManagmentResources))]
        public string FaxNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "OfficialEmail", ResourceType = typeof(ContractManagmentResources))]
        public string OfficialEmail { get; set; }

        [Display(Name = "SupportEmail", ResourceType = typeof(ContractManagmentResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string SupportEmail { get; set; }

        [Display(Name = "Logo", ResourceType = typeof(ContractManagmentResources))]
        public Guid LogoAttachmentId { get; set; }

        [Display(Name = "FacebookURL", ResourceType = typeof(ContractManagmentResources))]
        [Url(ErrorMessageResourceName = "Invalid_Url", ErrorMessageResourceType = typeof(AppResources))]
        public string FacebookURL { get; set; }

        [Display(Name = "TwitterURL", ResourceType = typeof(ContractManagmentResources))]
        [Url(ErrorMessageResourceName = "Invalid_Url", ErrorMessageResourceType = typeof(AppResources))]
        public string TwitterURL { get; set; }

    }
}
