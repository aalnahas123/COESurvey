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
    public class InvoiceRequestViewModel
    {
        public InvoiceRequestViewModel()
        {
            this.InvoiceRequest = new InvoiceRequest();
        }

        public InvoiceRequest InvoiceRequest { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string Comment { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RequestAction", ResourceType = typeof(AppResources))]
        public string SelectedAction { get; set; }

        public DecisionViewModel Decision { get; set; }
    }
}
