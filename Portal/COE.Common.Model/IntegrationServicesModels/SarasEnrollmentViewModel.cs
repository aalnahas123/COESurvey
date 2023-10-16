using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasEnrollmentViewModel
    {
        public string NationalID { get; set; }
        public string ProductCode { get; set; }
        public string CohortName { get; set; }
        public string CohortCode { get; set; }
        public DateTime CohortDate { get; set; }
        public DateTime IntakeStartDate { get; set; }
        public string IntakeName { get; set; }
    }
}
