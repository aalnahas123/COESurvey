using COE.Common.Localization;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class PeriodsViewModel : CommonMetaData
    {
        public int ID { get; set; }


        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public int? Year { get; set; }

        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public string YearName { get; set; }


        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public int? Month { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public string MonthName { get; set; }

        [Display(Name = "AcadimicYear", ResourceType = typeof(StipendResources))]
        public int? AcadimicYear { get; set; }

        [Display(Name = "AcadimicYear", ResourceType = typeof(StipendResources))]
        public string AcadimicYearName { get; set; }


        [Display(Name = "AcadimicTerm", ResourceType = typeof(StipendResources))]
        public int? AcadimicTerm { get; set; }

        [Display(Name = "AcadimicTerm", ResourceType = typeof(StipendResources))]
        public string AcadimicTermName { get; set; }


        [Display(Name = "FromDay", ResourceType = typeof(StipendResources))]
        public int? FromDay { get; set; }

        [Display(Name = "ToDay", ResourceType = typeof(StipendResources))]
        public int? ToDay { get; set; }

        [Display(Name = "DaysOfMonth", ResourceType = typeof(StipendResources))]
        public int DaysOfMonth{ get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public StaticPagedList<PeriodsViewModel> Items { get; set; }
    }
}
