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
       
    public partial class ComplaintRequest
    { 
        public int ID { get; set; }
        public Nullable<int> EnrollmentID { get; set; }
        public System.Guid UserID { get; set; }
        public Nullable<long> RequestId { get; set; }
        public int ComplaintTypeID { get; set; }
        public string ComplaintSupject { get; set; }
        public string ComplaintDescription { get; set; }
        public int ProgramID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual Program Program { get; set; }
        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual ComplaintType ComplaintType { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public virtual Request Request { get; set; }
    }
}
