using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasExamBookingResponseViewModel
    {
        public string ScheduleUserID { get; set; }
        public string ScheduleID { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public string HttpStatus { get; set; }
        public bool IsSuccessided => string.Equals(StatusCode.ToUpper(), StatusCodes.SH001);
    }

    enum StatusCodes
    {
        SH001
    }
}
