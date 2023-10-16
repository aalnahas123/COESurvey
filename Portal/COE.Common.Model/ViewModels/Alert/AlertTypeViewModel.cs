using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Alert
{
    public class AlertTypeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string CssClass { get; set; }
        public bool Clickable { get; set; }
        public string IconClass { get; set; }
        public string Url { get; set; }
    }
}
