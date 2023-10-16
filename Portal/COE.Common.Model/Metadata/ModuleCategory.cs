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
    [MetadataType(typeof(ModuleCategoryMetadata))]
    public partial class ModuleCategory
    {
        public bool IsSelected { get; set; }
        public virtual List<Module> ModuleList { get; set; } = new List<Model.Module>();

        class ModuleCategoryMetadata
        {
            [Display(Name = "Name", ResourceType = typeof(SecurityResources))]
            [Required]
            public string Name { get; set; }

            [Display(Name = "Description", ResourceType = typeof(SecurityResources))]
            [Required]
            public string Description { get; set; }


        }
    }
}
