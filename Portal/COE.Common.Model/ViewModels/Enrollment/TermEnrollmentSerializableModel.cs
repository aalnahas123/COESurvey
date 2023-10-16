using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    [Serializable]
    public class TermEnrollmentSerializableModel
    {
        public int TermEnrollmentId { get; set; }
        public int EnrollmentId { get; set; }
        public int AcademicYearTermId { get; set; }
        public int CollegeSpecializationId { get; set; }
        public int StageId { get; set; }
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public string StageName { get; set; }
    }
}
