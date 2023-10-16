
using COE.Common.Localization;
using COE.Common.Model;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace COE.Common.Model.ViewModels
{
    public class QualificationApprovalRequestSubmitViewModel
    {
        [Required]
        public int? IntakeTermID { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string Comment { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        public List<System.Web.Mvc.SelectListItem> SpecializationsList { get; set; }

        //New Fields after change

        public Specialization Specialization { get; set; }

        public College College { get; set; }
    }
}
