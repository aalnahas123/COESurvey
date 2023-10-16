using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model
{
    public class QualificationsViewModel : BaseViewModel
    {
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FacultyName", ResourceType = typeof(AppResources))]
        public string CollegeName { get; set; }

        public int RPLAppicantID { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CollegeAddress", ResourceType = typeof(AppResources))]
        public string CollegeAddress { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CourseName", ResourceType = typeof(AppResources))]
        public string QualificationName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? AttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "CVAttachmen", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile { get; set; }
        public HttpFileCollectionBase filebase { get; set; }


        
    }
}
