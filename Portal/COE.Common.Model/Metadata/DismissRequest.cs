using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(DismissRequestMetaData))]
    public partial class DismissRequest : CommonMetaData
    {

        internal class DismissRequestMetaData
        {
            [Display(Name = "DismissRequest_DismissRequestReason", ResourceType = typeof(MetaData))]
            public virtual ICollection<DismissRequestReason> DismissRequestReason { get; set; }

        }
    } 
}

