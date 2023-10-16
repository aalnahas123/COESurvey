using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintRequestActionsViewModel
    {
        public int StatusID { get; set; }
        public long RequestID { get; set; }
        public bool IsStudent { get; set; }
    }
}
