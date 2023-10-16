using COE.Common.Localization;
using COE.Common.Localization.Security;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(SponserMetadata))]
    public partial class Sponser
    {
        [Display(Name = "Country", ResourceType = typeof(SponserResources))]
        public int? CountryId { get; set; }

    }
    class SponserMetadata
    {
        [EnglishTextOnly, Display(Name = "NameEn", ResourceType = typeof(AppResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string Name { get; set; }

        [ArabicTextOnly, Display(Name = "NameAr", ResourceType = typeof(AppResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string NameAr { get; set; }

        [EnglishTextOnly, Display(Name = "DescriptionEn", ResourceType = typeof(AppResources))]
        public string Description { get; set; }

        [ArabicTextOnly, Display(Name = "DescriptionAr", ResourceType = typeof(AppResources))]
        public string DescriptionAr { get; set; }

        [Display(Name = "City", ResourceType = typeof(SponserResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CityID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(SponserResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int StatusID { get; set; }
    }

}
