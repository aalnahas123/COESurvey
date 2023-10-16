using PagedList;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionEnrollmentAllViewModel:BaseViewModel
    {
        public string StudentName { get; set; }
        public string NationalID { get; set; }
        public bool IsRepeated { get; set; }
        public string SectionCode { get; set; }
        public string CourseCode { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }        
        public string AcademicYear { get; set; }
        public string AcademicYearTerm { get; set; }
        
        public StaticPagedList<SectionEnrollmentAllViewModel> Items { get; set; }
        public SectionEnrollmentSearchViewModel SearchModel { get; set; }

        public double RepeatedCounter { get; set; }
        public double EnrolledCounter { get; set; }
        public int RepeatedPercentage { get; set; }
        public int EnrolledPercentage { get; set; }

        public int PageNumber { get; set; } = 1;
    }
}
