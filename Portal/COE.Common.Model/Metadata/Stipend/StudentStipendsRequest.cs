using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(StudentStipendsRequestMetaData))]
    public partial class StudentStipendsRequest
    {
        public bool Selected { get; set; }
        [Display(Name = "AspNetUsers_NationalId", ResourceType = typeof(MetaData))]
        public string NationalId { get; set; }
  
         public string FullName { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public int CollegeID { get; set; }

        [Display(Name = "AspNetUsers_TVTCNo", ResourceType = typeof(StipendResources))]
        public string TVTCNo { get; set; }

        //public int RequestId { get; set; }
        public int RequestFeedbackId { get; set; }

        class StudentStipendsRequestMetaData
        {
 
        }
    }

}
