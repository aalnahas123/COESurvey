using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ProgramDashboardViewModel
    {
        public List<EnrollmentStatusCounts> StatusCounts { get; set; }
        public List<ChartViewModel> StatusChartDataProvider { get; set; } // Bar Chart
        public List<ChartViewModel> ApplicationsDataProvider { get; set; } // PIE Chart
        public List<ChartViewModel> StatusDataProvider { get; set; } // PIE Chart
    }
}
