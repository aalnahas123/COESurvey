using COE.Common.Model.ViewModels.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class MOLDashboardViewModel
    {
        public MOLDashboardViewModel()
        {
            //RequestCountChart = new List<DashboardRequestStatusChartViewModel>();
            //RequestPercentageChart = new List<DashboardRequestPercentageChartViewModel>();
            ApprovedChartData = new List<DashboardDataChartViewModel>();
            NotApprovedChartData = new List<DashboardDataChartViewModel>();
            InProgressChartData = new List<DashboardDataChartViewModel>();
            SentBackToCandidate = new List<DashboardDataChartViewModel>();

        }

        public decimal DraftCount { get; set; }
        public decimal InProgressCount { get; set; }
        public decimal DoneCount { get; set; }
        public RequestSearchViewModel RequestViewModel { get; set; }
        //public List<DashboardRequestStatusChartViewModel> RequestCountChart { get; set; }
        //public List<DashboardRequestPercentageChartViewModel> RequestPercentageChart { get; set; }
        public List<DashboardDataChartViewModel> ApprovedChartData { get; set; }
        public List<DashboardDataChartViewModel> NotApprovedChartData { get; set; }
        public List<DashboardDataChartViewModel> InProgressChartData { get; set; }
        public List<DashboardDataChartViewModel> SentBackToCandidate { get; set; }


    }
}
