using COE.Common.Localization;
using COE.Common.Localization.Security;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(CollegeStaffMetadata))]
    public partial class CollegeStaff
    {

        internal class CollegeStaffMetadata
        {
            public int ID { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            public string Name { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
            [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
            public string Email { get; set; }

            [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
            ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = Commons.Framework.Web.Mvc.Helpers.NumberType.MOBILE, CountryCode = "SA")]
            [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
            [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
            public string Phone { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "EffectiveDate", ResourceType = typeof(SecurityResources))]
            public DateTime? EffectiveDate { get; set; }

            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DateMustBeGreaterThan("EffectiveDate", ErrorMessageResourceName = "LeaveDateMustBeGreaterThanEffectiveDate", ErrorMessageResourceType = typeof(SecurityResources))]
            [Display(Name = "LeaveDate", ResourceType = typeof(SecurityResources))]
            public DateTime? LeaveDate { get; set; }

            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            //[DateLessThanOrEqualToday(ErrorMessageResourceName = "LastQualificationDateMustBeLessThanToday", ErrorMessageResourceType = typeof(SecurityResources))]
            [Display(Name = "LastQualificationDate", ResourceType = typeof(SecurityResources))]
            public DateTime? LastQualificationDate { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "CollegeID", ResourceType = typeof(SecurityResources))]
            public Nullable<int> CollegeID { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "TypeID", ResourceType = typeof(SecurityResources))]
            public int? TypeID { get; set; }

            [RequiredIf("TypeID == 2", ErrorMessageResourceName = "RequiredField",
                       ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "LevelID", ResourceType = typeof(SecurityResources))]
            public int? LevelID { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "VisaType", ResourceType = typeof(SecurityResources))]
            public int? VisaTypeID { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "Nationality", ResourceType = typeof(SecurityResources))]
            public int? NationalityID { get; set; }

            [RequiredIf("TypeID == 1", ErrorMessageResourceName = "RequiredField",
           ErrorMessageResourceType = typeof(SharedResources))]
            [Display(Name = "AdminTitle", ResourceType = typeof(SecurityResources))]
            public string AdminTitle { get; set; }

            [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "QualificationID", ResourceType = typeof(SecurityResources))]
            public int? QualificationID { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "SpesializationID", ResourceType = typeof(SecurityResources))]
            public int? SpesializationID { get; set; }

            [Display(Name = "LeaveReasonID", ResourceType = typeof(SecurityResources))]
            public int? LeaveReasonID { get; set; }

            [Display(Name = "JobTypeID", ResourceType = typeof(SecurityResources))]
            public int? JobTypeID { get; set; }

            //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
            [Display(Name = "Gender", ResourceType = typeof(SecurityResources))]
            public int? Gender { get; set; }
        }
    }
}
