using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentAttendanceViewModel
    {
        public int AcademicYearId { get; set; }
        public string Name { get; set; }
        public string TermName { get; set; }
        public int SectionID { get; set; }
        public string SectionCode { get; set; }
        public int EnrollmentID { get; set; }
        public int SectionEnrollmentID { get; set; }
        public decimal Attended { get; set; }
        public decimal Excused { get; set; }
        public decimal Extra { get; set; }
        public int OJT { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal OfferedHours { get; set; }
        public string MonthNo { get; set; }

    }
}
