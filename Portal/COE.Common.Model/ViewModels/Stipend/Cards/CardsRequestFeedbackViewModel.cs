using COE.Common.Localization;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardsRequestFeedbackViewModel : UploadFeedbackBase
    {
        [Required]
        [Display(Name = "Common_FileUploadAttachment", ResourceType = typeof(StipendResources))]
        public HttpPostedFileBase Attachment { get; set; }

        [FileExtensions(Extensions = "csv", ErrorMessageResourceName = "Common_FileUploadValidExtensions", ErrorMessageResourceType = typeof(StipendResources))]
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

        public CardsRequest CardsRequest { get; set; }

        public StaticPagedList<CardsFeedbackValidation> Items { get; set; }
        public UploadRequest UploadRequest { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }
}
