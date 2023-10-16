using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class DashboardSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "College_SP", ResourceType = typeof(AppResources))]
        public int? CollegeID { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(AppResources))]
        public int? AcademicYearID { get; set; }

        public List<EnrollmentStatusCounts> StatusCounts { get; set; }
        public List<ChartViewModel> StatusChartDataProvider { get; set; } // Bar Chart
        public List<ChartViewModel> ApplicationsDataProvider { get; set; } // PIE Chart
        public List<ChartViewModel> StatusDataProvider { get; set; } // PIE Chart

    }
}
