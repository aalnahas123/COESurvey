using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(StipendPaymentMethodMetaData))]
    public partial class StipendPaymentMethod
    {
        class StipendPaymentMethodMetaData
        {
            [Display(Name = "Stipend_PaymentMethod", ResourceType = typeof(StipendResources))]
            public int Name { get; set; }

        }
    }

}
