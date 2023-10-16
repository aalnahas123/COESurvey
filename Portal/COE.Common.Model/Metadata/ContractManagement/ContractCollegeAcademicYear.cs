using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(ContractCollegeAcademicYearMetaData))]
    public partial class ContractCollegeAcademicYear
    {
        class ContractCollegeAcademicYearMetaData
        {

            [Display(Name = "ContractCollegeAcademicYear_CollegeID", ResourceType = typeof(MetaData))]
            public int CollegeID { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_Saudization", ResourceType = typeof(MetaData))]
            public Nullable<double> Saudization { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_BasePriceForFoundationStudent", ResourceType = typeof(MetaData))]
            public Nullable<int> BasePriceForFoundationStudent { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_BasePriceForAssociateStudent", ResourceType = typeof(MetaData))]
            public Nullable<int> BasePriceForAssociateStudent { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_BasePriceForDiplomaStudent", ResourceType = typeof(MetaData))]
            public Nullable<int> BasePriceForDiplomaStudent { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_FoundationStudentToTeacherRatio", ResourceType = typeof(MetaData))]
            public Nullable<double> FoundationStudentToTeacherRatio { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_VocationalStudentToTeacherRatio", ResourceType = typeof(MetaData))]
            public Nullable<double> VocationalStudentToTeacherRatio { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_PracticalStudentToTeacherRatio", ResourceType = typeof(MetaData))]
            public Nullable<double> PracticalStudentToTeacherRatio { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_PerformancePrice", ResourceType = typeof(MetaData))]
            public Nullable<int> PerformancePrice { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_InstitutionalReview", ResourceType = typeof(MetaData))]
            public Nullable<int> InstitutionalReview { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_Assessment", ResourceType = typeof(MetaData))]
            public Nullable<int> Assessment { get; set; }

            [Display(Name = "ContractCollegeAcademicYear_Employability", ResourceType = typeof(MetaData))]
            public Nullable<int> Employability { get; set; }
        }
    }

}
