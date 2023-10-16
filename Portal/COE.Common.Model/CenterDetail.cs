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
       
    public partial class CenterDetail
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CenterDetail()
        {
            this.CenterDetailTrainingTypes = new HashSet<CenterDetailTrainingType>();
        }
    
        public int ID { get; set; }
        public int CollegeID { get; set; }
        public string CenterManager { get; set; }
        public bool GeneralLicenseThreeMonth { get; set; }
        public bool PrivateLicenseHealthSafety { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual College College { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CenterDetailTrainingType> CenterDetailTrainingTypes { get; set; }
    }
}
