using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ContractCollegeAcademicYearViewModel : BaseViewModel
    {
        public ContractCollegeAcademicYearViewModel()
        {
        }

        [Display(Name = "ContractCollegeAcademicYear_ContractID", ResourceType = typeof(MetaData))]
        public int ContractID { get; set; }

        [Display(Name = "ContractCollegeAcademicYear_AcademicYearID", ResourceType = typeof(MetaData))]
        public int AcademicYearID { get; set; }

        public int ContractTypeID { get; set; }

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

        public List<ContractTermPaymentSettingViewModel> ContractTermPaymentSettings { get; set; }


        [Display(Name = "ContractCollegeAcademicYear_AcademicYearID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedAcademicYearID { get; set; }


        [Display(Name = "ContractCollegeAcademicYear_CollegeID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedCollegeID { get; set; }
    }
}
