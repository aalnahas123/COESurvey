using PagedList;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionUploadAllViewModel
    {

        public StaticPagedList<UploadRequest> Items { get; set; }

        public SectionUploadSearchViewModel SearchModel { get; set; }
    }
}
