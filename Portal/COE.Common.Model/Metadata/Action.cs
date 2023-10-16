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
    [MetadataType(typeof(ActionMetadata))]
    public partial class Action : PagedResultBase
    {
        public bool IsSelected { get; set; }

        public StaticPagedList<Action> Items { get; set; }
        public string SearchName { get; set; }
        class ActionMetadata
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }
        }
    }
}
