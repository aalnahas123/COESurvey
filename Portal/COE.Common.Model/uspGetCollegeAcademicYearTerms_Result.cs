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
    
    public partial class uspGetCollegeAcademicYearTerms_Result
    {
        public int ID { get; set; }
        public int AcademicYearID { get; set; }
        public int TermTypeID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TermOrdering { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string TermName { get; set; }
        public string TermNameAr { get; set; }
    }
}
