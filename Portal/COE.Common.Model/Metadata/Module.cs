using COE.Common.Localization;
using COE.Common.Localization.Security;
using COE.Common.Model.ViewModels.Security;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(ModuleMetadata))]
    public partial class Module : PagedResultBase
    {
        public bool IsSelected { get; set; }
        public virtual List<ModuleAction> ModuleActionList { get; set; } = new List<ModuleAction>();
        public StaticPagedList<Module> Items { get; set; }
        public string SearchName { get; set; }

        class ModuleMetadata
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }

            [Display(Name = "ModuleCategoryID", ResourceType = typeof(SecurityResources))]
            public int ModuleCategoryID { get; set; }
        }
    }
}
