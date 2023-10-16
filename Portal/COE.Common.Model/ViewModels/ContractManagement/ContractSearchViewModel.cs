using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ContractSearchViewModel  : BaseSearchViewModel
    {
        public ContractSearchViewModel()
        {

        }
        [Display(Name = "Contract_Name", ResourceType = typeof(MetaData))]
        public string Name { get; set; }

        [Display(Name = "Contract_ReferenceNo", ResourceType = typeof(MetaData))]
        public string ReferenceNo { get; set; }

        [Display(Name = "Contract_Value", ResourceType = typeof(MetaData))]
        public decimal Value { get; set; }

        [Display(Name = "Contract_StartDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Contract_EndDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Contract_EffectiveDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "Contract_SigningDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? SigningDate { get; set; }

        [Display(Name = "Contract_WaveID", ResourceType = typeof(MetaData))]
        public int? WaveID { get; set; }

        [Display(Name = "Contract_TermTypeID", ResourceType = typeof(MetaData))]
        public int? TermTypeID { get; set; }

        [Display(Name = "Contract_ContractTypeID", ResourceType = typeof(MetaData))]
        public int? ContractTypeID { get; set; }

        public StaticPagedList<Contract> Items { get; set; }
    }
}
