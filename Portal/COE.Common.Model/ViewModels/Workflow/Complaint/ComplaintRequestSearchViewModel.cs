using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintRequestSearchViewModel
    {
        public int ProgramID { get; set; }
        public string UserName { get; set; }
        public bool IsStudent { get; set; }

        [Display(Name = "ComplaintNumber", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintNumber { get; set; }

        [Display(Name = "ComplaintParentType", ResourceType = typeof(ComplaintRequestResource))]
        public int? ComplaintParentTypeID { get; set; }

        [Display(Name = "ComplaintType", ResourceType = typeof(ComplaintRequestResource))]
        public int? ComplaintTypeID { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(AppResources))]
        public string NationalId { get; set; }

        [Display(Name = "College", ResourceType = typeof(AppResources))]
        public int? CollegeID { get; set; }
    }
}
