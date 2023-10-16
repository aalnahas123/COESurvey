using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class CollegeAcademicYearTermsViewModel
    {
        public int Id { get; set; }
        public int AcademicYearId { get; set; }
        public int TermTypeId { get; set; }
        public int EnrollmentId { get; set; }
        public int TermOrdering { get; set; }
        public int CollegeSpecializationId { get; set; }
        public int CollegeId { get; set; }
        public int SpecializationId { get; set; }
        public string TermName { get; set; }
        public string YearName { get; set; }
        public bool IsIntake { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
