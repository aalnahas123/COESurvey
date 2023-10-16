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
    [MetadataType(typeof(UnitMetaData))]
    public partial class Unit 
    {
        public string UnitTypeText { get; set; }

        internal class UnitMetaData
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "UnitName", ResourceType = typeof(ContractManagmentResources))]
            public string Name { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "UnitCode", ResourceType = typeof(ContractManagmentResources))]
            public string Code { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "UnitType", ResourceType = typeof(ContractManagmentResources))]
            public int TypeID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [RegularExpression("^(\\d{1,5}|\\d{0,5}\\.\\d{1,2})$", ErrorMessage = "Hours must be a number with maximum two decimal places")]
            [Display(Name = "RecommendedLearningHours", ResourceType = typeof(ContractManagmentResources))]
            public decimal RecommendedLearningHours { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "Status", ResourceType = typeof(ProviderResources))]
            public int StatusID { get; set; }
        }
    }
}
