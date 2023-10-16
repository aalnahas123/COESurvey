using COE.Common.Localization;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class SponserSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(AppResources))]
        public string Name { get; set; }

        //[Display(Name = "Country", ResourceType = typeof(SponserResources))]
        //public int? CountryId { get; set; }

        [Display(Name = "City", ResourceType = typeof(SponserResources))]
        public int? CityID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(ProviderResources))]
        public int? StatusID { get; set; }

        public StaticPagedList<SponserViewModel> Items { get; set; }

    }
}
