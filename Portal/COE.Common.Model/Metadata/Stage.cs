using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model
{
    [MetadataType(typeof(StageMetaData))]
    public partial class Stage : CommonMetaData
    {
        internal class StageMetaData
        {
            [Display(Name = "Stage_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }

            [Display(Name = "Stage_NameAr", ResourceType = typeof(MetaData))]
            public string NameAr { get; set; }
        }
    }
}