using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasExamResultsSearchViewModel
    {
        //[Display(Name = "ExamResult_Qualification", ResourceType = typeof(EnrollmentResources))]
        //public string Qualification { get; set; }

        //[Display(Name = "ExamResult_OrganizationCode", ResourceType = typeof(EnrollmentResources))]
        //public string OrganizationCode { get; set; }

        [Display(Name = "ExamResult_ExamBookingCode", ResourceType = typeof(EnrollmentResources))]
        public string ScheduleCode { get; set; }

        [Display(Name = "ExamResult_ResultDate", ResourceType = typeof(EnrollmentResources))]
        public DateTime? ResultDate { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string LoginName { get; set; }

        [Display(Name = "ExamResult_FromDate", ResourceType = typeof(EnrollmentResources))]
        public DateTime? FromDate { get; set; } //= DateTime.Today.AddDays(-30);

        [Display(Name = "ExamResult_DateTo", ResourceType = typeof(EnrollmentResources))]
        public DateTime? ToDate { get; set; }// = DateTime.Today;

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamResult_Qualification", ResourceType = typeof(EnrollmentResources))]
        public int? QualificationID { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamResult_QualificationIDs", ResourceType = typeof(EnrollmentResources))]
        public int[] QualificationIDs { get; set; }

        public string Qualifications { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AcademicYear", ResourceType = typeof(EnrollmentResources))]
        public int? AcademicYearID { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AcademicYearTermName", ResourceType = typeof(EnrollmentResources))]
        public int? AcademicYearTermID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamResult_Program", ResourceType = typeof(EnrollmentResources))]
        public int? ProgramID { get; set; } = 1;

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamResult_AssessmentComponent", ResourceType = typeof(EnrollmentResources))]
        public int? AssessmentComponentID { get; set; } = 3;


        [Display(Name = "ExamResult_TestCenterCode", ResourceType = typeof(EnrollmentResources))]
        public string TestCenterCode { get; set; }

        public int? CollegeID { get; set; }
    }
}
