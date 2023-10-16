using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(PaymentSettingMetaData))]
    public partial class PaymentSetting
    {       
        [Required(ErrorMessageResourceName = "Vld_CoursePriceRequired", ErrorMessageResourceType = typeof(PaymentResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_CoursePriceGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "FoundationLevelPrice", ResourceType = typeof(PaymentResource))]
        public double FoundationLevelPrice { get; set; }

        [Required(ErrorMessageResourceName = "Vld_CoursePriceRequired", ErrorMessageResourceType = typeof(PaymentResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_CoursePriceGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "AssociateLevelPrice", ResourceType = typeof(PaymentResource))]
        public double AssociateLevelPrice { get; set; }

        [Required(ErrorMessageResourceName = "Vld_CoursePriceRequired", ErrorMessageResourceType = typeof(PaymentResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_CoursePriceGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "DiplomaLevelPrice", ResourceType = typeof(PaymentResource))]
        public double DiplomaLevelPrice { get; set; }
    }

    internal class PaymentSettingMetaData
    {
        [Required]
        [Display(Name = "MD_College", ResourceType = typeof(PaymentResource))]
        public int CollegeID { get; set; }

        [Required]
        [Display(Name = "MD_Term", ResourceType = typeof(PaymentResource))]
        public int AcademicYearTermID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_MinimumGuaranteeGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "MD_MinimumGuarantee", ResourceType = typeof(PaymentResource))]
        public int MinimumGuarantee { get; set; }

        [Required]
        [Display(Name = "MD_OJTFactor", ResourceType = typeof(PaymentResource))]
        public int OJTFactor { get; set; }

        [Required]
        [Display(Name = "MD_IsDroppedOutStudentsIncludedInPayment", ResourceType = typeof(PaymentResource))]
        public Nullable<bool> IsDroppedOutStudentsIncludedInPayment { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_PlannedStudentNoGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "MD_PlannedStudentNo", ResourceType = typeof(PaymentResource))]
        public Nullable<int> PlannedStudentNo { get; set; }

        [Required]
        [Display(Name = "MD_AttritionPercentage", ResourceType = typeof(PaymentResource))]
        public Nullable<double> AttritionPercentage { get; set; }

        [Required]
        [Display(Name = "MD_AttendancePayablePercentage", ResourceType = typeof(PaymentResource))]
        public double AttendancePayablePercentage { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "Vld_AcademicYearPriceGT0", ErrorMessageResourceType = typeof(PaymentResource))]
        [Display(Name = "MD_AcademicYearPrice", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> AcademicYearPrice { get; set; }
    }
}
