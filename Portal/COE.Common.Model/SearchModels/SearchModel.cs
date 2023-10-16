using COE.Common.Model.ViewModels.Enrollment;
using PagedList;

namespace COE.Common.Model.SearchModels.Enrollment
{
    public class SearchModel
    {
        public string UserName { get; set; }
        public StaticPagedList<EnrollmentViewModel> Items { get; set; }
        /// <summary>
        ///     Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        ///     Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

    }
}
