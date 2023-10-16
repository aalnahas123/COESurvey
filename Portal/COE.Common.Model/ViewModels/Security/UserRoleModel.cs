using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;

namespace COE.Common.Model.ViewModels
{
    public class UserRoleModel
    {
        public Guid RoleId { get; set; }
        public int CategoryId { get; set; }

        public string RoleName { get; set; }
        public string CategoryName { get; set; }
    }

}
