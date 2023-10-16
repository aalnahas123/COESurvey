using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.ComponentModel.DataAnnotations;


namespace COE.Common.Model
{
    [MetadataType(typeof(SponserRepresentiveDetailMetadata))]
    public partial class SponserRepresentiveDetail
    {
    }
    class SponserRepresentiveDetailMetadata
    {
        [Display(Name = "RepresentativeName", ResourceType = typeof(ProviderResources))]
        public string RepresentativeName { get; set; }

        [Display(Name = "RepresentativeJobTitle", ResourceType = typeof(ProviderResources))]
        public string RepresentativeJobTitle { get; set; }

        [Display(Name = "RepresentativeMobileNo", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ProviderResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        public string RepresentativeMobileNo { get; set; }

        [Display(Name = "RepresentativeEmail", ResourceType = typeof(ProviderResources))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ProviderResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string RepresentativeEmail { get; set; }
    }

}
