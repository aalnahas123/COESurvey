using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using RM.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class DismissRequestViewModel
    {
        public DismissRequestViewModel()
        {
            this.DismissRequest = new DismissRequest();
        }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        [RequiredIf("Attachment1Id == null && SelectedDismissReasonID != 7", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile2", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile2 { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment2Id { get; set; }

        [Display(Name = "DismissRequestReasons", ResourceType = typeof(DismissRequestResources))]
        public IEnumerable<System.Web.Mvc.SelectListItem> SelectedDismissReasons { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DismissRequestReasons", ResourceType = typeof(DismissRequestResources))]
        public int? SelectedDismissReasonID { get; set; }

        public DismissRequest DismissRequest { get; set; }

        public List<AttachmentViewModel> AttachedViews { get; set; }

        public int LastAttachedIndex { get; set; }

        public int AttachedCount { get; set; }

        public DecisionViewModel Decision { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

        public RequestViewModel RequestViewModel { get; set; }

        [RequiredIf("SelectedDismissReasonID == 7", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]

        [Display(Name = "DismissRequestReasonComments", ResourceType = typeof(DismissRequestResources))]
        public string DismissRequestReasonComments { get; set; }

        public bool IsAttachmentRequired { get; set;}

    }
}
