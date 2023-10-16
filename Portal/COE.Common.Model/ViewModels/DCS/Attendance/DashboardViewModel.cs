using PagedList;
using System;
using System.Collections.Generic;

namespace COE.Common.Model.ViewModels.DCS
{
    public class DashboardViewModel : BaseViewModel
    {
        public string NationalID { get; set; }
        public string SectionCode { get; set; }
        public string CourseCode { get; set; }
        public string CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string AcademicYear { get; set; }
        public string AcademicYearTerm { get; set; }
        public decimal AttendedHours { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public double RecordedAttendancePercent { get; set; }
        public string StudentsAttendanceGraph { get; set; }
        public string TeachersPerformanceGraph { get; set; }


        public string NumberAllStudents { get; set; }
        public string NumberAttended { get; set; }
        public string NumberAbsent { get; set; }
        public string NumberExecusedAbsent { get; set; }

        public List<LookupViewModel> CollegesList { get; set; }
        public List<GetTeacherLectures_Result> Lectures { get; set; }

    }

    
}
