using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.AssessmentPeriod
{
    public class ExamCalendarViewModel : BaseSearchViewModel
    {
        public ExamCalendarViewModel()
        {

        }

        [Required]
        public int[] QualificationsId { get; set; }

        public bool Selected { get; set; }
        public bool OneDayEvent { get; set; }

        public int ID { get; set; }

        [Display(Name = "Qualification", ResourceType = typeof(AssessmentPeriodResources))]
        public int QualificationID { get; set; }
        public int AssessmentPeriodID { get; set; }


        public string QualificationName { get; set; }

        public string FullDate { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(AssessmentPeriodResources))]
        public string StartDateString { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(AssessmentPeriodResources))]
        public string EndDateString { get; set; }

        [Display(Name = "StartTime", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "EndTime", ResourceType = typeof(AssessmentPeriodResources))]
        [Required]
        public TimeSpan EndTime { get; set; }

        public string StartTimeString { get; set; }
        public string EndTimeString { get; set; }
        public int ExamCalenderId { get; set; }


        public int ExamCalendarStatus { get; set; }

        [Display(Name = "IsRequireApproval", ResourceType = typeof(AssessmentPeriodResources))]
        public bool IsRequireApproval { get; set; }
        public string IsRequireApprovalVal { get; set; }

        [Display(Name = "IsFlexibleDateEditing", ResourceType = typeof(AssessmentPeriodResources))]
        public bool IsFlexibleDateEditing { get; set; }
        public string IsFlexibleDateEditingVal { get; set; }

        public string AssessmentComponents { get; set; }

        public string AssessmentComponentName { get; set; }

        [Display(Name = "AssessmentComponent", ResourceType = typeof(AssessmentPeriodResources))]
        public int AssessmentComponentID { get; set; }
        public List<System.Web.Mvc.SelectListItem> AssessmentPeriodComponents { get; set; }

        public AssessmentPeriodViewModel AssessmentPeriod { get; set; }

    }
}
