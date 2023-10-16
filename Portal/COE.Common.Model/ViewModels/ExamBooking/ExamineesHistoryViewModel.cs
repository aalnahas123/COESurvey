using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.ExamBooking
{
    public class ExamineesHistoryViewModel
    {
        public int ID { get; set; }
        public string ExamineeName { get; set; }
        public string NationalId { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsReScheduled { get; set; }
        public bool IsRefunded { get; set; }
        public bool IsSarasConfirmed { get; set; }
    }
}
