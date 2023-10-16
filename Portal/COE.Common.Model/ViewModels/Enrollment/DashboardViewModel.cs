using COE.Common.Model.ViewModels.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            RequestCountChart = new List<DashboardRequestStatusChartViewModel>();
            RequestPercentageChart = new List<DashboardRequestPercentageChartViewModel>();
            EnrollmentRequestPercentageChart = new List<DashboardEnrollmentRequestPercentageChartViewModel>();
        }
        
        public decimal DeferralRequestInprogressCount { get; set; }
        public decimal DeferralRequestCount { get; set; }
        public decimal DismissRequestInprogressCount { get; set; }
        public decimal DismissRequestCount { get; set; }
        public decimal TransferRequestInprogressCount { get; set; }
        public decimal TransferRequestCount { get; set; }
        public decimal WithdrawRequestInprogressCount { get; set; }
        public decimal WithdrawRequestCount { get; set; }
        public RequestSearchViewModel RequestViewModel { get; set; }
        public List<DashboardRequestStatusChartViewModel> RequestCountChart { get; set; }
        public List<DashboardRequestPercentageChartViewModel> RequestPercentageChart { get; set; }
        public List<DashboardEnrollmentRequestPercentageChartViewModel> EnrollmentRequestPercentageChart { get; set; }

    }
}
