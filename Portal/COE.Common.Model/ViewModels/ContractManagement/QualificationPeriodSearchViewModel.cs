using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class QualificationPeriodSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        public int? CollegeAcademicYearID { get; set; }

        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        public int? CollegeID { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(PeriodResources))]
        public int? AcademicYearID { get; set; }

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(PeriodResources))]
        public int? AcademicYearTermID { get; set; }

        [Display(Name = "PeriodCode", ResourceType = typeof(PeriodResources))]
        public string PeriodCode { get; set; }

        public StaticPagedList<QualificationPeriod> Items { get; set; }

    }
}
