using COE.Common.Localization;
using COE.Common.Localization.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(ModuleActionMetadata))]
    public partial class ModuleAction
    {
        public bool IsSelected { get; set; }
        class ModuleActionMetadata
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }

            [Display(Name = "ModuleName", ResourceType = typeof(SecurityResources))]
            public int ModuleID { get; set; }

            [Display(Name = "ActionName", ResourceType = typeof(SecurityResources))]
            public int ActionID { get; set; }

        }
    }
}
