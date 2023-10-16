using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using COE.Common.Model.ViewModels.Workflows;
using Commons.Framework.Web.Mvc.DataAnnotations;
using RM.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model.ViewModels.Workflow
{
    public class StudentsDisabilityRequestViewModel
    {
        public StudentsDisabilityRequestViewModel()
        {
            AttachedViews = new List<AttachmentViewModel>();
            RequestActionList = new List<RequestActionViewModel>();
            EnrollmentVM = new EnrollmentViewModel();
        }

        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public long WorkflowRequestID { get; set; }
        public int? StudentsDisabilityLevelId { get; set; }

        [Display(Name = "StudentsDisabilityDescription", ResourceType = typeof(StudentsDisabilityRequestResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public string Comment { get; set; }
        public string StudentsDisabilityLevelName { get; set; }

        //public DateTime CreatedOn { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }
        //public string UpdatedBy { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "MedicalReport", ResourceType = typeof(StudentsDisabilityRequestResource))]
        [ValidateFileUpload]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "OfficialLetter", ResourceType = typeof(StudentsDisabilityRequestResource))]
        [ValidateFileUpload]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile2 { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(StudentsDisabilityRequestResource), Name = "MedicalReport")]
        public Guid? Attachment1Id { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(StudentsDisabilityRequestResource), Name = "OfficialLetter")]
        public Guid? Attachment2Id { get; set; }

        public EnrollmentViewModel EnrollmentVM { get; set; }
        public List<RequestActionViewModel> RequestActionList { get; set; }
        public List<RequestAttachment> RequestAttachment { get; set; }
        public List<AttachmentViewModel> AttachedViews { get; set; }

        //public virtual Enrollment Enrollment { get; set; }
        //public virtual Request Request { get; set; }
    }
}
