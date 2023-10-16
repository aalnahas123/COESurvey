using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentOtherInfoEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WorkStatus", ResourceType = typeof(AppResources))]
        public int WorkStatusId { get; set; }

        [Display(Name = "UniversityGraduated", ResourceType = typeof(AppResources))]
        public bool IsUniversityGraduated { get; set; }

        [Display(Name = "JoinedBefore", ResourceType = typeof(AppResources))]
        public bool IsJoinedBefore { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "HaveEnglishCertificate", ResourceType = typeof(ApplicantResources))]
        public bool IsEnglishCertified { get; set; }

        [Display(Name = "Motivation", ResourceType = typeof(AppResources))]
        public string Motivation { get; set; }

    }
}
