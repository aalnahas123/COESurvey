using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Model;
using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StipendRequestFeedbackViewModel
    {
        public bool SelectAll { get; set; }
        public string SearchIds { get; set; }
        public bool IsDisabled { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public int CollegeID { get; set; }

        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public int YearId { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public int MonthId { get; set; }

        public int PeriodId { get; set; }

        //[Display(Name = "PeriodId", ResourceType = typeof(StipendResources))]
        //public int PeriodId { get; set; }

        public string Type { get; set; }
        public StipendsRequest StipendsRequest { get; set; }
        public StaticPagedList<StudentStipendsRequest> Items { get; set; }
        public StaticPagedList<StudentStipendViewModel> NewRequestItems { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }
}
