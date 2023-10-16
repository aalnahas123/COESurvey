using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;

namespace COE.Common.Model.ViewModels
{
    public class UserDetails
    {
        public Guid UserId { get; set; }

        public UserDisplay User { get; set; }
        public List<College> Colleges { get; set; }
        public List<AspNetRoles> Roles { get; set; }

        public List<Specialization> Qualifications { get; set; }
    }
}
