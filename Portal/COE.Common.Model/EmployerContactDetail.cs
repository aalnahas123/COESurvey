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
       
    public partial class EmployerContactDetail
    { 
        public int ID { get; set; }
        public int EmployerID { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string Location { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string TelNo1 { get; set; }
        public string TelNo2 { get; set; }
        public string FaxNo { get; set; }
        public string OfficialEmail { get; set; }
        public string SupportEmail { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual Employer Employer { get; set; }
    }
}
