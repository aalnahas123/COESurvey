using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public class CollegeSearchViewModel : BaseViewModel
    {
        public CollegeSearchViewModel()
        {
        }
        [Display(Name = "CollegeName", ResourceType = typeof(ContractManagmentResources))]
        public string Name { get; set; }

        [Display(Name = "CollegeNameAr", ResourceType = typeof(ContractManagmentResources))]
        public string NameAr { get; set; }

        [Display(Name = "CollegeType", ResourceType = typeof(ContractManagmentResources))]
        public int CollegeTypeID { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(ContractManagmentResources))]
        public bool GenderID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(ContractManagmentResources))]
        public int StatusID { get; set; }

        [Display(Name = "City", ResourceType = typeof(ContractManagmentResources))]
        public int CityID { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }
}
