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
       
    public partial class UploadRejectionReason
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UploadRejectionReason()
        {
            this.SectionEnrollmentAttendanceValidation = new HashSet<SectionEnrollmentAttendanceValidation>();
            this.SectionEnrollmentValidation = new HashSet<SectionEnrollmentValidation>();
            this.SectionValidation = new HashSet<SectionValidation>();
            this.TermCourseValidation = new HashSet<TermCourseValidation>();
            this.SessionValidation = new HashSet<SessionValidation>();
            this.CardsFeedbackValidation = new HashSet<CardsFeedbackValidation>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionEnrollmentAttendanceValidation> SectionEnrollmentAttendanceValidation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionEnrollmentValidation> SectionEnrollmentValidation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionValidation> SectionValidation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TermCourseValidation> TermCourseValidation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionValidation> SessionValidation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CardsFeedbackValidation> CardsFeedbackValidation { get; set; }
    }
}
