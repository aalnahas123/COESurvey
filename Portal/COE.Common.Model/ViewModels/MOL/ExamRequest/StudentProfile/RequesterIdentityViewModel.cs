using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Utils;
using COE.Common.Localization;


namespace COE.Common.Model.ViewModels.MOL.ExamRequest
{
    public class RequesterIdentityViewModel
    {
        public Guid? UserID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(UsersMgmtResources))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [RegularExpression(@"^[12]\d{9}$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "SaudiNationalId")]
        public string NationalID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BirthYear", ResourceType = typeof(ExamRequestResources))]
        public string BirthYear { get; set; }


        // National ID : Attachment
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ExamRequestResources))]
        public Guid? StudentIdentityAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ExamRequestResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase StudentIdentityAttachedFile { get; set; }

        /*[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RecaptchaVerification", ResourceType = typeof(ApplicantResources))]
        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(ApplicantResources))]
        public string RecaptchaResponse { get; set; }*/

        // To Display Data
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(SponserResources))]
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
        ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = (Commons.Framework.Web.Mvc.Helpers.NumberType)NumberType.MOBILE, CountryCode = "SA")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        public string Email { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ApplicantResources), Name = "Region")]
        public int RegionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ApplicantResources), Name = "City")]
        public int CityID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "IsHealthSpecialist", ResourceType = typeof(ExamRequestResources))]
        public bool? IsHealthSpecialist { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "QualificationFrom", ResourceType = typeof(ExamRequestResources))]
        public bool? IsSaudiEducationalQualification { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TrainingTrack", ResourceType = typeof(ExamRequestResources))]
        public byte TrainingTrack { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EducationLevel", ResourceType = typeof(AppResources))]
        public int EducationLevel { get; set; }
       
    }
}
