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
       
    public partial class SurveyViewer
    { 
        public int ID { get; set; }
        public int SurveyId { get; set; }
        public string ViewerUsername { get; set; }
        public bool CanEdit { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
