using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StudentStipendViewModel: StudentStipendsRequest
    {
        public string Status { get; set; }
        //public bool Selected { get; set; }
        //public int EnrollmentID { get; set; }

        //[Display(Name = "AspNetUsers_NationalId", ResourceType = typeof(MetaData))]
        //public string NationalId { get; set; }
        //public string FullName { get; set; }

        //public int CollegeID { get; set; }

        //[Display(Name = "AspNetUsers_TVTCNo", ResourceType = typeof(StipendResources))]
        //public string TVTCNo { get; set; }
    }
}
