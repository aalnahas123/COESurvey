using COE.Common.Localization;
using Commons.Framework.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class SystemSettingSearchModel : BaseSearchViewModel
    {
        [Display(Name = "Settings_ApplicationId", ResourceType = typeof(AppResources))]
        public string ApplicationId { get; set; }
        [Display(Name = "Settings_Key", ResourceType = typeof(AppResources))]
        public string Key { get; set; }
        [Display(Name = "Settings_Type", ResourceType = typeof(AppResources))]
        public string Type { get; set; }

        public StaticPagedList<SystemSetting> Items { get; set; }


    }
}
