using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels
{
    public class AttachmentViewModel
    {
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? AttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        [RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField",
            ErrorMessageResourceType = typeof(SharedResources))]

        //[Display(Name = "AttachedFile", ResourceType = typeof(AppResources))]
        public HttpPostedFileBase AttachedFile { get; set; }
    }
}
