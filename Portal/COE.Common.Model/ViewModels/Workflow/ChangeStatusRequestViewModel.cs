using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using Commons.Framework.Web.Mvc.DataAnnotations;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Workflow
{
    public class ChangeStatusRequestViewModel
    {
        public ChangeStatusRequestViewModel()
        {
            TermEnrollmentIds = new List<int>();
            //TermEnrollmentList = new List<TermEnrollmentViewModel>();
        }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CurrentStageId { get; set; }

        public List<int> TermEnrollmentIds { get; set; }

        public string Comment { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? AttachmentId { get; set; }

        public List<TermEnrollmentViewModel> AllSelectedTermEnrollmentItems { get; set; }

        public StaticPagedList<TermEnrollmentViewModel> Items { get; set; }
    }
}
