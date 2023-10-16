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
       
    public partial class CollegeSpecialization
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CollegeSpecialization()
        {
            this.Batch = new HashSet<Batch>();
            this.EnglishExamResult = new HashSet<EnglishExamResult>();
            this.Enrollment = new HashSet<Enrollment>();
            this.EnrollmentRequestDetail = new HashSet<EnrollmentRequestDetail>();
            this.TermEnrollment = new HashSet<TermEnrollment>();
            this.TransferRequest = new HashSet<TransferRequest>();
            this.VocationalExamResult = new HashSet<VocationalExamResult>();
            this.TransferVistorRequest = new HashSet<TransferVistorRequest>();
        }
    
        public int ID { get; set; }
        public int CollegeID { get; set; }
        public int SpecializationID { get; set; }
        public Nullable<int> IntakeTermID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> ExpiryTermID { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual AcademicYearTerm AcademicYearTerm { get; set; }
        public virtual AcademicYearTerm AcademicYearTerm1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batch { get; set; }
        public virtual College College { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnglishExamResult> EnglishExamResult { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollmentRequestDetail> EnrollmentRequestDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TermEnrollment> TermEnrollment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferRequest> TransferRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VocationalExamResult> VocationalExamResult { get; set; }
        public virtual Specialization Specialization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferVistorRequest> TransferVistorRequest { get; set; }
    }
}
