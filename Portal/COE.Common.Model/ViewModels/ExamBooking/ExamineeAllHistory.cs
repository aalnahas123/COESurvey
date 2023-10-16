using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace COE.Common.Model.ViewModels.ExamBooking
{
    public class ExamineeAllHistory
    {
        public ExamineeAllHistory() { }
        public int ID { get; set; }
        [Display(Name = "TraineeName", ResourceType = typeof(ExamBookingResources))]
        public string ExamineeName { get; set; }


        [MaxLength(10, ErrorMessageResourceName = "MaxLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [MinLength(10, ErrorMessageResourceName = "MinLengthNationalId", ErrorMessageResourceType = typeof(SharedResources))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "MustBeNumeric")]
        public string NationalId { get; set; }
        public List<ExamineeBookings> BookingList { get; set; }
        public List<ExamineeNotifications> NotificationList { get; set; }
    }
}
