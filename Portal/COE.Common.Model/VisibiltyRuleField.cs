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
       
    public partial class VisibiltyRuleField
    { 
        public int ID { get; set; }
        public int VisibiltyRuleID { get; set; }
        public int ModuleFieldID { get; set; }
        public int FieldVisibilityID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual FieldVisibilty FieldVisibilty { get; set; }
        public virtual ModuleField ModuleField { get; set; }
        public virtual VisibitlyRule VisibitlyRule { get; set; }
    }
}
