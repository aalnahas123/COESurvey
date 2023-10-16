using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(UploadRequestStatusMetaData))]
    public partial class UploadRequestStatus
    {
        class UploadRequestStatusMetaData
        {

            [Display(Name = "MD_UploadRequestStatus_Name", ResourceType = typeof(DCSResources))]
            public string Name { get; set; }

            [Display(Name = "CardsRequest_FeedbackUploadStatus", ResourceType = typeof(StipendResources))]
            public int ID { get; set; }

        }
    }

}