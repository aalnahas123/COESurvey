using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.SearchModels.Enrollment
{
    public class EnrollmentSm : SearchModel
    {

        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string RequestNumber { get; set; }
        public string NationalId { get; set; }
        public int? RequestStageId { get; set; }
        public int? EnrollmentStageId { get; set; }
        public int? CollegeId { get; set; }
        public int? SpecializationId { get; set; }

    }
}
