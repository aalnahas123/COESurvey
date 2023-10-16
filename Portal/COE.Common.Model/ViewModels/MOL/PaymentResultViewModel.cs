using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.MOL
{
    public class PaymentResultViewModel
    {
        public string PaymentId { get; set; }
        public string TranId { get; set; }
        public string ECI { get; set; }
        public string AuthCode { get; set; }

        public string ResponseCode { get; set; }
        public string RRN { get; set; }
        public string Result { get; set; }
        public string TrackId { get; set; }
        public string ResponseHash { get; set; }
        public string Amount { get; set; }
        public string CardBrand { get; set; }
        public string UserField1 { get; set; }
        public string UserField2 { get; set; }
        public string UserField3 { get; set; }
        public string UserField4 { get; set; }
        public string UserField5 { get; set; }
        public string UserField6 { get; set; }
        public string MaskedPAN { get; set; }
        public bool IsRefund { get; set; }
        public DateTime? TranDate { get; set; }
    }
}
