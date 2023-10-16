using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class SeriesAttendanceChartViewModel
    {
        public string name { get; set; }
        public string type { get; set; }
        public decimal[] data { get; set; }
        public object itemStyle { get; set; }
        public object markLine { get; set; }

    }
}
