using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TransferVisitorViewModel
    {
        public TermEnrollment TermEnrollment { get; set; }

        public int TermEnrollmentId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NewCollege", ResourceType = typeof(AppResources))]
        public int NewCollegeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NewSpecialization", ResourceType = typeof(AppResources))]
        public int NewSpecializationID { get; set; }
    }
}
