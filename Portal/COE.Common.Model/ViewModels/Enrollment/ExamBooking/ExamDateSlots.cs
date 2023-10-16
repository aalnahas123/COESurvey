using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ExamDateSlots
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }

    }
}
