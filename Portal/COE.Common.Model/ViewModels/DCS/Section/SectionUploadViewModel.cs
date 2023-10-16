using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionUploadViewModel : UploadViewModel
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

        public UploadRequest UploadRequest { get; set; }

        public string SaveMessage { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(DCSResources))]
        public DateTime? DateTo { get; set; }
        [Display(Name = "DateFrom", ResourceType = typeof(DCSResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "IsRecurring", ResourceType = typeof(DCSResources))]
        public bool IsRecurring { get; set; } = false;

        public bool IsSavedSuccessfully { get; set; } = false;


        public string SixMonthCollegeIDs => ConfigurationManager.AppSettings["SixMonthsCollegesIDs"];

    }
}
