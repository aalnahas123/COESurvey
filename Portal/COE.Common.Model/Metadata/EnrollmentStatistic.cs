using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(EnrollmentStatisticMetaData))]
    public partial class EnrollmentStatistic : CommonMetaData
    {
        internal class EnrollmentStatisticMetaData
        {
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "EnrollmentStatistic_DeanName", ResourceType = typeof(MetaData))]
            public virtual string DeanName { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
            [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "EnrollmentStatistic_DeanEmail", ResourceType = typeof(MetaData))]
            public virtual string DeanEmail { get; set; }

            [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
            ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "EnrollmentStatistic_DeanMobileNumber", ResourceType = typeof(MetaData))]
            [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
            public virtual string DeanMobileNumber { get; set; }

            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "EnrollmentStatistic_NumberOfFoundationTeachers", ResourceType = typeof(MetaData))]
            public int NumberOfFoundationTeachers { get; set; }

            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "EnrollmentStatistic_NumberOfAdminStaff", ResourceType = typeof(MetaData))]
            public int NumberOfAdminStaff { get; set; }

            [Required]
            //[Range(1, int.MaxValue, ErrorMessageResourceName = "LargerThanZeroValidation", ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "EnrollmentStatistic_NumberOfTechnicalTeachers", ResourceType = typeof(MetaData))]
            public int NumberOfTechnicalTeachers { get; set; }

        }
    }
}

