using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StipendRequestManagmentViewModel : PagedResultBase
    {
        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public int? HijriYear { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public int StipendMonth { get; set; }

        public List<CollegeStipendRequestManagmentViewModel> Items { get; set; }

        public int TotalItemCount { get; set; }
    }
}
