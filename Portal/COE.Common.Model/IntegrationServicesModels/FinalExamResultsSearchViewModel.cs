using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class FinalExamResultsSearchViewModel
    {
        [Display(ResourceType = typeof(EnrollmentResources), Name = "ExamResult_Qualification")]
        public int? QualificationId { get; set; }

        [Display(ResourceType = typeof(EnrollmentResources), Name = "College")]
        public int? CollegeId { get; set; }

        [Display(ResourceType = typeof(EnrollmentResources), Name = "AcademicYear")]
        public int? AcademicYearId { get; set; }

        [Display(ResourceType = typeof(EnrollmentResources), Name = "AcademicTerm")]
        public int? TermId { get; set; }


        [Display(Name = "ExamResult_Qualification", ResourceType = typeof(EnrollmentResources))]
        public string Qualification { get; set; }

        [Display(Name = "ExamResult_OrganizationCode", ResourceType = typeof(EnrollmentResources))]
        public string OrganizationCode { get; set; }

        [Display(Name = "ExamResult_ResultDate", ResourceType = typeof(EnrollmentResources))]
        public DateTime? ResultDate { get; set; } 

        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string LoginName { get; set; }

        [Display(Name = "ExamResult_FromDate", ResourceType = typeof(EnrollmentResources))]
        public DateTime? FromDate { get; set; } = DateTime.Today.AddDays(-30);

        [Display(Name = "ExamResult_DateTo", ResourceType = typeof(EnrollmentResources))]
        public DateTime? ToDate { get; set; } = DateTime.Today;
        public string SelectedNationalIds { get; set; }
    }
}
