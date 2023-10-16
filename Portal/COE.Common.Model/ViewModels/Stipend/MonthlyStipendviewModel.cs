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
    public class MonthlyStipendviewModel
    {
        [Required]
        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public int YearId { get; set; }

        [Required]
        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public int MonthId { get; set; }

        [Required]
        [Display(Name = "Stipend_Title_Periods", ResourceType = typeof(StipendResources))]
        public int PeriodId { get; set; }


        public int StipendType { get; set; }

    }
}
