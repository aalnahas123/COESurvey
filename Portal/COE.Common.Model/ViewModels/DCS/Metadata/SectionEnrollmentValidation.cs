using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(SectionEnrollmentValidationMetaData))]
    public partial class SectionEnrollmentValidation
    {
        class SectionEnrollmentValidationMetaData
        {

            [Display(Name = "MD_SectionValidation_CourseCode", ResourceType = typeof(DCSResources))]
            public string CourseCode { get; set; }

            [Display(Name = "MD_SectionValidation_SectionCode", ResourceType = typeof(DCSResources))]
            public string SectionCode { get; set; }

            [Display(Name = "MD_SectionEnrollmentValidation_NationalID", ResourceType = typeof(DCSResources))]
            public string NationalID { get; set; }

            [Display(Name = "MD_SectionEnrollmentValidation_EnrollmentStatus", ResourceType = typeof(DCSResources))]
            public string EnrollmentStatus { get; set; }
            
        }
    }
}