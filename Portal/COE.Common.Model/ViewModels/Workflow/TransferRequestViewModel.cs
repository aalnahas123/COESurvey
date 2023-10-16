using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class TransferRequestViewModel : TransferRequest
    {
        public TransferRequestViewModel()
        {
            AttachedViews = new List<AttachmentViewModel>();
            RequestAttachments = new List<RequestAttachment>();
            RequestActionList = new List<RequestActionViewModel>();
            EnrollmentViewModel = new EnrollmentViewModel();
            NewSpecializationList = new List<System.Web.Mvc.SelectListItem>();
        }

        public TransferRequestViewModel(TransferRequest transferRequest)
        {
            ID = transferRequest.ID;
            WorkflowRequestID = transferRequest.WorkflowRequestID;
            CreatedBy = transferRequest.CreatedBy;
            CreatedOn = transferRequest.CreatedOn;
            EnrollmentID = transferRequest.EnrollmentID;
            UpdatedBy = transferRequest.UpdatedBy;
            UpdatedOn = transferRequest.UpdatedOn;
            Enrollment = transferRequest.Enrollment;
            Request = transferRequest.Request;
        }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        //[RequiredIf("Attachment1Id == null && SelectedTransferReasonID != 5", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile2", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment2Id { get; set; }

        [Display(Name = "RequestName", ResourceType = typeof(SharedResources))]
        public string RequestName { get; set; }

        [Display(Name = "RequestNumber", ResourceType = typeof(SharedResources))]
        public string RequestNumber { get; set; }

        [Display(Name = "StageName", ResourceType = typeof(SharedResources))]
        public string StageName { get; set; }

        public int CurrentCollegeId { get; set; }

        public int CurrentLevelId { get; set; }

        public string CurrentCollege { get; set; }

        public string CurrentCollegeSpecialization { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NewCollegeId", ResourceType = typeof(AppResources))]
        //[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int? NewCollegeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NewSpecializationId", ResourceType = typeof(AppResources))]
        //[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new int? NewCollegeSpecializationID { get; set; }

        public string NewCollege { get; set; }

        public string NewCollegeSpecialization { get; set; }

        public List<RequestAttachment> RequestAttachments { get; set; }

        public List<AttachmentViewModel> AttachedViews { get; set; }

        public int LastAttachedIndex { get; set; }

        public int AttachedCount { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

        [Display(Name = "TransferRequestReasons", ResourceType = typeof(AppResources))]
        public IEnumerable<System.Web.Mvc.SelectListItem> SelectedReasons { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TransferRequestReasons", ResourceType = typeof(AppResources))]
        public int? SelectedTransferReasonID { get; set; }

        public EnrollmentViewModel EnrollmentViewModel { get; set; }



        [RequiredIf("SelectedTransferReasonID == 5", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "OtherTransferReasons", ResourceType = typeof(AppResources))]
        public new string OtherReasons { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NumberOfFullFundingTrimester", ResourceType = typeof(AppResources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new int? NoOfFullFundedTerms { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FundingLevelID", ResourceType = typeof(AppResources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new int? FundingLevelID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FundingSpecializationID", ResourceType = typeof(AppResources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new int? FundingSpecializationID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SSSExamID", ResourceType = typeof(AppResources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new int? SSSExamID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SSSExamResult", ResourceType = typeof(AppResources))]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public new decimal? SSSExamResult { get; set; }

        public string FundingLevel { get; set; }

        public string FundingSpecialization { get; set; }


        public string SSSExamName { get; set; }


        public IEnumerable<System.Web.Mvc.SelectListItem> newCollegeList { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> NewSpecializationList { get; set; }

    }
}
