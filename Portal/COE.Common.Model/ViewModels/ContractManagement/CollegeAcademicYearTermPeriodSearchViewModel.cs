using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class CollegeAcademicYearTermPeriodSearchViewModel : BaseSearchViewModel
    {
        public CollegeAcademicYearTermPeriodSearchViewModel()
        {
        }

        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        public int? CollegeAcademicYearID { get; set; }

        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        public int? CollegeID { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(PeriodResources))]
        public int? AcademicYearID { get; set; }

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(PeriodResources))]
        public int? AcademicYearTermID { get; set; }

        [Display(Name = "AdmissionStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionStartDate { get; set; }

        [Display(Name = "AdmissionEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionEndDate { get; set; }

        [Display(Name = "RegistrationStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? RegistrationStartDate { get; set; }

        [Display(Name = "RegistrationEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? RegistrationEndDate { get; set; }

        [Display(Name = "DissmisStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? DissmisStartDate { get; set; }

        [Display(Name = "DissmisEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? DissmisEndDate { get; set; }

        [Display(Name = "TransferStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? TransferStartDate { get; set; }

        [Display(Name = "TransferEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? TransferEndDate { get; set; }

        [Display(Name = "DeferralStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? DeferralStartDate { get; set; }

        [Display(Name = "DeferralEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? DeferralEndDate { get; set; }

        [Display(Name = "ExamStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? ExamStartDate { get; set; }

        [Display(Name = "ExamEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? ExamEndDate { get; set; }

        [Display(Name = "WithDrawStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? WithDrawStartDate { get; set; }

        [Display(Name = "WithDrawEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? WithDrawEndDate { get; set; }

        public StaticPagedList<CollegeAcademicYearTermPeriod> Items { get; set; }
    }
}
