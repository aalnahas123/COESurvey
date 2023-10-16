using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class SectionEnrollmentAttendanceViewModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public decimal? ActualyAttenedHours { get; set; }
        public string SectionCode { get; set; }
        public decimal OfferedHours { get; set; }
        public decimal TotalHours { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public string YearName { get; set; }
        public string TermName { get; set; }
        public decimal? AttendancePercentage { get; set; }
        public string MonthName { get; set; }
        public string SectionMonthName { get; set; }

    }
}
