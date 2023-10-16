using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ZATCA
{
    public class ReportInvoiceResponsetData
    {

        public bool IsReported => string.Equals(ReportingStatus, "REPORTED");
        public string ReportingStatus { get; set; }
        public ValidationResult ValidationResults { get; set; }
        public string QR { get; set; }
        public string InvoiceHash { get; set; }
        public byte[] SignedXMLBytes { get; set; }
    }

    public class ValidationResult
    {
        public bool IsSuccess => string.Equals(Status, "PASS") && !ErrorMessages.Any() && !WarningMessages.Any();
        public string Status { get; set; }
        public List<MessageBase> InfoMessages { get; set; }
        public List<MessageBase> WarningMessages { get; set; }
        public List<MessageBase> ErrorMessages { get; set; }
    }

    public class MessageBase
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}