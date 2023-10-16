using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model.ViewModels
{
    [Serializable]
    public class AttachmentVM
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? AttachmentId { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile", ResourceType = typeof(SharedResources))]
        [ValidateFileUpload]
        [RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile { get; set; }

        public string Name { get; set; }
    }

    public class AttachmentModel
    {
        public AttachmentVM Attachment { get; set; }
        public List<AttachmentVM> AttachmentList { get; set; }
        public List<Attachments> AttachmentsList { get; set; }
    }
}
