using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public class OTpVM : BaseRegistrationStepVM
    {
        public OTpVM()
        {
            StepNumber = 3;
        }
        [Display(Name = "CenterSecureCode", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(10, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string SecureCode { get; set; }

        public string SecureCodeNotification { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Error secure code")]
        public bool IsVerified { get; set; } = false;

        public bool IsResend { get; set; } = false;
    }
}