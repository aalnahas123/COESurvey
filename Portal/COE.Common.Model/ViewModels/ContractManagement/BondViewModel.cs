using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class BondViewModel : BaseViewModel
    {
        public BondViewModel()
        {
            this.ContractsList = new List<System.Web.Mvc.SelectListItem> ();
        }
        [Display(Name = "Bond_Name", ResourceType = typeof(MetaData))]
        public string Name { get; set; }

        [Display(Name = "Bond_TypeID", ResourceType = typeof(MetaData))]
        public int TypeID { get; set; }

        [Display(Name = "Bond_Value", ResourceType = typeof(MetaData))]
        public decimal Value { get; set; }


        [Display(Name = "Bond_ExpiryDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime ExpiryDate { get; set; }


        [Display(Name = "Bond_SubmissionDate", ResourceType = typeof(MetaData))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime SubmissionDate { get; set; }
        public int BankID { get; set; }

        //
        [Display(Name = "Bond_BankID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedBankID { get; set; }

        [Display(Name = "Bond_ContractID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedContractID { get; set; }

        [Display(Name = "Bond_TypeID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedBondTypeID { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile1 { get; set; }


        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        //
        public List<System.Web.Mvc.SelectListItem> ContractsList { get; set; }
    }
}
