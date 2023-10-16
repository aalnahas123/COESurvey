using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintRequestDetailsViewModel
    {
        public Request Request { get; set; }
        public ComplaintRequestViewModel ComplaintRequest { get; set; }
        public List<RequestActionViewModel> RequestActions { get; set; }
        public DecisionViewModel Decision { get; set; }
    }
}
