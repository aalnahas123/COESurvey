using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ContractViewModel : BaseViewModel
    {
        public ContractViewModel()
        {
            this.ContractAttachments = new List<ContractAttachmentViewModel>();
            this.ContractCollegeAcademicYears = new List<ContractCollegeAcademicYearViewModel>();

        }

        [Display(Name = "Contract_EffectiveDate", ResourceType = typeof(MetaData))]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "Contract_EndDate", ResourceType = typeof(MetaData))]
        public DateTime EndDate { get; set; }

        [Display(Name = "Contract_Name", ResourceType = typeof(MetaData))]
        public string Name { get; set; }
        public virtual Model.Provider Provider { get; set; }

        [Display(Name = "Contract_ProviderID", ResourceType = typeof(MetaData))]
        public int ProviderID { get; set; }

        [Display(Name = "Contract_ReferenceNo", ResourceType = typeof(MetaData))]
        public string ReferenceNo { get; set; }

        [Display(Name = "Contract_SigningDate", ResourceType = typeof(MetaData))]
        public DateTime SigningDate { get; set; }

        [Display(Name = "Contract_StartDate", ResourceType = typeof(MetaData))]
        public DateTime StartDate { get; set; }

        [Display(Name = "Contract_Value", ResourceType = typeof(MetaData))]
        public decimal ContractValue { get; set; }

        [Display(Name = "Contract_WaveID", ResourceType = typeof(MetaData))]
        public int WaveID { get; set; }

        [Display(Name = "Contract_WaveID", ResourceType = typeof(MetaData))]
        public int? SelectedWaveID { get; set; }

        [Display(Name = "Contract_ProviderID", ResourceType = typeof(MetaData))]
        public int? SelectedProviderID { get; set; }

        [Display(Name = "Contract_ContractTypeID", ResourceType = typeof(MetaData))]
        public int? SelectedContractTypeID { get; set; }

        

        [Display(Name = "Contract_TermTypeID", ResourceType = typeof(MetaData))]
        public int? SelectedTermTypeID { get; set; }
        public List<System.Web.Mvc.SelectListItem> CollegesList { get; set; }

        public List<System.Web.Mvc.SelectListItem> ProvidersList { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile1 { get; set; }

      
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        public List<ContractCollegeAcademicYearViewModel> ContractCollegeAcademicYears { get; set; }
         
        public List<ContractAttachmentViewModel> ContractAttachments { get; set; }
    }
}
