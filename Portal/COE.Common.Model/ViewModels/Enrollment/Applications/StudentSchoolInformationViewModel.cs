using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentSchoolInformationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GraduationYear", ResourceType = typeof(AppResources))]
        public int GraduationYearID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Region", ResourceType = typeof(ApplicantResources))]
        public int RegionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolCity", ResourceType = typeof(AppResources))]
        public int CityID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolType", ResourceType = typeof(AppResources))]
        public int? SchoolTypeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolName", ResourceType = typeof(AppResources))]
        public string SchoolName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GPA", ResourceType = typeof(AppResources))]
        public decimal? GPA { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Qiyas", ResourceType = typeof(AppResources))]
        public int? StudentMeasure { get; set; }

        [Display(Name = "Achievment", ResourceType = typeof(AppResources))]
        public int? StudentAchievement { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? HighSchoolCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "HighSchoolCertificateAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase HighSchoolCertificateAttachedFile { get; set; }
        public int? QualificationID { get; set; }
        [Display(Name = "Specialization", ResourceType = typeof(ApplicantResources))]
        public string Specialization { get; set; }
    }
}
