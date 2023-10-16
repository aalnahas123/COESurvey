using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class ComplaintRequestViewModel
    {
        public int ID { get; set; }
        public int ProgramID { get; set; }
        public Guid UserID { get; set; }
        public long? RequestId { get; set; }
        public int? EnrollmentID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ComplaintParentType", ResourceType = typeof(ComplaintRequestResource))]
        public int? ComplaintParentTypeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ComplaintType", ResourceType = typeof(ComplaintRequestResource))]
        public int? ComplaintTypeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(250, ErrorMessageResourceType = typeof(ComplaintRequestResource), ErrorMessageResourceName = "ComplaintSubjectMaxLength")]
        [Display(Name = "ComplaintSubject", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintSupject { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(250, ErrorMessageResourceType = typeof(ComplaintRequestResource), ErrorMessageResourceName = "ComplaintDescriptionMaxLength")]
        [Display(Name = "ComplaintDescription", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintDescription { get; set; }

        // request attachments
        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]

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

        public ComplaintApplicantInfoViewModel TraineeInformation { get; set; }



        [Display(Name = "ComplaintParentType", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintParentTypeName { get; set; }

        [Display(Name = "ComplaintType", ResourceType = typeof(ComplaintRequestResource))]
        public string ComplaintTypeName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string Comment { get; set; }
    }
}
