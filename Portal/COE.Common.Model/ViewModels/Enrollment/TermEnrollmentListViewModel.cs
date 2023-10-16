using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentListViewModel
    {
        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public int AcademicYearTermID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int StageID { get; set; }
        public bool IsIntake { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string StageName { get; set; }
        public string AcademicYearName { get; set; }
        public string AcademicYearTermName { get; set; }
        public string IntakeTerm { get; set; }
        public int CollegeID { get; set; }
        public int CollegeTypeID { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string MobileNumber { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public bool IsMale { get; set; }
    }
}
