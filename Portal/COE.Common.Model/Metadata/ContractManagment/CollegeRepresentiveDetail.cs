using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(CollegeRepresentiveDetailMetadata))]
    public partial class CollegeRepresentiveDetail
    {
    }

    class CollegeRepresentiveDetailMetadata
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RepresentativeName", ResourceType = typeof(ContractManagmentResources))]
        public string RepresentativeName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RepresentativeJobTitle", ResourceType = typeof(ContractManagmentResources))]
        public string RepresentativeJobTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RepresentativeMobileNo", ResourceType = typeof(ContractManagmentResources))]
        public string RepresentativeMobileNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RepresentativeEmail", ResourceType = typeof(ContractManagmentResources))]
        public string RepresentativeEmail { get; set; }
    }
}
