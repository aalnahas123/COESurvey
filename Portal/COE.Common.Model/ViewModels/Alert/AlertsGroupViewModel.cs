using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Alert
{
    public class AlertsGroupViewModel
    {
        public int Count { get; set; }
        public List<AlertViewModel> Items { get; set; }
        public AlertTypeViewModel AlertTypeViewModel { get; set; }
        public DateTime AlertDate { get; set; }

        //StageID is added to the whole group to match grouping with Stage, if the most
        //recent item is unread then the whole group should be marked as unread on UI.
        public int StageID { get; set; }
    }
}
