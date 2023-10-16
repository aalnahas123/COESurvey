using PagedList;
using System;

namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionAllViewModel : BaseViewModel
    {        
        public string CourseCode { get; set; }
        public string CourseName { get; set; }        
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string SectionCode { get; set; }
        public string AcademicYear { get; set; }
        public string AcademicYearTerm { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalHours { get; set; }
        public StaticPagedList<SectionAllViewModel> Items { get; set; }
        public SectionSearchViewModel SearchModel { get; set; }

        public int PageNumber { get; set; } = 1;
    }
}
