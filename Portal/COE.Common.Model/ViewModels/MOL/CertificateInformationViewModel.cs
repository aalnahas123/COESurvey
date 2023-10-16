using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    public class CertificateInformationViewModel:BaseViewModel
    {
        public int RPLApplicantID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GraduationYear", ResourceType = typeof(AppResources))]
        public int GraduationYearID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Country", ResourceType = typeof(ApplicantResources))]
        public int RegionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolCity", ResourceType = typeof(AppResources))]
        public int CityID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FacultyName", ResourceType = typeof(AppResources))]
        public string FacultyName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CollegeAddress", ResourceType = typeof(AppResources))]
        public string CollegeAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "InstituteAddress", ResourceType = typeof(AppResources))]
        public string InstituteAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CourseName", ResourceType = typeof(AppResources))]
        public string CourseName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CertificateName", ResourceType = typeof(AppResources))]
        public string CertificateName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CertificateDonor", ResourceType = typeof(AppResources))]
        public string CertificateDonor { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CertificateLevel", ResourceType = typeof(RPLResources))]
        public int CertificateLevelId { get; set; }

        [Display(Name = "StudyStartDate", ResourceType = typeof(AppResources))]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StudyStartDate { get; set; }

        [Display(Name = "GraduationDate", ResourceType = typeof(AppResources))]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime GraduationDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EducationLevel", ResourceType = typeof(AppResources))]
        public int EducationLevel { get; set; }

        [Display(Name = "Region", ResourceType = typeof(AppResources))]
        public string RegionName { get; set; }

        [Display(Name = "SchoolCity", ResourceType = typeof(AppResources))]
        public string CityName { get; set; }

        [Display(Name = "EducationLevel", ResourceType = typeof(AppResources))]
        public string EducationLevelName { get; set; }

        [Display(Name = "CertificateLevel", ResourceType = typeof(RPLResources))]
        public string CertificateLevelName { get; set; }

        [Display(Name = "StudyStartDate", ResourceType = typeof(AppResources))]
        public string StudyStartDateStr { get; set; }

        [Display(Name = "GraduationDate", ResourceType = typeof(AppResources))]
        public string GraduationDateStr { get; set; }

        public int StageId { get; set; }
        public Nullable<long> RequestID { get; set; }

    }
}
