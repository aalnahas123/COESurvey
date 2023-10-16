using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(ContractTermPaymentSettingMetaData))]
    public partial class ContractTermPaymentSetting
    {
        class ContractTermPaymentSettingMetaData
        {
            [Display(Name = "ContractTermPaymentSetting_ContractCollegeAcademicYearID", ResourceType = typeof(MetaData))]
            [Required]
            public int ContractCollegeAcademicYearID { get; set; }

            [Display(Name = "ContractTermPaymentSetting_AcademicYearTermID", ResourceType = typeof(MetaData))]
            [Required]
            public int AcademicYearTermID { get; set; }

            [Display(Name = "ContractTermPaymentSetting_MinimumGuarantee", ResourceType = typeof(MetaData))]

            public int MinimumGuarantee { get; set; }

            [Display(Name = "ContractTermPaymentSetting_PlannedStudentNo", ResourceType = typeof(MetaData))]
            public Nullable<int> PlannedStudentNo { get; set; }

            [Display(Name = "ContractTermPaymentSetting_ExpectedAttritionPercentage", ResourceType = typeof(MetaData))]
            public Nullable<double> ExpectedAttritionPercentage { get; set; }

            [Display(Name = "ContractTermPaymentSetting_EnrollmentBeforeAttrition", ResourceType = typeof(MetaData))]
            public Nullable<int> EnrollmentBeforeAttrition { get; set; }

            [Display(Name = "ContractTermPaymentSetting_IsDroppedOutStudentsIncludedInPayment", ResourceType = typeof(MetaData))]
            public bool IsDroppedOutStudentsIncludedInPayment { get; set; }

            [Display(Name = "ContractTermPaymentSetting_RequiredHoursPerStudent", ResourceType = typeof(MetaData))]
            public Nullable<double> RequiredHoursPerStudent { get; set; }
        }
    }

}
