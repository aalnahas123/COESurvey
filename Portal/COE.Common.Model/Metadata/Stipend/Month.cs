using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(MonthMetaData))]
    public partial class Month
    {
        class MonthMetaData
        {
            [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
            public int Name { get; set; }

        }
    }

}
