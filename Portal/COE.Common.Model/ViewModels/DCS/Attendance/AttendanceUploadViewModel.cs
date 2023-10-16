using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceUploadViewModel : UploadViewModel
    {
        [Required]
        [Display(Name = "Provider", ResourceType = typeof(DCSResources))]
        public int ProviderId { get; set; }

        [Required]
        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public int CollegeId { get; set; }

        [Required]
        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public string AcademicYearId { get; set; }

        [Required]
        [Display(Name = "Term", ResourceType = typeof(DCSResources))]
        public int TermId { get; set; }

        [Required]
        [Display(Name = "Period", ResourceType = typeof(DCSResources))]
        public string SectionAttendanceSetting { get; set; }
        
        [Required]
        [Display(Name = "FileUploadAttachment", ResourceType = typeof(DCSResources))]
        public HttpPostedFileBase Attachment { get; set; }

        [FileExtensions(Extensions = "csv", ErrorMessageResourceName = "FileUploadValidExtensions", ErrorMessageResourceType = typeof(DCSResources))]
        public string AttachmentFileName
        {
            get
            {
                if (Attachment != null)
                    return Attachment.FileName;
                else
                    return "";
            }
        }

        public List<ExtendedLookupViewModel> PeriodsList { get; set; }

    }
}
