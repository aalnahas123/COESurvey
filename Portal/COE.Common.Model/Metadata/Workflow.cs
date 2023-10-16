using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(WorkflowMetaData))]
    public partial class Workflow : CommonMetaData
    {
        internal class WorkflowMetaData
        {

            [Display(Name = "Workflow_NameEn", ResourceType = typeof(MetaData))]
            public string NameEn { get; set; }

            [Display(Name = "Workflow_NameAr", ResourceType = typeof(MetaData))]
            public string NameAr { get; set; }

        }
    }
}
