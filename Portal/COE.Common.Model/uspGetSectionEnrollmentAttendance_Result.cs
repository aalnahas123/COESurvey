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
    
    public partial class uspGetSectionEnrollmentAttendance_Result
    {
        public int ID { get; set; }
        public string CourseNameAr { get; set; }
        public string CourseName { get; set; }
        public Nullable<decimal> ActualyAttenedHours { get; set; }
        public string SectionCode { get; set; }
        public decimal OfferedHours { get; set; }
        public decimal TotalHours { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public string YearNameAr { get; set; }
        public string YearName { get; set; }
        public string TermName { get; set; }
        public Nullable<decimal> AttendancePercentage { get; set; }
        public string MonthName { get; set; }
        public string SectionMonthName { get; set; }
    }
}
