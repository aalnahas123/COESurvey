using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using Commons.Framework.Resources;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public class BasicDetailsVM : BaseRegistrationStepVM
    {
        public BasicDetailsVM()
        {
            StepNumber = 1;
        }

        [Display(Name = "CenterName", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [EnglishTextOnly(ErrorMessageResourceName = "EnglishLettersOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))]
        public string Name { get; set; }

        [Display(Name = "CenterNameAR", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [ArabicTextOnly(ErrorMessageResourceName = "ArabicLettersOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))]
        public string NameAr { get; set; }

        [Display(Name = "CenterDescription", ResourceType = typeof(RPLResources))]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(500, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [ArabicTextOnly(ErrorMessageResourceName = "ArabicLettersOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Display(Name = "CenterManager", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(255, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [ArabicTextOnly(ErrorMessageResourceName = "ArabicLettersOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))]
        public string CenterManager { get; set; }


        [Display(Name = "CenterAddress", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(250, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [ArabicTextOnly(ErrorMessageResourceName = "ArabicLettersOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))]
        public string CenterAddress { get; set; }

        [Display(Name = "Capacity", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]    
        [NumbersOnly/*(ErrorMessageResourceName = "NumberOnlyErrorMessage", ErrorMessageResourceType = typeof(Messages))*/]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int Capacity { get; set; }

        //[Display(Name = "Gender", ResourceType = typeof(AppResources))]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //public bool GenderID { get; set; }

        //[Display(Name = "Gender", ResourceType = typeof(AppResources))]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //public int CenterType { get; set; }

        [Display(Name = "Area", ResourceType = typeof(ContractManagmentResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AreaID { get; set; }

        [Display(Name = "City", ResourceType = typeof(ContractManagmentResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CityID { get; set; }

        [Display(Name = "IAgree", ResourceType = typeof(RPLResources))]
        [MustBeTrue(ErrorMessageResourceName = "YouMustAgree", ErrorMessageResourceType = typeof(RPLResources))]
        public bool IAgree { get; set; }

      

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RecaptchaVerification", ResourceType = typeof(ApplicantResources))]
        [GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(ApplicantResources))]
        public string RecaptchaResponse { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CenterTrainingType", ResourceType = typeof(RPLResources))]
        [EnsureMinimumElementsAttribute(1,ErrorMessageResourceType = typeof(RPLResources), ErrorMessageResourceName = "RequiredSelectCenterType")]
        public List<CenterTrainingTypeVM> CenterTypes { get; set; }              

        //public List<System.Web.Mvc.SelectListItem> AreasList { get; set; }
        //public List<System.Web.Mvc.SelectListItem> CitiesList { get; set; }
    }
}
