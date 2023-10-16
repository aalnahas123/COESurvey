using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ZATCA
{
    public class ReportInvoiceData
    {
        public string InvoiceId { get; set; }
        public string UUID { get; set; }
        public string IssueDate { get; set; }
        public string IssueTime { get; set; }
        public string ICV { get; set; }
        public string PIH { get; set; }
        public string ServiceName { get; set; }
        public bool IsCreaditNote { get; set; }
        public string BaseInvoiceId { get; set; }
        public string BaseInvoiceDate { get; set; }
    }
}