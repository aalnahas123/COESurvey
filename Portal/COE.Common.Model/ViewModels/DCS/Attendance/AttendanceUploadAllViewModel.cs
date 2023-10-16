using PagedList;

namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceUploadAllViewModel
    {
        public StaticPagedList<UploadRequest> Items { get; set; }

        public AttendanceUploadSearchViewModel SearchModel { get; set; }
    }
}
