using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(SubProgramMetaData))]
    public partial class SubProgram
    {
        [Display(Name = "ProgramType", ResourceType = typeof(SubProgramResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int ProgramID { get; set; }

        public string ProgramTypeName { get; set; }

        [Display(Name = "Specializations", ResourceType = typeof(SubProgramResources))]
        public int[] SelectedSpecializationsIds { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(SubProgramResources))]
        public string SelectedSpecializationName { get; set; }

        public int CollegeLevel { get; set; }

        class SubProgramMetaData
        {
            [Display(Name = "Name", ResourceType = typeof(SubProgramResources))]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }

            [Display(Name = "StartDate", ResourceType = typeof(SubProgramResources))]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public System.DateTime? StartDate { get; set; }

            [Display(Name = "EndDate", ResourceType = typeof(SubProgramResources))]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public System.DateTime? EndDate { get; set; }
        }
    }

}
