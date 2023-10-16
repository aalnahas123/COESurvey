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
    public class DeferralRequestViewModel /*: DeferralRequest*/
    {
        public DeferralRequestViewModel()
        {
            DeferralRequestAcademicYearTerm = new List<DeferralRequestAcademicYearTerm>();
            DeferralRequestReason = new List<DeferralRequestReason>();
            AttachedViews = new List<AttachmentViewModel>();
            RequestActionList = new List<RequestActionViewModel>();
            ReasonsList = new List<LookupViewModel>();
            AcademicYearTermList = new List<LookupViewModel>();
            EnrollmentVM = new EnrollmentViewModel();
        }



        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public long WorkflowRequestID { get; set; }
        public bool IsAfter3rdWeek { get; set; }
        public bool IsCurrentTermOnly { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [RequiredIf("SelectedDeferralReasonID == 4", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string OtherReasons { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<DeferralRequestAcademicYearTerm> DeferralRequestAcademicYearTerm { get; set; }
        public List<DeferralRequestReason> DeferralRequestReason { get; set; }

        // ViewModels Properties

        public EnrollmentViewModel EnrollmentVM { get; set; }
        public List<RequestActionViewModel> RequestActionList { get; set; }
        public List<LookupViewModel> ReasonsList { get; set; }
        public List<LookupViewModel> AcademicYearTermList { get; set; }

        public int RequestStageId { get; set; }
        public int RequestStatusId { get; set; }

        // Attachment properties
        //[Required(ErrorMessage = "Please select at least 1")]
        public List<AttachmentViewModel> AttachedViews { get; set; }
        public int LastAttachedIndex { get; set; }
        public int AttachedCount { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        [RequiredIf("Attachment1Id == null && SelectedDeferralReasonID != 4", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]

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

        // This property contains the selected reasons
        [Display(Name = "DeferralRequestReasons", ResourceType = typeof(AppResources))]
        //public List<string> SelectedReasons { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> SelectedReasons { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DeferralRequestReasons", ResourceType = typeof(AppResources))]
        public int? SelectedDeferralReasonID { get; set; }


        // This property contains the selected academic year terms
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DeferralRequestTrainingTrimester", ResourceType = typeof(AppResources))]
        public List<string> SelectedAcademicYearTerms { get; set; }


        public List<RequestAttachment> RequestAttachment { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Range(typeof(bool), "true", "true", ErrorMessageResourceType = typeof(RM.Workflow.DeferralRequestResources), ErrorMessageResourceName = "TermsAndConditions")]
        [Display(Name = "Approval", ResourceType = typeof(RM.Workflow.DeferralRequestResources))]
        public bool IsApproved { get; set; }

    }

}
