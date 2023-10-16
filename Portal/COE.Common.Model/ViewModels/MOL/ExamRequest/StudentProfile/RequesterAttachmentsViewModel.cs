using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;

namespace COE.Common.Model.ViewModels.MOL.ExamRequest
{
    public class RequesterAttachmentsViewModel
    {
        // Graduation certificate Attachments

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "GraduationCertificateAttachments", ResourceType = typeof(ExamRequestResources))]
        public Guid? GraduationCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "GraduationCertificateAttachments", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase GraduationCertificateAttachedFile { get; set; }


        // Academic Record Attachments
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "AcademicRecord", ResourceType = typeof(ExamRequestResources))]
        public Guid? AcademicRecordAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AcademicRecord", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AcademicRecordAttachedFile { get; set; }

        // Educational Equation Attachments
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "EducationalEquation", ResourceType = typeof(ExamRequestResources))]
        public Guid? EducationalEquationAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "EducationalEquation", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase EducationalEquationAttachedFile { get; set; }


        // E-training attendance certificate   : Attachments
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "ETrainingAttendance", ResourceType = typeof(ExamRequestResources))]
        public Guid? ETrainingAttendanceAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "ETrainingAttendance", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase ETrainingAttendanceAttachedFile { get; set; }


        // Letter of introduction from the employer / experience certificate    : Attachments
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "LetterOrexperienceCertificate", ResourceType = typeof(ExamRequestResources))]
        public Guid? LetterOrexperienceCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "LetterOrexperienceCertificate", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase LetterOrexperienceCertificateAttachedFile { get; set; }


        // Saudi Council Of Engineers Certificate     : Attachments 
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "SaudiCouncilOfEngineersCertificate", ResourceType = typeof(ExamRequestResources))]
        public Guid? SaudiCouncilOfEngineersCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "SaudiCouncilOfEngineersCertificate", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase SaudiCouncilOfEngineersCertificateAttachedFile { get; set; }

        // Saudi Health Specializations Authority  Certificate     : Attachments SaudiHealthSpecializationsAuthority 
        //[RequiredIf(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "SaudiHealthSpecializationsAuthorityCertificate", ResourceType = typeof(ExamRequestResources))]
        public Guid? SaudiHealthSpecializationsAuthorityCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "SaudiHealthSpecializationsAuthorityCertificate", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase SaudiHealthSpecializationsAuthorityCertificateAttachedFile { get; set; }


    }
}