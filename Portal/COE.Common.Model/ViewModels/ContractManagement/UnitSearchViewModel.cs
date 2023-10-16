using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public class UnitSearchViewModel : BaseViewModel
    {
        public UnitSearchViewModel()
        {
        }

        [Display(Name = "UnitName", ResourceType = typeof(ContractManagmentResources))]
        public string UnitName { get; set; }

        [Display(Name = "UnitCode", ResourceType = typeof(ContractManagmentResources))]
        public string UnitCode { get; set; }

        [Display(Name = "UnitType", ResourceType = typeof(ContractManagmentResources))]
        public int? TypeID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(ProviderResources))]
        public int? StatusID { get; set; }

        public StaticPagedList<Unit> Items { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }
}
