using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(LevelMetaData))]
    public partial class Level : CommonMetaData
    {
        internal class LevelMetaData
        {

            [Display(Name = "Level_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }
        }
    }
}

