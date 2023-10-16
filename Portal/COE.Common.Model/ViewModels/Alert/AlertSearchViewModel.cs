using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Model;

namespace COE.Common.Model.ViewModels.Alert
{
    public class AlertSearchViewModel: BaseSearchViewModel
    {
        public StaticPagedList<COE.Common.Model.Alert> Items { get; set; }
    }
}
