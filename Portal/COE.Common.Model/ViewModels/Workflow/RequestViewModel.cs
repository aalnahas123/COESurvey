
namespace COE.Common.Model.ViewModels.Workflows
{
    using System.ComponentModel.DataAnnotations;
    using RM.Workflow;
    using System.Collections.Generic;
    using Enrollment;
    using System.Web;
    using Localization;
    using ExpressiveAnnotations.Attributes;
    using Commons.Framework.Web.Mvc.DataAnnotations;
    using System;
    using Workflow;

    /// <summary>
    ///  The Request View Model
    /// </summary>
    /// <date>7/19/2017</date>
    /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
    /// <seealso cref="COE.Enrollment.Model.Request" />
    public class RequestViewModel : Request
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestViewModel"/> class.
        /// </summary>
        /// <date>7/19/2017</date>
        /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
        public RequestViewModel()
        {
            Decision = new DecisionViewModel();
            RequestAttachments = new List<RequestAttachmentViewModel>();
            DeferralRequestVM = new Workflows.DeferralRequestViewModel();
        }


        public RequestViewModel(Request request)
        {
            RequestID = request.RequestID;
            RequestNumber = request.RequestNumber;
            RequestDate = request.RequestDate;
            WorkflowID = request.WorkflowID;
            RequestDate = request.RequestDate;
            StageID = request.StageID;
            Stage = request.Stage;
            NextStep = request.NextStep;
            ProcessInstanceId = request.ProcessInstanceId;
            CreatedBy = request.CreatedBy;
            CreatedOn = request.CreatedOn;            
            UpdatedBy = request.UpdatedBy;
            UpdatedOn = request.UpdatedOn;
        }

        [Display(Name = "RequestName", ResourceType = typeof(InboxResources))]
        public string RequestName { get; set; }

        [Display(Name = "RequestNameAr", ResourceType = typeof(InboxResources))]
        public string RequestNameAr { get; set; }

        [Display(Name = "RequestNameEn", ResourceType = typeof(InboxResources))]
        public string RequestNameEn { get; set; }

        [Display(Name = "StageNameAr", ResourceType = typeof(InboxResources))]
        public string StageNameAr { get; set; }

        [Display(Name = "StageNameEn", ResourceType = typeof(InboxResources))]
        public string StageNameEn { get; set; }

        [Display(Name = "RequestStatus", ResourceType = typeof(InboxResources))]
        public string RequestStatus { get; set; }

        [Display(Name = "OriginatorName", ResourceType = typeof(InboxResources))]
        public string OriginatorName { get; set; }

        [Display(Name = "Url", ResourceType = typeof(InboxResources))]
        public string Url { get; set; }

        [Display(Name = "SerialNumber", ResourceType = typeof(InboxResources))]
        public string SerialNumber { get; set; }

        [Display(Name = "ActivityName", ResourceType = typeof(InboxResources))]
        public string ActivityName { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(InboxResources))]
        public string UserName { get; set; }

        [Display(Name = "UserFullName", ResourceType = typeof(InboxResources))]
        public string UserFullName { get; set; }

        [Display(Name = "AllocatedUser", ResourceType = typeof(InboxResources))]
        public string AllocatedUser { get; set; }

        [Display(Name = "StageName", ResourceType = typeof(InboxResources))]
        public string StageName { get; set; }
        public string RequestDetailsUrl { get; set; }
        public string ViewFlowUrl { get; set; }

        public string QualificationName { get; set; }

        // For tack Decision
        public DecisionViewModel Decision { get; set; }

        public DeferralRequestViewModel DeferralRequestVM { get; set; }
        
        public WithdrawRequestViewModel WithdrawRequestVM { get; set; }

        public TransferRequestViewModel TransferRequestVM { get; set; }

        public ReinstateRequestViewModel ReinstateRequestVM { get; set; }

        public StudentsDisabilityRequestViewModel StudentsDisabilityRequestVM { get; set; }

        public ComplaintRequestViewModel ComplaintRequestVM { get; set; }

        public List<RequestAttachmentViewModel> RequestAttachments { get; set; }
        public List<EnrollmentChangeStatusRequestViewModel> ChangeStatusRequestList { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

        public bool CanCancelProcess { get; set; }

        [Display(Name = "CancelProcessComment", ResourceType = typeof(InboxResources))]
        public string CancelProcessComment { get; set; }
        public string ModelJsonEncoded { get; set; }

        public int CollegeSpecializationIDTEST { get; set; }
        public string CollegeName { get; set; }
        public string NationalID { get; set; }
    }
}
