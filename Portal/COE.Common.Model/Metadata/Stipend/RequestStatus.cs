using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(RequestStatusMetaData))]
    public partial class RequestStatus
    {
        class RequestStatusMetaData
        {
            [Display(Name = "Common_RequestStatus", ResourceType = typeof(StipendResources))]
            public int Name { get; set; }

        }
    }

}
