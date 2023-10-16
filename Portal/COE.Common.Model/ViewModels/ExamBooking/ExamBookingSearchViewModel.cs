using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Exam.Model.ViewModels
{
    public class BulkInvoicesViewModel
    {
        [Display(ResourceType = typeof(ExamBookingResources), Name = "InvoiceType")]
        public int? InvoiceType { get; set; }

        [Display(Name = "DateFrom", ResourceType = typeof(SharedResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(SharedResources))]
        public DateTime? DateTo { get; set; }
    }
}