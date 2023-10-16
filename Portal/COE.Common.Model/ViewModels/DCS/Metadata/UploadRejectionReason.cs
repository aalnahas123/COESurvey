using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(UploadRejectionReasonMetaData))]
    public partial class UploadRejectionReason
    {
        class UploadRejectionReasonMetaData
        {

            [Display(Name = "MD_UploadRejectionReason_Name", ResourceType = typeof(DCSResources))]
            public string Name { get; set; }
        }
    }
}