using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class PaymentProgress
    {       
        public int ProgressCounter { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public decimal CalculatedAmount { get; set; }
    }
}
