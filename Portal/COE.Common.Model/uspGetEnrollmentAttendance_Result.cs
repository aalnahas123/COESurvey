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
    
    public partial class uspGetEnrollmentAttendance_Result
    {
        public int AcademicYearId { get; set; }
        public string Name { get; set; }
        public string TermName { get; set; }
        public int SectionID { get; set; }
        public string SectionCode { get; set; }
        public int EnrollmentID { get; set; }
        public int SectionEnrollmentID { get; set; }
        public decimal Attended { get; set; }
        public decimal Excused { get; set; }
        public decimal Extra { get; set; }
        public int OJT { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal OfferedHours { get; set; }
        public string MonthNo { get; set; }
    }
}
