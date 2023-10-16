using PagedList;
namespace COE.Common.Model.ViewModels.DCS
{
    public class CourseAllViewModel:BaseViewModel
    {        
        public int? CollegeId { get; set; }
        public int? SpecializationId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseLevelId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int PageNumber { get; set; } = 1;
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }        
        public StaticPagedList<CourseAllViewModel> Items { get; set; }
        public CourseSearchViewModel SearchModel { get; set; }
    }
}
