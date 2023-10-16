using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasExamBookingListViewModel
    {
        public IEnumerable<SarasExamBookingViewModel> AvailableSlots { get; set; }
        public bool IsUnavailableCity { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }
}