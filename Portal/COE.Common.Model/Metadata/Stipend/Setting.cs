using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public class Setting
    {
        //[Display(Name = "Key", ResourceType = typeof(StipendResources))]
        public string Key { get; set; }

        //[Display(Name = "Value", ResourceType = typeof(StipendResources))]
        public string Value { get; set; }
    }
}
