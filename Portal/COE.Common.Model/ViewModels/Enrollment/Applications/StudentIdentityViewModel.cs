using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model
{
    public class StudentIdentityViewModel: StudentExperienceViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(UsersMgmtResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        //[RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        [RegularExpression(@"^[12]\d{9}$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiNationalId")]
        public string NationalID { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string BirthDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BirthYear", ResourceType = typeof(ApplicantResources))]
        public string BirthYear { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber", ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? StudentIdentityAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase StudentIdentityAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? CertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "CertificateAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase CertificateAttachedFile { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? AcademicRecordAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AcademicRecordAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AcademicRecordAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? CertificateEquivalenceLetterAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "CertificateEquivalenceLetterAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase CertificateEquivalenceLetterAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? EmployerLetterAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "EmployerLetterAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase EmployerLetterAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? ProgramDescAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "ProgramDescAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase ProgramDescAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? ExperienceCertificateAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "ExperienceCertificateAttachmen", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase ExperienceCertificatecAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? CVAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "CVAttachmen", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase CVAttachedFile { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RecaptchaVerification", ResourceType = typeof(ApplicantResources))]
        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(ApplicantResources))]
        public string RecaptchaResponse { get; set; }




        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? PassportAttachmentId { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "Passport", ResourceType = typeof(RPLResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase PassportAttachedFile { get; set; }        
    }
}