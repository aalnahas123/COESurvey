using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class OJTEditBatchViewModel
    {
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public string College { get; set; }
        public string CollegeAr { get; set; }
        public int ID { get; set; }
        public System.Guid UserID { get; set; }
        public bool IsCompleteAssociateOJT { get; set; }
        public bool IsCompleteDiplomaOJT { get; set; }

        //public bool IsCompleteAssociate { get; set; }
        //public bool IsCompleteDiploma { get; set; }

    }
}
