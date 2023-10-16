using PagedList;

 namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionEnrollmentUploadDetailsViewModel
    {
        public virtual UploadRequest UploadRequest { get; set; }
        public StaticPagedList<SectionEnrollmentValidation> SectionEnrollmentValidations { get; set; }
    }
}
