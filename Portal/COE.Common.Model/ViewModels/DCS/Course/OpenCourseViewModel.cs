using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class OpenCourseViewModel:BaseViewModel
    {
        public CourseDetailsViewModel CourseDetails { get; set; }

        [Required]
        [Display(Name = "Term", ResourceType = typeof(DCSResources))]
        public int AcademicYearTermID { get; set; }

        [Required]
        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public int CollegeAcademicYearID { get; set; }

        public int CourseID { get; set; }

        public List<LookupViewModel> CollegeAcademicYears { get; set; }
        public List<LookupViewModel> AcademicYearTerms { get; set; }       
        public bool isDuplicateTermCourse { get; set; }
        public bool isErrorHappenedWhileSave { get; set; }
    }
}
