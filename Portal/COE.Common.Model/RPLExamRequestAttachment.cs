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
       
    public partial class RPLExamRequestAttachment
    { 
        public int Id { get; set; }
        public System.Guid AttachmentID { get; set; }
        public int RPLExamRequestID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual Attachments Attachment { get; set; }
        public virtual RPLExamRequest RPLExamRequest { get; set; }
    }
}
