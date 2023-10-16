using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class GetExamBookingPaymentInvoice_Result
    {
        //public string QRCode { get; set; }

        public byte[] InvoiceFile { get; set; }
        public int ExambookingId { get; set; }
    }
}
