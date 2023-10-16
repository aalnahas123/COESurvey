using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization;
using COE.Common.Model;
using COE.Common.Model.IntegrationServicesModels;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ExamDate
    {
        public ExamDate()
        {
            AvailableSlots = new List<ExamDateSlots>();
            Sessions = new SarasExamBookingListViewModel();
        }
        [Display(Name = "ExamName", ResourceType = typeof(ExamBookingResources))]
        public string ExameCode { get; set; }

        public string ExameName { get; set; }

        //[Display(Name = "Qualification", ResourceType = typeof(ExamBookingResources))]
        //public string Qualification { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamDate", ResourceType = typeof(ExamBookingResources))]
        public DateTime ExameDate { get; set; }

        //public int QualificationCode { get; set; }

        [Display(Name = "ExameCenterName", ResourceType = typeof(ExamBookingResources))]
        public string ExameCenterName { get; set; }
        [Display(Name = "ExamCity", ResourceType = typeof(ExamBookingResources))]
        public string ExamCity { get; set; }

        [Display(Name = "ExameCenterLocationUrl", ResourceType = typeof(ExamBookingResources))]
        public string ExameCenterLocationUrl { get; set; }

        //public Model.Enrollment Enrollment { get; set; }
        public List<ExamDateSlots> AvailableSlots { get; set; }

        public SarasExamBookingListViewModel Sessions { get; set; }

        public string PaymentMessage { get; set; }

        public string PaymentUrl { get; set; }

        public double ExamFees { get; set; }
        public string TrackId { get; set; }

        public int ExamBookingId { get; set; }

        public string PaymentResultURL { get; set; }


        public List<SelectListItem> AvailableCities { get; set; }
        public bool IsMultiLevel { get; set; }
        [Display(Name = "Qualification", ResourceType = typeof(ExamBookingResources))]
        public string QualificationCode { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
