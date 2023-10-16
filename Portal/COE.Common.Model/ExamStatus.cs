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
       
    public partial class ExamStatus
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamStatus()
        {
            this.EnglishExamResult = new HashSet<EnglishExamResult>();
            this.VocationalExamResult = new HashSet<VocationalExamResult>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int ExamTypeID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnglishExamResult> EnglishExamResult { get; set; }
        public virtual ExamType ExamType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VocationalExamResult> VocationalExamResult { get; set; }
    }
}
