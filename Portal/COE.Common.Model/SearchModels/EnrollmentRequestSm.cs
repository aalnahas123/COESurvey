using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.SearchModels.Enrollment
{
    public class EnrollmentRequestSm : SearchModel
    {
        public System.Guid UserID { get; set; }
        public int? RequestStageID { get; set; }
        public string RequestNumber { get; set; }

    }
}
