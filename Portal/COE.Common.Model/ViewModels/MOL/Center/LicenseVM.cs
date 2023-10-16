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

namespace COE.Common.Model.CenterVMs
{
    public class LicenseVM : BaseRegistrationStepVM
    {
        public LicenseVM()
        {
            StepNumber = 2;
        }
        [Display(Name = "GeneralLicenseThreeMonth", ResourceType = typeof(RPLResources))]
        //[MustBeTrue(ErrorMessageResourceName = "YouMustAgree", ErrorMessageResourceType = typeof(RPLResources))]
        public bool GeneralLicenseThreeMonth { get; set; }

        [Display(Name = "PrivateLicenseHealthSafety", ResourceType = typeof(RPLResources))]
        //[MustBeTrue(ErrorMessageResourceName = "YouMustAgree", ErrorMessageResourceType = typeof(RPLResources))]
        public bool PrivateLicenseHealthSafety { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "GeneralLicenseAttachment", ResourceType = typeof(RPLResources))]
        [ValidateFileUpload]
        [RequiredIf("GeneralLicenseThreeMonth == true && GeneralLicenseID == null", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase GeneralLicenseFile { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "PrivateLicenseAttachment", ResourceType = typeof(RPLResources))]
        [ValidateFileUpload]
        [RequiredIf("PrivateLicenseHealthSafety == true && PrivateLicenseID == null", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase PrivateLicenseFile { get; set; }

        public Guid? PrivateLicenseID { get; set; }
        public Guid? GeneralLicenseID { get; set; }

        public bool IsEditable { get { return !PrivateLicenseID.HasValue || !GeneralLicenseID.HasValue; } }

        public int CenterID { get; set; }
    }
}