using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(HomePageModuleMetaData))]
    public partial class HomePageModule
    {
        internal class HomePageModuleMetaData
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Icon { get; set; }
        }
    }
}
