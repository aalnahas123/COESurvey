//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COE.Common.Model
{
     
    using System;
    using System.Collections.Generic;
       
    public partial class ContractTermPaymentSetting
    { 
        public int ID { get; set; }
        public int ContractCollegeAcademicYearID { get; set; }
        public int AcademicYearTermID { get; set; }
        public int MinimumGuarantee { get; set; }
        public Nullable<int> PlannedStudentNo { get; set; }
        public Nullable<double> ExpectedAttritionPercentage { get; set; }
        public Nullable<int> EnrollmentBeforeAttrition { get; set; }
        public bool IsDroppedOutStudentsIncludedInPayment { get; set; }
        public Nullable<double> RequiredHoursPerStudent { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual AcademicYearTerm AcademicYearTerm { get; set; }
        public virtual ContractCollegeAcademicYear ContractCollegeAcademicYear { get; set; }
    }
}
