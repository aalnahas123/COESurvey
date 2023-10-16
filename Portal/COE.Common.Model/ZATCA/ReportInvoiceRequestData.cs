using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ZATCA
{
    public class ReportInvoiceRequestData
    {
        public string InvoiceHash { get; set; }
        public string UUID { get; set; }
        public string Invoice { get; set; }
    }
}