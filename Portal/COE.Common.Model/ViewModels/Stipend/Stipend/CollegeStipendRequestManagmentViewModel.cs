using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CollegeStipendRequestManagmentViewModel
    {
        public int CollegeID { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public string CollegeName { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfStudents", ResourceType = typeof(StipendResources))]
        public int NoOfStudents { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentInRequest", ResourceType = typeof(StipendResources))]
        public int NoOfStudentInRequest { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentsHasStipend", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsHasStipend { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentsHasNoStipend", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsHasNoStipend { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentsPending", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsPending { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentsRejected", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsRejected { get; set; }

        [Display(Name = "StipendRequestManagement_NoOfStudentNew", ResourceType = typeof(StipendResources))]
        public int NoOfStudentNew { get; set; }
    }
}
