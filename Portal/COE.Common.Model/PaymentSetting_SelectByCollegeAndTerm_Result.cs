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
    
    public partial class PaymentSetting_SelectByCollegeAndTerm_Result
    {
        public int CollegeID { get; set; }
        public int AcademicYearTermID { get; set; }
        public int MinimumGuarantee { get; set; }
        public int OJTFactor { get; set; }
        public bool IsDroppedOutStudentsIncludedInPayment { get; set; }
        public Nullable<int> PlannedStudentNo { get; set; }
        public Nullable<double> AttritionPercentage { get; set; }
        public Nullable<decimal> AcademicYearPrice { get; set; }
        public int WaveID { get; set; }
        public int TermTypeID { get; set; }
    }
}
