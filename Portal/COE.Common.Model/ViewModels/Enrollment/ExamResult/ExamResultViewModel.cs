using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment.ExamResult
{
    public class ExamResultViewModel
    {
        public int ID { get; set; }
        public string NationalID { get; set; }
        public int EnrollmentID { get; set; }
        public string Code { get; set; }
        public int AssessmentComponentID { get; set; }
    }
}
