using PagedList;

namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionEnrollmentUploadAllViewModel
    {
        public StaticPagedList<UploadRequest> Items { get; set; }

        public SectionEnrollmentUploadSearchViewModel SearchModel { get; set; }

    }
}
