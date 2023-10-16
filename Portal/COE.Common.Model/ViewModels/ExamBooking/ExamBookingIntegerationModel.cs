using COE.Common.Localization;
using COE.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Exam.Model.ViewModels
{
    public class ExamBookingIntegerationModel
    {
        public string BookingCode { get; set; }
        public string[] Students { get; set; }
        public DateTime BookingStartDateTime { get; set; }
        public DateTime BookingEndDateTime { get; set; }
        public string CollegeCode { get; set; }
        public string AssessmentPeriodCode { get; set; }
        public DateTime AssessmentPeriodStartDate { get; set; }
        public DateTime AssessmentPeriodEndDate { get; set; }
        public string ProductCode { get; set; }
        public bool IsPractitioner { get; set; }
    }

}
