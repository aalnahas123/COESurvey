using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentEnglishExamViewModel
    {
        public string AcademicYearName { get; set; }
        public string TrimesterName { get; set; }
        public int CandidateNo { get; set; }
        public string Status { get; set; }
        public string Score { get; set; }
        public decimal StudentActualMark { get; set; }
    }
}
