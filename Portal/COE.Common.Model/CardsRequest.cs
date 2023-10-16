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
       
    public partial class CardsRequest
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardsRequest()
        {
            this.StudentCardsRequest = new HashSet<StudentCardsRequest>();
        }
    
        public int ID { get; set; }
        public int RequestNo { get; set; }
        public int CollegeID { get; set; }
        public Nullable<int> NoOfStudents { get; set; }
        public Nullable<int> NoOfRejected { get; set; }
        public Nullable<int> NoOfAccepted { get; set; }
        public string FileUrl { get; set; }
        public int CardsRequestTypeID { get; set; }
        public int RequestStatusID { get; set; }
        public Nullable<int> FileAutoGenerationStatusID { get; set; }
        public Nullable<int> ReplyUploadRequestID { get; set; }
        public string ReplyFileRequestNo { get; set; }
        public Nullable<int> ReplyFileNoOfRecords { get; set; }
        public Nullable<int> ReplyFileNoOfAccepted { get; set; }
        public Nullable<int> ReplyFileNoOfRejected { get; set; }
        public Nullable<int> FileGenerationProgress { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual CardsRequestType CardsRequestType { get; set; }
        public virtual FileAutoGenerationStatus FileAutoGenerationStatus { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual UploadRequest UploadRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCardsRequest> StudentCardsRequest { get; set; }
        public virtual College College { get; set; }
    }
}
