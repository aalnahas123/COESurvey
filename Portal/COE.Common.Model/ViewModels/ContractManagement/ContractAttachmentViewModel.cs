using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ContractAttachmentViewModel
    {
        public long Id { get; set; }

        [Required]
        public int ContractID { get; set; }
        public long RequestId { get; set; }
        public Guid AttachmentId { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile1 { get; set; }


        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

    }
}
