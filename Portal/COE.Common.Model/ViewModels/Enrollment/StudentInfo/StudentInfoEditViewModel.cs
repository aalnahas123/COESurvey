using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentInfoEditViewModel
    {
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


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BirthDate", ResourceType = typeof(AppResources))]
        public string BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Gender", ResourceType = typeof(AppResources))]
        public bool IsMale { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        public string NationalID { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase StudentIdentityAttachedFile { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? StudentIdentityAttachmentId { get; set; }

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
