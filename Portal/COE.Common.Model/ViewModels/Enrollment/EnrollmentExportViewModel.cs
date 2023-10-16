using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentExportViewModel
    {
        public EnrollmentExportViewModel()
        {
        }
        public string StudentName { get; set; }

        public string NationalID { get; set; }

        public string StageName { get; set; }

        public string CollegeName { get; set; }

        public string SpecializationName { get; set; }
        public string IntakeTerm { get; set; }

        public System.DateTime CreatedOn { get; set; }
    }
}
