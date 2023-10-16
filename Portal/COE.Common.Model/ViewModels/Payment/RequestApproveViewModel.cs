using COE.Common.Localization;
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
    public class RequestApproveViewModel
    {

        public int? id { get; set; }

        public CollegePaymentRequestDetailsViewModel CollegePaymentRequestDetailsVM { get; set; }

        [Required]
        [Display(Name = "PaidAmount", ResourceType =typeof(PaymentResource))]
        public decimal PaidAmount { get; set; }
        [Required]
        [Display(Name = "PaidAmountComment", ResourceType = typeof(PaymentResource))]
        public string PaidAmountComment { get; set; }

        // attachment
        [DataType(DataType.Upload)]
        [Display(Name = "AttachedFile1", ResourceType = typeof(AppResources))]
        [ValidateFileUpload]
        //[Required]
        [RequiredIf("IsAttachmentRequired==true", ErrorMessageResourceName = "RequiredField",
            ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AttachedFile1 { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? Attachment1Id { get; set; }

        public bool IsAttachmentRequired { get; set; }
    }
}
