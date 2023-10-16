using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace COE.Common.Model.ViewModels
{
    public class SystemSettingViewModel 
    {

        public int Id { get; set; }
        [Display(Name = "Settings_ApplicationId", ResourceType = typeof(AppResources))]
        public string ApplicationId { get; set; }
        [Display(Name = "Settings_Key", ResourceType = typeof(AppResources))]
        public string Key { get; set; }

        [AllowHtml]
        [Display(Name = "Settings_Value", ResourceType = typeof(AppResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string Value { get; set; }
        public string ValueDataType { get; set; }
        public DateTime? ValueDt { get; set; }
        [Display(Name = "Settings_IsActive", ResourceType = typeof(AppResources))]
        public bool IsActive { get; set; }
        [Display(Name = "Settings_Secure", ResourceType = typeof(AppResources))]
        public bool Secure { get; set; }

    }
}
