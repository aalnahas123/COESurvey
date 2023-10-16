using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentViewModel : BaseViewModel
    {

        public EnrollmentViewModel()
        {
        }

        public int CollegeSpecializationId { get; set; }
        public int EnrollmentRequestId { get; set; }
        [Display(Name = "Stage", ResourceType = typeof(EnrollmentResources))]
        public int? StageId { get; set; }
        public int? BatchID;
        public EnrollmentRequestViewModel EnrollmentRequest { get; set; }


        // Custom properties
        public string StageName { get; set; }
        public int? CollegeID { get; set; }
        public string CollegeName { get; set; }
        public int CollegeTypeId { get; set; }
        public int? SpecializationID { get; set; }
        public string SpecializationName { get; set; }
        public string RowClass { get; set; }

        // Data from EnrollmentRequestDetail
        public int RequestDetailStageId { get; set; }
        public string RequestDetailSatgeName { get; set; }
        public int RequestDetailCollegeSpecializationId { get; set; }

        // Status Counts
        public List<LookupViewModel> StatusCountList { get; set; }
       
        // Term Enrollment Properties     
        public string AcademicYearName { get; set; }
        public string AcademicYearTermName { get; set; }
        public int StatusID { get; set; }

        // For Applications Batch Editing Enroll Term
        public int? AcademicYearTermId { get; set; }

        public int Priority { get; set; }
    }
}
