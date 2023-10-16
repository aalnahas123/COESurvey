using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(CollegeMetaDataContract))]
    public partial class College 
    {

        internal class CollegeMetaDataContract
        {
            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            //[Display(Name = "Area", ResourceType = typeof(ContractManagmentResources))]
            //public int AreaID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "College_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }

            [Display(Name = "College_NameAr", ResourceType = typeof(MetaData))]
            public string NameAr { get; set; }

            [Display(Name = "CollegeType", ResourceType = typeof(ContractManagmentResources))]
            public int CollegeTypeID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "Gender", ResourceType = typeof(ContractManagmentResources))]
            public bool GenderID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "Status", ResourceType = typeof(ContractManagmentResources))]
            public int StatusID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "City", ResourceType = typeof(ContractManagmentResources))]
            public int CityID { get; set; }


            public string Description { get; set; }
            public string DescriptionAr { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "StartDate", ResourceType = typeof(ContractManagmentResources))]
            public DateTime StartDate { get; set; }

            [Display(Name = "ProviderID", ResourceType = typeof(ContractManagmentResources))]
            public int ProviderID { get; set; }

            [Display(Name = "College_Wave", ResourceType = typeof(MetaData))]
            public int WaveID { get; set; }

            [Display(Name = "TVTCFinanceCollegeCode", ResourceType = typeof(ContractManagmentResources))]
            public string TVTCFinanceCollegeCode { get; set; }

            [Display(Name = "TVTCCollegeBankCode", ResourceType = typeof(ContractManagmentResources))]
            public string TVTCCollegeBankCode { get; set; }

            [Display(Name = "TVTCSystemCollegeCode", ResourceType = typeof(ContractManagmentResources))]
            public string TVTCSystemCollegeCode { get; set; }

            [Display(Name = "TVTCCollegeNameAr", ResourceType = typeof(ContractManagmentResources))]
            public string TVTCCollegeNameAr { get; set; }

            [Display(Name = "HasStipend", ResourceType = typeof(ContractManagmentResources))]
            public bool HasStipend { get; set; }

        }

    }
}
