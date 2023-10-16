using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentEditBatchViewModel
    {
        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public int AcademicYearTermID { get; set; }
        public string AcademicYearTermName { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public int LevelID { get; set; }
        public int StageID { get; set; }
        public int CollegeID { get; set; }
        public int SpecializationID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int CollegeSponsorID { get; set; } = 0;
        public bool CanChangeSpecialization { get; set; } = true;

    }


}
