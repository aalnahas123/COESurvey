using PagedList;

namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceUploadDetailsViewModel
    {
        public virtual UploadRequest UploadRequest { get; set; }
        public StaticPagedList<SectionEnrollmentAttendanceValidation> SectionEnrollmentAttendanceValidations { get; set; }
    }
}
