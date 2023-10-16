using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasUserScheduleRequestViewModel
    {
        public string ScheduleCode { get; set; }
        public string[] UserCode { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartDateTime { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndDateTime { get; set; }

        public string AssessmentCode { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime AssessmentPeriodStartDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime AssessmentPeriodEndDate { get; set; }

        public string OrganizationCode { get; set; }

        public string ProductCode { get; set; }
    }

    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        }
    }
}
