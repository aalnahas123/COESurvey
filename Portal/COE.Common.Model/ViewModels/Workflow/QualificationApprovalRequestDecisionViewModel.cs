
using COE.Common.Localization;
using COE.Common.Model;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace COE.Common.Model.ViewModels
{
    public class QualificationApprovalRequestDecisionViewModel
    {
        public QualificationApprovalRequestDecisionViewModel()
        {
            this.CollegeSpecializationRequest = new CollegeSpecializationRequest();
        }
        public string approve = "Approve";
        public CollegeSpecializationRequest CollegeSpecializationRequest { get; set; }

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

        //
        [Required]
        public int? ExpiryTermID { get; set; }

        [Required]
        public DateTime? ExpiryDate { get; set; }
    }
}
