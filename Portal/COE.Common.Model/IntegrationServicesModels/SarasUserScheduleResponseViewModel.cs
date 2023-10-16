using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasUserScheduleResponseViewModel
    {
        public int ScheduleID { get; set; }
        public string ScheduleCode { get; set; }

        public List<SarasScheduleUserViewModel> ScheduleUsers { get; set; }

        public string StatusCode { get; set; }

        public string StatusMessage { get; set; }
    }
}
