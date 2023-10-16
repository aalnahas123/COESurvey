using PagedList;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionUploadDetailsViewModel
    {

        public virtual UploadRequest UploadRequest { get; set; }
        public StaticPagedList<SectionValidation> SectionValidations { get; set; }
        public StaticPagedList<SessionValidation> SessionValidations { get; set; }

    }
}
