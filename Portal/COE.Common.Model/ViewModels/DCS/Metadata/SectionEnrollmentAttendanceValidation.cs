using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(SectionEnrollmentAttendanceValidationMetaData))]
    public partial class SectionEnrollmentAttendanceValidation
    {
        class SectionEnrollmentAttendanceValidationMetaData
        {

            [Display(Name = "MD_SectionValidation_CourseCode", ResourceType = typeof(DCSResources))]
            public string CourseCode { get; set; }

            [Display(Name = "MD_SectionValidation_SectionCode", ResourceType = typeof(DCSResources))]
            public string SectionCode { get; set; }

            [Display(Name = "MD_SectionEnrollmentValidation_NationalID", ResourceType = typeof(DCSResources))]
            public string NationalID { get; set; }

            [Display(Name = "MD_SectionEnrollmentAttendanceValidation_ExcusedHours", ResourceType = typeof(DCSResources))]
            public string ExcusedHours { get; set; }

            [Display(Name = "MD_SectionEnrollmentAttendanceValidation_AttendedHours", ResourceType = typeof(DCSResources))]
            public string AttendedHours { get; set; }

            [Display(Name = "MD_SectionEnrollmentAttendanceValidation_ExtraHours", ResourceType = typeof(DCSResources))]
            public string ExtraHours { get; set; }

        }
    }
}