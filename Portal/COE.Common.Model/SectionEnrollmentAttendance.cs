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
       
    public partial class SectionEnrollmentAttendance
    { 
        public int ID { get; set; }
        public int SectionEnrollmentID { get; set; }
        public Nullable<int> SectionAttendanceSettingID { get; set; }
        public decimal Attended { get; set; }
        public decimal Excused { get; set; }
        public decimal Extra { get; set; }
        public int OJT { get; set; }
        public int UploadRequestID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual SectionEnrollment SectionEnrollment { get; set; }
        public virtual UploadRequest UploadRequest { get; set; }
        public virtual SectionAttendanceSetting SectionAttendanceSetting { get; set; }
    }
}
