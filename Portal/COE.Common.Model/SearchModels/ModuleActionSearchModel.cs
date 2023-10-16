using COE.Common.Localization;
using COE.Common.Localization.Security;
using COE.Common.Model.ViewModels.Security;
using PagedList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.SearchModels.ModuleAction
{
    public class ModuleActionSearchModel : PagedResultBase
    {
        [Display(Name = "Name", ResourceType = typeof(SecurityResources))]
        public string Name { get; set; }

        [Display(Name = "ModuleName", ResourceType = typeof(SecurityResources))]
        public int? ModuleID { get; set; }
        public StaticPagedList<Model.ModuleAction> Items { get; set; }
 
    }
}
