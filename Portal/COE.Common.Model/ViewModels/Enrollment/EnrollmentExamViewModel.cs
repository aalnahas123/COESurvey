using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentExamViewModel
    {
        public string AcademicYearName { get; set; }
        public string TrimesterName { get; set; }
        public string OverAll { get; set; }
        public string Eportfolio { get; set; }
        public string Capstone { get; set; }
        public string CBT { get; set; }
        public int LevelID { get; set; }
    }
}
