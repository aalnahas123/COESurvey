using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(StipendFeedbackStatusMetaData))]
    public partial class StipendFeedbackStatus
    {
        class StipendFeedbackStatusMetaData
        {
            [Display(Name = "Common_FeedbackStatus", ResourceType = typeof(StipendResources))]
            public int Name { get; set; }

        }
    }

}
