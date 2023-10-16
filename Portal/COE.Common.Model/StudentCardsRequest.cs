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
       
    public partial class StudentCardsRequest
    { 
        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public Nullable<int> CardsFeedbackStatusID { get; set; }
        public Nullable<int> CardsFeedbackDenialReasonID { get; set; }
        public string CardNo { get; set; }
        public string BankIBAN { get; set; }
        public int CardsRequestID { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual CardsFeedbackDenialReason CardsFeedbackDenialReason { get; set; }
        public virtual CardsFeedbackStatus CardsFeedbackStatus { get; set; }
        public virtual CardsRequest CardsRequest { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
