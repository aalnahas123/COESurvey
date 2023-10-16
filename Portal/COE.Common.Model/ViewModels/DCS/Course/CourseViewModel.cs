using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class CourseViewModel:BaseViewModel
    {
        
        [Required]
        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public string Name { get; set; }        
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "CourseCreditHoursValidation", ErrorMessageResourceType =typeof(DCSResources))]
        [Display(Name = "CourseCreditHours", ResourceType = typeof(DCSResources))]       
        public int CreditHours { get; set; }
        [Required]
        [Display(Name = "CourseCode", ResourceType = typeof(DCSResources))]
        [StringLength(20, MinimumLength = 1,ErrorMessageResourceName = "CourseCodeLengthValidation", ErrorMessageResourceType = typeof(DCSResources))]
        public string CourseCode { get; set; }
        [Required]
        [Display(Name = "CourseType", ResourceType = typeof(DCSResources))]
        public int CourseTypeID { get; set; }
        //[Required]
        [Display(Name = "CourseLevel", ResourceType = typeof(DCSResources))]
        public int CourseLevelID { get; set; }
        
        public string CourseLevelName { get; set; }

        [Required]
        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public int CollegeID { get; set; }
        //[Required]
        [Display(Name = "Specialization", ResourceType = typeof(DCSResources))]
        public int SpecializationID { get; set; }
       
        public string SpecializationName { get; set; }


        [Required]
        [Display(Name = "Batch_ProgramID", ResourceType = typeof(MetaData))]        
        public int? SelectedProgramID { get; set; }

        [Required]
        [Display(Name = "Batch_SubProgramID", ResourceType = typeof(MetaData))]       
        public int? SelectedSubProgramID { get; set; }

        public List<LookupViewModel> CollegesList { get; set; }
        //public List<LookupViewModel> SpecializationList { get; set; }
        public List<LookupViewModel> CourseTypes { get; set; }
        //public List<LookupViewModel> CourseLevels { get; set; }
        public bool isDuplicateCourse { get; set; }
        public bool isErrorHappenedWhileSave { get; set; }

        public List<CourseOpenTermViewModel> OpenTerms { get; set; }

        public List<System.Web.Mvc.SelectListItem> SubProgramsList { get; set; }
    }
}
