using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StudentViewModel 
    {
        public Guid ID { get; set; }

        [Display(Name = "AspNetUsers_NationalId", ResourceType = typeof(MetaData))]
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string IBAN { get; set; }

        public string CardNo { get; set; }

        [Display(Name = "AspNetUsers_TVTCNo", ResourceType = typeof(StipendResources))]
        public string TVTCNo { get; set; }

        [Display(Name = "Status_Name", ResourceType = typeof(MetaData))]
        public string Status { get; set; }

        [Display(Name = "RequestDetails_RejectReason", ResourceType = typeof(StipendResources))]
        public string RejectReason { get; set; }
    }
}
