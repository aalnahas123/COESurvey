using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(UploadRequestMetaData))]
    public partial class UploadRequest
    {
        class UploadRequestMetaData
        {

            [Display(Name = "MD_UploadRequest_NoOfRecords", ResourceType = typeof(DCSResources))]
            public Nullable<int> NoOfRecords { get; set; }


            [Display(Name = "MD_UploadRequest_NoOfInValidRecords", ResourceType = typeof(DCSResources))]
            public Nullable<int> NoOfInValidRecords { get; set; }



            [Display(Name = "MD_UploadRequest_CreatedOn", ResourceType = typeof(DCSResources))]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public System.DateTime CreatedOn { get; set; }


            [Display(Name = "MD_UploadRequest_CreatedBy", ResourceType = typeof(DCSResources))]
            public string CreatedBy { get; set; }


            [Display(Name = "MD_UploadRequest_UploadedFileURL", ResourceType = typeof(DCSResources))]
            public string UploadedFileURL { get; set; }

            [Display(Name = "MD_UploadRequest_UploadRequestStatusID", ResourceType = typeof(DCSResources))]
            public int UploadRequestStatusID { get; set; }

        }
    }

}
