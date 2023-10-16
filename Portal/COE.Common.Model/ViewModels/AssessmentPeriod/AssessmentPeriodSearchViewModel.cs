using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.AssessmentPeriod
{
    public class AssessmentPeriodSearchViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Program", ResourceType = typeof(AssessmentPeriodResources))]
        public int Programs { get; set; }

        [Display(Name = "Qualification", ResourceType = typeof(AssessmentPeriodResources))]
        public int Qualifications { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public int Colleges { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(AssessmentPeriodResources))]
        public string AcademicYear { get; set; }

        [Display(Name = "AcademicTerm", ResourceType = typeof(AssessmentPeriodResources))]
        public int AcademicTerm { get; set; }

        [Display(Name = "AssessmentType", ResourceType = typeof(AssessmentPeriodResources))]
        public int[] AssessmentType { get; set; }

        [Display(Name = "AssessmentStatus", ResourceType = typeof(AssessmentPeriodResources))]
        public int[] AssessmentStatus { get; set; }

        [Display(Name = "AssessmentPeriodCode", ResourceType = typeof(AssessmentPeriodResources))]
        public string AssessmentCode { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DateString { get; set; }

        public string ExamCalendarStatus { get; set; }
        public string Status { get; set; }


        public int ProgramId { get; set; }
        public int AssessmentComponentId { get; set; }

        public string AssessmentComponentName { get; set; }
        public string ProgramName { get; set; }
        public int AssessmentPeriodStatusID { get; set; }
        public string AssessmentPeriodStatus{ get; set; }
        public bool ExamCalendarRequestStatus { get; set; }

        public string Description { get; set; }
    }
}
