using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintRequestListViewModel
    {
        public int ID { get; set; }
        public long RequestID { get; set; }
        public int StatusID { get; set; }

        [Display(Name = "ComplaintNumber", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintNumber { get; set; }

        [Display(Name = "ComplaintDate", ResourceType = typeof(ComplaintRequestResource))]
        public DateTime ComplaintDate { get; set; }

        [Display(Name = "ComplaintStage", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintStage { get; set; }

        [Display(Name = "ComplaintParentType", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintParentTypeName { get; set; }

        [Display(Name = "ComplaintType", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintTypeName { get; set; }

        [Display(Name = "StudentName", ResourceType = typeof(AppResources))]
        public string FullName { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        public string NationalId { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public string CollegeName { get; set; }
    }
}
