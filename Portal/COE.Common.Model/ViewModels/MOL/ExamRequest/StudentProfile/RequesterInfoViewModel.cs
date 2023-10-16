using System;
using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.MOL.ExamRequest
{
    public class RequesterInfoViewModel
    {
        //public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstNameEn", ResourceType = typeof(AppResources))]
        public string FirstName { get; set; }
        public bool? FirstNameIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FatherNameEn", ResourceType = typeof(AppResources))]
        public string SecondName { get; set; }
        public bool? SecondNameIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GrandFatherNameEn", ResourceType = typeof(AppResources))]
        public string ThirdName { get; set; }
        public bool? ThirdNameIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FamilyNameEn", ResourceType = typeof(AppResources))]
        public string FourthName { get; set; }
        public bool? FourthNameIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstNameAr", ResourceType = typeof(AppResources))]
        public string FirstNameAr { get; set; }
        public bool? FirstNameArIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FatherNameAr", ResourceType = typeof(AppResources))]
        public string SecondNameAr { get; set; }
        public bool? SecondNameArIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GrandFatherNameAr", ResourceType = typeof(AppResources))]
        public string ThirdNameAr { get; set; }
        public bool? ThirdNameArIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FamilyNameAr", ResourceType = typeof(AppResources))]
        public string FourthNameAr { get; set; }
        public bool? FourthNameArIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BirthDateHijri", ResourceType = typeof(AppResources))]
        public string BirthDate { get; set; }
        public bool? BirthDateIsFromYakeen { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Gender", ResourceType = typeof(AppResources))]
        public bool IsMale { get; set; }
        public bool? IsMaleIsFromYakeen { get; set; }

        public int IsMaleInt { get; set; }
        public DateTime? LastUpdatedFromYakeen { get; set; }

        

    }
}
