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
       
    public partial class DismissRequestReason
    { 
        public int ID { get; set; }
        public int DismissRequestID { get; set; }
        public int DismissReasonID { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual DismissReason DismissReason { get; set; }
        public virtual DismissRequest DismissRequest { get; set; }
    }
}
