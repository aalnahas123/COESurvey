using COE.Common.Localization;
using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(PeriodMetadata))]
    public partial class Period
    {
       
        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int YearId { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int MonthId { get; set; }

        [Display(Name = "TermTypeId", ResourceType = typeof(StipendResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int? TermTypeId { get; set; }

        [Display(Name = "AcademicYearID", ResourceType = typeof(StipendResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]

        public int AcademicYearID { get; set; }

        public int? Periods { get; set; }

        public int FirsteriodDays { get; set; }

        public int SecondPeriodDays { get; set; }

        class PeriodMetadata
        {

            [Display(Name = "FromDay", ResourceType = typeof(StipendResources))]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public int FromDay { get; set; }

            [Display(Name = "ToDay", ResourceType = typeof(StipendResources))]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public int ToDay { get; set; }

            [Required]
            [Display(Name = "DaysOfMonth", ResourceType = typeof(StipendResources))]
            public int DaysOfMonth { get; set; } 

        }
    }
}