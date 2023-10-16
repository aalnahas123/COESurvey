
namespace COE.Common.Model.ViewModels.Workflows
{
    using Commons.Framework.Web.Mvc.DataAnnotations;
    using Enrollment;
    using ExpressiveAnnotations.Attributes;
    using Localization;
    using RM.Workflow;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    /// <summary>
    ///  The Withdraw Request View Model
    /// </summary>
    /// <date>7/19/2017</date>
    /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
    /// <seealso cref="WithdrawRequest" />
    public class WithdrawRequestViewModel : WithdrawRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawRequestViewModel"/> class.
        /// </summary>
        /// <date>7/19/2017</date>
        /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
        public WithdrawRequestViewModel()
        {
            AttachedViews = new List<AttachmentViewModel>();
            RequestAttachments = new List<RequestAttachment>();           
            RequestActionList = new List<RequestActionViewModel>();
            EnrollmentViewModel = new EnrollmentViewModel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawRequestViewModel"/> class.
        /// </summary>
        /// <param name="withdrawRequest">The withdraw request.</param>
        /// <date>7/19/2017</date>
        /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
        public WithdrawRequestViewModel(WithdrawRequest withdrawRequest)
        {
            ID = withdrawRequest.ID;
            WorkflowRequestID = withdrawRequest.WorkflowRequestID;
            CounselorComment = withdrawRequest.CounselorComment;
            CreatedBy = withdrawRequest.CreatedBy;
            CreatedOn = withdrawRequest.CreatedOn;
            EnrollmentID = withdrawRequest.EnrollmentID;
            StudentServicesComment = withdrawRequest.StudentServicesComment;
            UpdatedBy = withdrawRequest.UpdatedBy;
            UpdatedOn = withdrawRequest.UpdatedOn;
            Enrollment = withdrawRequest.Enrollment;
            Request = withdrawRequest.Request;            
            WithdrawRequestReason = withdrawRequest.WithdrawRequestReason;
        }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        [RequiredIf("Attachment1Id == null && SelectedWithdrawReasonID != 4", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
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

        [Display(Name = "StudentServicesComment", ResourceType = typeof(WithdrawRequestResources))]
        public new string StudentServicesComment { get; set; }

        [Display(Name = "CounselorComment", ResourceType = typeof(WithdrawRequestResources))]
        public new string CounselorComment { get; set; }

        [Display(Name = "RequestName", ResourceType = typeof(WithdrawRequestResources))]
        public string RequestName { get; set; }

        [Display(Name = "RequestNameAr", ResourceType = typeof(WithdrawRequestResources))]
        public string RequestNameAr { get; set; }

        [Display(Name = "RequestNameEn", ResourceType = typeof(WithdrawRequestResources))]
        public string RequestNameEn { get; set; }

        [Display(Name = "RequestNumber", ResourceType = typeof(WithdrawRequestResources))]
        public string RequestNumber { get; set; }

        [Display(Name = "StageNameAr", ResourceType = typeof(WithdrawRequestResources))]
        public string StageNameAr { get; set; }

        [Display(Name = "StageNameEn", ResourceType = typeof(WithdrawRequestResources))]
        public string StageNameEn { get; set; }

        [Display(Name = "StageName", ResourceType = typeof(WithdrawRequestResources))]
        public string StageName { get; set; }

        [Display(Name = "OriginatorName", ResourceType = typeof(WithdrawRequestResources))]
        public string OriginatorName { get; set; }

        [Display(Name = "Url", ResourceType = typeof(WithdrawRequestResources))]
        public string Url { get; set; }

        [Display(Name = "SerialNumber", ResourceType = typeof(WithdrawRequestResources))]
        public string SerialNumber { get; set; }

        [Display(Name = "ActivityName", ResourceType = typeof(WithdrawRequestResources))]
        public string ActivityName { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(WithdrawRequestResources))]
        public string UserName { get; set; }

        [Display(Name = "UserFullName", ResourceType = typeof(WithdrawRequestResources))]
        public string UserFullName { get; set; }

        [Display(Name = "AllocatedUser", ResourceType = typeof(WithdrawRequestResources))]
        public string AllocatedUser { get; set; }

        public int CollegeId { get; set; }

        [Display(Name = "WithdrawRequestReason", ResourceType = typeof(WithdrawRequestResources))]
        public IEnumerable<System.Web.Mvc.SelectListItem> WithdrawSelectedReasonList { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WithdrawRequestReason", ResourceType = typeof(WithdrawRequestResources))]
        public int? SelectedWithdrawReasonID { get; set; }


        [RequiredIf("SelectedWithdrawReasonID == 4", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "WithdrawRequestReasonComments", ResourceType = typeof(WithdrawRequestResources))]
        public string WithdrawRequestReasonComments { get; set; }

        public List<RequestAttachment> RequestAttachments { get; set; }

        public List<AttachmentViewModel> AttachedViews { get; set; }

        //public int LastAttachedIndex { get; set; }

        //public int AttachedCount { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

        public EnrollmentViewModel EnrollmentViewModel { get; set; }

        //public string ModelJsonEncoded { get; set; }

    }   
  
}
