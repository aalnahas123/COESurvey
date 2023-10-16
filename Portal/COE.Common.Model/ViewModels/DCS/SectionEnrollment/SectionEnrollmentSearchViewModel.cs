using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionEnrollmentSearchViewModel
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }

        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public int? CollegeId { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(DCSResources))]
        public int? SpecializationId { get; set; }

        [Display(Name = "CourseType", ResourceType = typeof(DCSResources))]
        public int? CourseTypeId { get; set; }

        [Display(Name = "CourseLevel", ResourceType = typeof(DCSResources))]
        public int? CourseLevelId { get; set; }

        [Display(Name = "CourseCode", ResourceType = typeof(DCSResources))]
        public string CourseCode { get; set; }

        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public string CourseName { get; set; }

        [Display(Name = "SectionCode", ResourceType = typeof(DCSResources))]
        public string SectionCode { get; set; }

        
        [Display(Name = "NationalId", ResourceType = typeof(DCSResources))]
        public string NationalId { get; set; }


        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }


        public List<LookupViewModel> CollegesList { get; set; }
        public List<LookupViewModel> SpecializationList { get; set; }
        public List<LookupViewModel> CourseTypes { get; set; }
        public List<LookupViewModel> CourseLevels { get; set; }
    }
}
