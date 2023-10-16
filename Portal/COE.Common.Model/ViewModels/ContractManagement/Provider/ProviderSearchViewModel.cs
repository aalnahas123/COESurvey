using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ProviderSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(AppResources))]
        public string Name { get; set; }

        [Display(Name = "Country", ResourceType = typeof(ProviderResources))]
        public int? CountryId { get; set; }

        [Display(Name = "Status", ResourceType = typeof(ProviderResources))]
        public int? StatusID { get; set; }

        public StaticPagedList<ProviderViewModel> Items { get; set; }

    }
}
