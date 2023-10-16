using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels
{
    public class AllUsersModel
    {
        public Guid Id { get; set; }
        public Guid DisplayId { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        public string UserName { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(SecurityResources))]
        public string FullName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(SecurityResources))]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string NationalId { get; set; }
        public int Type { get; set; }
        public int Colleges { get; set; }
        public int Roles { get; set; }

        public string CreatedBy { get; set; }
        public int QualificationsCount { get; set; }
    }
}
