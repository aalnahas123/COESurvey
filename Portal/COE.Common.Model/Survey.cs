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
       
    public partial class Survey
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Survey()
        {
            this.SurveyAnswer = new HashSet<SurveyAnswer>();
            this.SurveyQuestion = new HashSet<SurveyQuestion>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public string SurveyTitle { get; set; }
        public string Description { get; set; }
        public string SurveyText { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> AllowAnonymous { get; set; }
        public Nullable<bool> AllowMultiple { get; set; }
        public bool IsRTL { get; set; }

        public string ImageUrl { get; set; }

        public virtual SurveyModules SurveyModules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SurveyAnswer> SurveyAnswer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }
    }
}
