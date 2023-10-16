using PagedList;
using System;
namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceAllViewModel:BaseViewModel
    {       
        public string NationalID { get; set; }        
        public string SectionCode { get; set; }
        public string CourseCode { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string AcademicYear { get; set; }
        public string AcademicYearTerm { get; set; }
        public decimal AttendedHours { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public StaticPagedList<AttendanceAllViewModel> Items { get; set; }
        public AttendanceSearchViewModel SearchModel { get; set; }

        public int PageNumber { get; set; } = 1;
        public string CourseLevel { get; set; }
    }
}
