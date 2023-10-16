using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentHistoryViewModel
    {
        public EnrollmentHistoryViewModel()
        {
            // History
            Foundation = new List<TermEnrollmentViewModel>();
            Diploma = new List<TermEnrollmentViewModel>();
            AssociateDiploma = new List<TermEnrollmentViewModel>();
            //Academic = new List<TermEnrollmentViewModel>();
            // Exams
            FoundationEnglishExamList = new List<EnrollmentEnglishExamViewModel>();
            AssociateDiplomaExamList = new List<EnrollmentExamViewModel>();
            DiplomaExamList = new List<EnrollmentExamViewModel>();
        }
        public List<TermEnrollmentViewModel> Foundation { get; set; }
        public List<EnrollmentEnglishExamViewModel> FoundationEnglishExamList { get; set; }

        public List<TermEnrollmentViewModel> Diploma { get; set; }
        public List<EnrollmentExamViewModel> DiplomaExamList { get; set; }

        public List<TermEnrollmentViewModel> AssociateDiploma { get; set; }
        public List<EnrollmentExamViewModel> AssociateDiplomaExamList { get; set; }

    }
}
