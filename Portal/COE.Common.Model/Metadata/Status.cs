using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(StatusMetaData))]
    public partial class Status : CommonMetaData
    {
        internal class StatusMetaData
        {
            [Display(Name = "Status_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }

        }
    }
}