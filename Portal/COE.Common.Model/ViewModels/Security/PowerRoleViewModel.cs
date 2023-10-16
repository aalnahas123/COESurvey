using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;

namespace COE.Common.Model.ViewModels
{
    public class PowerRoleviewModel
    {
        public PowerRoleviewModel()
        {
            //ModuleCategories = new List<ModuleCategory>();
        }
        public AspNetRoles AspNetRoles { get; set; }
        public List<ModuleCategory> ModuleCategories { get; set; }
    }

}
