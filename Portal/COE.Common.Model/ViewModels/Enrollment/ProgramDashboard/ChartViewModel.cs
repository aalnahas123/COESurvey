using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ChartViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Value { get; set; }
        public string Color { get; set; }
    }
}
