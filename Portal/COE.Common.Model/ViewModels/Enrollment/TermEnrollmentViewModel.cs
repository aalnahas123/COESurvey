using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentViewModel : BaseViewModel
    {
        //public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public int AcademicYearTermId { get; set; }
        public int CurrentCollegeAcademicYearTermId { get; set; }
        public int CollegeSpecializationId { get; set; }
        public int StageId { get; set; }
        public bool IsIntake { get; set; }
        public string IntakeTerm { get; set; }

        // Custom properties
        public string AcademicYearTermName { get; set; }
        public int CollegeId { get; set; }
        public int SpecializationId { get; set; }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }

        public string AcademicYearName { get; set; }
        public string TermTypeName { get; set; }
        public string TermName { get; set; }
        public int TermOrdering { get; set; }

        public string StageName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public EnrollmentViewModel EnrollmentViewModel { get; set; }

        // This property for batch editing new status
        public int ChangeStatusNewStatusId { get; set; } = 0;
    }
}
