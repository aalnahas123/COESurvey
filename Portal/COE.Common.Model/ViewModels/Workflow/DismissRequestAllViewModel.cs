using PagedList;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class DismissRequestAllViewModel
    {
        public StaticPagedList<DismissRequest> Items { get; set; }

        public DismissRequestSearchViewModel SearchModel { get; set; }
    }
}
