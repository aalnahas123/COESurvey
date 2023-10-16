using System;
using System.Collections.Generic;
namespace COE.Common.Model.ViewModels.DCS
{
    public class UploadViewModel :BaseViewModel
    {
        public int UploadRequestId { get; set; }
        public int StartProgress { get; set; }
        public int RequestTypeId { get; set; }
        public Guid? AttachmentID { get; set; }
        public int AttachmentSizeInMB => 5;
        public string AllowedExtension => "csv";

        public List<LookupViewModel> ProvidersList { get; set; }
        public List<LookupViewModel> CollegesList { get; set; }
        public List<ExtendedLookupViewModel> AcademicYearsList { get; set; }
        public List<LookupViewModel> TermsList { get; set; }

        public bool IsStartProgress { get; set; }
        public bool IsErrorHappenedWhileSave { get; set; }
        public bool IsAttachmentFileIsNullOrEmpty { get; set; }

    }
}
