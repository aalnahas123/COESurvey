using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class BondSearchViewModel : BaseSearchViewModel
    {
        public BondSearchViewModel()
        {
        }

        [Display(Name = "Bond_Name", ResourceType = typeof(MetaData))]
        public string Name { get; set; }

        [Display(Name = "Bond_TypeID", ResourceType = typeof(MetaData))]
        public int? TypeID { get; set; }

        [Display(Name = "Bond_Value", ResourceType = typeof(MetaData))]
        public decimal Value { get; set; }

        [Display(Name = "Bond_ExpiryDate", ResourceType = typeof(MetaData))]
        public System.DateTime ExpiryDate { get; set; }

        [Display(Name = "Bond_SubmissionDate", ResourceType = typeof(MetaData))]
        public System.DateTime SubmissionDate { get; set; }

        [Display(Name = "Bond_BankID", ResourceType = typeof(MetaData))]
        public int? BankID { get; set; }

        [Display(Name = "Bond_ContractID", ResourceType = typeof(MetaData))]
        public int? ContractID { get; set; }

        public StaticPagedList<Bond> Items { get; set; }
       
    }
}
