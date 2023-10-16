using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentListSearchViewModel
    {
        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string NationalId { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

    }
}
