using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(CollegeAcademicYearPeriodMetaData))]
    public partial class CollegeAcademicYearPeriod
    {
    }
    class CollegeAcademicYearPeriodMetaData
    {
        public int ID { get; set; }

        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        public int CollegeAcademicYearID { get; set; }

        [Display(Name = "AcademicYearTermPeriod", ResourceType = typeof(PeriodResources))]
        public int AcademicYearTermPeriodID { get; set; }
    }
}
