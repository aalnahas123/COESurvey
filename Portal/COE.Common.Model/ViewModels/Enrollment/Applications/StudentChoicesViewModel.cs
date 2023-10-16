using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentChoicesViewModel
    {
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "Programs", ResourceType = typeof(ApplicantResources))]
        //public int ProgramID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Batch", ResourceType = typeof(ApplicantResources))]
        public int BatchID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstSpecialization", ResourceType = typeof(ApplicantResources))]
        public int FirstSpecializationID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Region", ResourceType = typeof(ApplicantResources))]
        public int RegionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AcademicDegree", ResourceType = typeof(ApplicantResources))]
        public int QualificationLevelID { get; set; } 

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

        [Display(Name = "Motivation", ResourceType = typeof(AppResources))]
        public string Motivation { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "JoinedBefore", ResourceType = typeof(AppResources))]
        public bool IsJoinedBefore { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UniversityGraduated", ResourceType = typeof(AppResources))]
        public bool IsUniversityGraduated { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WorkStatus", ResourceType = typeof(AppResources))]
        public int WorkStatusID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "HaveEnglishCertificate", ResourceType = typeof(ApplicantResources))]
        public bool IsEnglishCertified { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? EnglishCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "EnglishCertificateAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase EnglishCertificateAttachedFile { get; set; }


        // For OSH Program

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? AcademicDegreeAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AcademicDegreeAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AcademicDegreeAttachedFile { get; set; }
    }
}
