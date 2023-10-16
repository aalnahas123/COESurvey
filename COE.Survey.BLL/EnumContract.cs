using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.ContractManagement.BLL.Enums
{
    public class EnumContract
    {
        public enum DublicationResult
        {
            CollegeDublicated = 0,
            CollegeContactDetailDublicated = 1,
            CollegeRepresentiveDetailDublicated = 2
        }
        public enum ValidationStatus
        {
            RelatedActiveContract = 3,
            RelatedEnrolledStudents = 4
        }
    }
}
