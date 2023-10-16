using System;
using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ApplicantsBatchEditingSearchViewModel
    {
        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string NationalId { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "DateFrom", ResourceType = typeof(SharedResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(SharedResources))]
        public DateTime? DateTo { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "College", ResourceType = typeof(EnrollmentResources))]
        public int CollegeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Status", ResourceType = typeof(EnrollmentResources))]
        public int StageId { get; set; }

        public string UserName { get; set; }
    }
}
