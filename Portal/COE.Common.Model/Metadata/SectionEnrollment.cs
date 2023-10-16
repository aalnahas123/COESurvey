using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class SectionEnrollment
    {       
        public string ViewStatus { get; set; }
        public string ExamStatus { get; set; }
        public int Atttemps { get; set; }
        public string LevelTerm { get; set; }
        public string EnglishExamScore { get; set; }
        public string AssociateExamScore { get; set; }       
    }
}
