using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(SpecializationStatisticMetaData))]
    public partial class SpecializationStatistic : CommonMetaData
    {
        public List<LookupViewModel> LevelList { get; set; }

        public List<LookupViewModel> SpecializationList { get; set; }

        [Required]
        public int? SelectedLevelID { get; set; }

        [Required]
        public int? SelectedSpecializationID { get; set; }

        internal class SpecializationStatisticMetaData
        {
            [Display(Name = "SpecializationStatistic_NumberOfNew", ResourceType = typeof(MetaData))]
            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            public int NumberOfNew { get; set; }

            [Display(Name = "SpecializationStatistic_NumberOfContinuing", ResourceType = typeof(MetaData))]
            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            public int NumberOfContinuing { get; set; }

            [Display(Name = "SpecializationStatistic_NumberOfRepeats", ResourceType = typeof(MetaData))]
            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            public int NumberOfRepeats { get; set; }
        }
    }
}

