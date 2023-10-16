using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasExamResultsViewModel
    {
        [Display(Name = "ExamResult_AssessmentCode", ResourceType = typeof(EnrollmentResources))]
        public string AssessmentCode { get; set; }

        [Display(Name = "ExamResult_Qualification", ResourceType = typeof(EnrollmentResources))]
        public string Qualification { get; set; }

        [Display(Name = "ExamResult_Qualification", ResourceType = typeof(EnrollmentResources))]
        public string QualificationName { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string NationalID { get; set; }

        [Display(Name = "ExamResult_TestDate", ResourceType = typeof(EnrollmentResources))]
        public DateTime? TestCompletedDate { get; set; }

        public double? AssessmentScore { get; set; }

        [Display(Name = "ExamResult_TotalScore", ResourceType = typeof(EnrollmentResources))]
        public double? TotalScore { get; set; }

        [Display(Name = "ExamResult_Percentage", ResourceType = typeof(EnrollmentResources))]
        public double? Percentage { get; set; }

        [Display(Name = "ExamResult_ResultStatus", ResourceType = typeof(EnrollmentResources))]
        public string ResultStatus { get; set; }

        [Display(Name = "ExamResult_Grade", ResourceType = typeof(EnrollmentResources))]
        public string Grade { get; set; }
        [Display(Name = "ExamResult_AssessmentType", ResourceType = typeof(EnrollmentResources))]
        public string AssessmentType { get; set; }

        [Display(Name = "ExamResult_AssessmentSubType", ResourceType = typeof(EnrollmentResources))]
        public string AssessmentSubType { get; set; }

        public int ScheduleUserId { get; set; }

        [Display(Name = "ExamResult_ScheduleCode", ResourceType = typeof(EnrollmentResources))]
        public string ScheduleCode { get; set; } // Assessment Period Code at Booking Module


        // [Display(Name = "ExamResult_TestCenterCode", ResourceType = typeof(EnrollmentResources))]
        // public string TestCenterCode { get; set; }

        public string Program { get; set; } = "ITC";
        public string AssessmentComponent { get; set; } = "CBT";
        public int AcademicYearTermId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(AppResources))]
        public string TraineeName { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public string TraineeCollege { get; set; }

        public double? EportfolioScore { get; set; }
    }
}
