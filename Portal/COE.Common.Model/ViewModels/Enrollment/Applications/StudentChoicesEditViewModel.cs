using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentChoicesEditViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int QualificationID { get; set; }
        [Display(Name = "Specialization", ResourceType = typeof(ApplicantResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string Specialization { get; set; }
        public bool IsHighSchool { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolType", ResourceType = typeof(AppResources))]
        public int SchoolTypeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstSpecialization", ResourceType = typeof(ApplicantResources))]
        public int FirstSpecializationID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstCollege", ResourceType = typeof(ApplicantResources))]
        public int FirstCollegeSpecializationID { get; set; }

        [Display(Name = "SecondSpecialization", ResourceType = typeof(ApplicantResources))]
        public int? SecondSpecializationID { get; set; }

        [Display(Name = "SecondCollege", ResourceType = typeof(ApplicantResources))]
        public int? SecondCollegeSpecializationID { get; set; }

        [Display(Name = "ThirdSpecialization", ResourceType = typeof(ApplicantResources))]
        public int? ThirdSpecializationID { get; set; }

        [Display(Name = "ThirdCollege", ResourceType = typeof(ApplicantResources))]
        public int? ThirdCollegeSpecializationID { get; set; }

    }
}
