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
       
    public partial class GetTermEnrollmentListOSH
    { 
        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public int AcademicYearTermID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int StageID { get; set; }
        public bool IsIntake { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int IntakeBatchID { get; set; }
        public int BatchDetailID { get; set; }
        public string AcademicYearTermName { get; set; }
        public string IntakeTerm { get; set; }
        public string StudentNameAr { get; set; }
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string StageName { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string AcademicYearName { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
        public System.DateTime AcademicYearTermStartDate { get; set; }
        public System.DateTime AcademicYearTermEndDate { get; set; }
        public int CollegeID { get; set; }
        public int CollegeTypeID { get; set; }
        public string CollegeName { get; set; }
        public string SpecializationName { get; set; }
        public string LoginName { get; set; }
        public string CollegeNameAr { get; set; }
        public string SpecializationNameAr { get; set; }
        public string StageNameAr { get; set; }
        public int ProgramID { get; set; }
    }
}
