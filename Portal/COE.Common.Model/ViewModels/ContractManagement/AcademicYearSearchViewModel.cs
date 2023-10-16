using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class AcademicYearSearchViewModel  : BaseSearchViewModel
    {
        public AcademicYearSearchViewModel()
        {

        }
        [Display(Name = "Contract_Name", ResourceType = typeof(MetaData))]
        public string Name { get; set; }

        public Nullable<bool> IsCurrent { get; set; }

        public StaticPagedList<AcademicYear> Items { get; set; }
    }
}
