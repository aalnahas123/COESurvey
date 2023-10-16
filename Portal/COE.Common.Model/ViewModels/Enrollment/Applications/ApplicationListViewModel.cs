using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ApplicationListViewModel
    {
        // for list
        public int ID { get; set; }
        public int Priority { get; set; }
        public int StageId { get; set; }
        public int StatusID { get; set; }
        public int AcademicYearTermId { get; set; }
        public int CollegeSponserID { get; set; }

        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public DateTime CreatedOn { get; set; }

        // for action
        public int CollegeID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int EnrollmentRequestID { get; set; }
        public int StudentProfileID { get; set; }

        //public int BatchID { get; set; }
        //public int EnrollmentRequestDetailStatusID { get; set; }
        //public int EnrollmentRequestStageID { get; set; }
        //public string LoginName { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
        //public Guid UserID { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public DateTime UpdatedOn { get; set; }
        //public DateTime? AdmissionStartDate { get; set; }
        //public DateTime? AdmissionEndDate { get; set; }
    }
}
