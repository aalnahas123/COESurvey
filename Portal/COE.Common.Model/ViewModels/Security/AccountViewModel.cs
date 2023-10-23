using COE.Common.Localization;
using COE.Common.Localization.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public partial class AccountViewModel
    {
        [Display(Name = "UserType", ResourceType = typeof(SecurityResources))]
        public string UserType { get; set; }

        public bool IsOnlineUser { get { return UserType == "2"; } set { } }

        
    }
}

