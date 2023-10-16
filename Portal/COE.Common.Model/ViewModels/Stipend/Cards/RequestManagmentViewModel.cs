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
    public class RequestManagmentViewModel : PagedResultBase
    {

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public int? CollegeId { get; set; }

        public StaticPagedList<CollegeCardRequestManagmentViewModel> Items { get; set; }

        public int TotalItemCount { get; set; }
    
    }
}
