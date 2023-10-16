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
    [MetadataType(typeof(ProviderMetadata))]
    public partial class Provider
    {
        public bool IsSelected { get; set; }
        public virtual List<College> CollegeList { get; set; } = new List<Model.College>();

    }

    class ProviderMetadata
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

        [Display(Name = "Country", ResourceType = typeof(ProviderResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CountryId { get; set; }

        [Display(Name = "Status", ResourceType = typeof(ProviderResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int StatusID { get; set; }
    }

}
