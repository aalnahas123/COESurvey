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
       
    public partial class EnrollmentRequestDetail
    { 
        public int ID { get; set; }
        public int EnrollmentRequestID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int Priority { get; set; }
        public int StageID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int BatchID { get; set; }
    
        public virtual Stage Stage { get; set; }
        public virtual EnrollmentRequest EnrollmentRequest { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual CollegeSpecialization CollegeSpecialization { get; set; }
    }
}
