using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class RequestAttachmentViewModel 
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public Guid AttachmentId { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
