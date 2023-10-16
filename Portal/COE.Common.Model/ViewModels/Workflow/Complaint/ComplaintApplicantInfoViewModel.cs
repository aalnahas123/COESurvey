using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintApplicantInfoViewModel
    {
        [Display(Name = "StudentName", ResourceType = typeof(AppResources))]
        public string FullName { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        public string NationalId { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public string CollegeName { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(AppResources))]
        public string SpecializationName { get; set; }
    }
}
