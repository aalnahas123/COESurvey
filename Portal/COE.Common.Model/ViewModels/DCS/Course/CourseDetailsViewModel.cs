using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class CourseDetailsViewModel
    {
        public int ID { get; set; }
        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public string Name { get; set; }
        public string Description { get; set; }      
        
        [Display(Name = "CourseCreditHours", ResourceType = typeof(DCSResources))]
        public int? CreditHours { get; set; }
        
        [Display(Name = "CourseCode", ResourceType = typeof(DCSResources))]
        public string CourseCode { get; set; }
        
        [Display(Name = "CourseType", ResourceType = typeof(DCSResources))]
        public string CourseType { get; set; }
      
        [Display(Name = "CourseLevel", ResourceType = typeof(DCSResources))]
        public string CourseLevel { get; set; }
      
        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public string CollegeName { get; set; }       
        public int CollegeID { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(DCSResources))]
        public string Specialization { get; set; }

        [Display(Name = "CourseCreatedOn", ResourceType = typeof(DCSResources))]
        public string CreatedOn { get; set; }
        [Display(Name = "CourseUpdatedOn", ResourceType = typeof(DCSResources))]
        public string UpdatedOn { get; set; }

        public List<CourseOpenTermViewModel> OpenTerms { get; set; }

    }
}
