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
    [MetadataType(typeof(AspNetRolesMetadata))]
    public partial class AspNetRoles : PagedResultBase
    {
        public bool IsSelected { get; set; }
        public StaticPagedList<AspNetRoles> Items { get; set; }
        public Guid[] Roles { get; set; }

        class AspNetRolesMetadata
        {
            [Display(Name = "Name", ResourceType = typeof(SecurityResources))]
            [Required]
            public string Name { get; set; }

            [Display(Name = "Code", ResourceType = typeof(SecurityResources))]
            [Required]
            public string Priority { get; set; }

        }
    }
}
