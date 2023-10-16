using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using Commons.Framework.Web.Mvc.DataAnnotations;
using COE.Common.Localization;
using System.Web;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            //ChangeContactViewModel = new ChangeContactViewModel();
            EnrollmentHistory = new EnrollmentHistoryViewModel();
            EnrollmentRequestDetails = new List<EnrollmentRequestDetailViewModel>();
        }
        // Personal Information
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EnglishTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "EnglishTextOnly")]
        [Display(Name = "FirstNameEn", ResourceType = typeof(AppResources))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EnglishTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "EnglishTextOnly")]
        [Display(Name = "FatherNameEn", ResourceType = typeof(AppResources))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EnglishTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "EnglishTextOnly")]
        [Display(Name = "GrandFatherNameEn", ResourceType = typeof(AppResources))]
        public string ThirdName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EnglishTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "EnglishTextOnly")]
        [Display(Name = "FamilyNameEn", ResourceType = typeof(AppResources))]
        public string FourthName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ArabicTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "ArabicTextOnly")]
        [Display(Name = "FirstNameAr", ResourceType = typeof(AppResources))]
        public string FirstNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ArabicTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "ArabicTextOnly")]
        [Display(Name = "FatherNameAr", ResourceType = typeof(AppResources))]
        public string SecondNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ArabicTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "ArabicTextOnly")]
        [Display(Name = "GrandFatherNameAr", ResourceType = typeof(AppResources))]
        public string ThirdNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ArabicTextOnly(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "ArabicTextOnly")]
        [Display(Name = "FamilyNameAr", ResourceType = typeof(AppResources))]
        public string FourthNameAr { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase StudentIdentityAttachedFile { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? StudentIdentityAttachmentId { get; set; }

        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string Gender { get; set; }
        public bool IsMale { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public string UserName { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        public string NationalID { get; set; }
        public string BirthDate { get; set; }
        // Academic Information
        public int EnrollmentID { get; set; }
        public int StageId { get; set; }
        public int CollegeId { get; set; }
        public int CollegeTypeId { get; set; }
        public int LevelId { get; set; }
        public int StatuslId { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public string CollegeName { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(AppResources))]
        public string SpecializationName { get; set; }

        [Display(Name = "RequestStatus", ResourceType = typeof(AppResources))]
        public string CurrentStatus { get; set; }
        public DateTime? CurrentStatusDate { get; set; }
        public DateTime JoinDate { get; set; }
        public string JoinTerm { get; set; }
        public string SponserName { get; set; }
        public int? DisabilityLevelId { get; set; }
        public string DisabilityLevelName { get; set; }

        // ChangePassword
        public virtual ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        // ChangeContact
        public ChangeContactViewModel ChangeContactViewModel { get; set; }
        // School Information
        public SchoolViewModel School { get; set; }
        // Enrollment History
        public EnrollmentHistoryViewModel EnrollmentHistory { get; set; }
        public List<object> Exams { get; set; }
        public List<object> Attendence { get; set; }

        public string TabIndex { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WorkStatus", ResourceType = typeof(AppResources))]
        public int WorkStatusId { get; set; }

        [Display(Name = "WorkStatus", ResourceType = typeof(AppResources))]
        public string WorkStatus { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UniversityGraduated", ResourceType = typeof(AppResources))]
        public bool IsUniversityGraduated { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "JoinedBefore", ResourceType = typeof(AppResources))]
        public bool IsJoinedBefore { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "HaveEnglishCertificate", ResourceType = typeof(ApplicantResources))]
        public bool IsEnglishCertified { get; set; }

        [Display(Name = "Motivation", ResourceType = typeof(AppResources))]
        public string Motivation { get; set; }
        public List<EnrollmentRequestDetailViewModel> EnrollmentRequestDetails { get; set; }

        // Yakeen Flags
        public bool? FirstNameIsFromYakeen { get; set; }
        public bool? SecondNameIsFromYakeen { get; set; }
        public bool? ThirdNameIsFromYakeen { get; set; }
        public bool? FourthNameIsFromYakeen { get; set; }
        public bool? FirstNameArIsFromYakeen { get; set; }
        public bool? SecondNameArIsFromYakeen { get; set; }
        public bool? ThirdNameArIsFromYakeen { get; set; }
        public bool? FourthNameArIsFromYakeen { get; set; }
        public bool? BirthDateIsFromYakeen { get; set; }
        public bool? IsMaleIsFromYakeen { get; set; }
        public DateTime? LastUpdatedFromYakeen { get; set; }
    }
}
