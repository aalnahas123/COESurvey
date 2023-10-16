using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class UploadFeedbackBase
    {
        public bool IsStartProgress { get; set; }
        public bool IsErrorHappenedWhileSave { get; set; }
        public bool IsAttachmentFileIsNullOrEmpty { get; set; }
        public int UploadRequestId { get; set; }
    }
}
