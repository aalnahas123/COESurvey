using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.AssessmentPeriod
{
    public class AssessmentPeriodViewModel
    {
        public int ID { get; set; }
        public string ErrorMessage { get; set; }

        [Display(Name = "AcademicTerm", ResourceType = typeof(AssessmentPeriodResources))]
        public int AcademicYearTerm { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(AssessmentPeriodResources))]
        public int AcademicYear { get; set; }

        [Display(Name = "AssessmentPeriodCode", ResourceType = typeof(AssessmentPeriodResources))]
        [MaxLength(50)]
        [Required]
        public string AssessmentCode { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        [DateMustBeGreaterThan("StartDate", ErrorMessageResourceName = "EndDateMustBeGreaterThanStartDate", ErrorMessageResourceType = typeof(AssessmentPeriodResources))]
        public DateTime EndDate { get; set; }

        public string ExamCalendarStatus { get; set; }

        public string Status { get; set; }

        [Display(Name = "Program", ResourceType = typeof(AssessmentPeriodResources))]
        //[Required]
        public int ProgramId { get; set; }

        [Display(Name = "AssessmentComponent", ResourceType = typeof(AssessmentPeriodResources))]
        //[Required]
        public int[] AssessmentComponentId { get; set; }

        public List<string> AssessmentComponentName { get; set; }
        public string ProgramName { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(AppResources))]
        public string Description { get; set; }

        public List<ExamCalendarViewModel> ExamCalendars { get; set; }
        public List<AssessmentPeriodComponent> AssessmentPeriodComponents { get; set; }



    }
}
