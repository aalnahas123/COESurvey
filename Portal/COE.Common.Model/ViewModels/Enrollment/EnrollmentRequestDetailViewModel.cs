using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentRequestDetailViewModel : BaseViewModel 
    {
        public int EnrollmentRequestId { get; set; }
        public int CollegeSpecializationId { get; set; }
        public int CollegeId { get; set; }
        public int SpecializationId { get; set; }
        public int Priority { get; set; }
        public int StageId { get; set; }

        // Custom properties
        /*
        public int FirstCollegeId { get; set; }
        public int FirstSpecializationId { get; set; }

        public int SecondCollegeId { get; set; }
        public int SecondSpecializationId { get; set; }

        public int ThirdCollegeId { get; set; }
        public int ThirdSpecializationId { get; set; }
        */

        public string SatgeName { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string RequestNumber { get; set; }

    }
}
