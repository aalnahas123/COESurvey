using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CollegeCardRequestManagmentViewModel
    {
        public int CollegeID { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public string CollegeName { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfStudents", ResourceType = typeof(StipendResources))]
        public int  NoOfStudents { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfStudentsHasCards", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsHasCards { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfStudentsHasNoCards", ResourceType = typeof(StipendResources))]
        public int NoOfStudentsHasNoCards { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfIntakeStudents", ResourceType = typeof(StipendResources))]
        public int NoOfIntakeStudents { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfRejected", ResourceType = typeof(StipendResources))]
        public int NoOfRejected { get; set; }

        [Display(Name = "CardsRequestManagement_NoOfTransfer", ResourceType = typeof(StipendResources))]
        public int NoOfTransfer { get; set; }

        public int NoOfPendingStudentsHasNoCards { get; set; }
        public int NoOfPendingStudentsHasCards { get; set; }
    }
}
