using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentHistoryViewModel
    {
        public bool IsIntake { get; set; }
        public string AcademicYear { get; set; }
        public string Trimester { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string StageName { get; set; }
        public string LevelName { get; set; }

    }
}
