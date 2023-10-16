using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class SelectListItem
    {
        public bool Disabled { get; set; }

        public bool Selected { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }
        public string Code { get; set; }
    }
}
