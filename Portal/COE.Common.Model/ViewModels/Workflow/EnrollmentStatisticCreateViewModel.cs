using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class EnrollmentStatisticCreateViewModel
    {
        public EnrollmentStatisticCreateViewModel()
        {
            this.CollegesList = new List<LookupViewModel>();
            this.EnrollmentStatisticTypeList = new List<LookupViewModel>();
            this.AcademicYearsList = new List<LookupViewModel>();
            this.AcademicYearTermsList = new List<LookupViewModel>();
        }
        public EnrollmentStatistic EnrollmentStatistic { get; set; }

        public DecisionViewModel Decision { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

        [Display(Name = "College_Name", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedCollegeID { get; set; }

        [Display(Name = "EnrollmentStatisticType_Name", ResourceType = typeof(MetaData))]
        [Required]
        public int? EnrollmentStatisticTypeID { get; set; }
        [Required]
        public int? AcademicYearTermID { get; set; }
        [Required]
        public int? AcademicYearID { get; set; }

        public List<LookupViewModel> CollegesList { get; set; }

        public List<LookupViewModel> EnrollmentStatisticTypeList { get; set; }

        public List<LookupViewModel> AcademicYearsList { get; set; }

        public List<LookupViewModel> AcademicYearTermsList { get; set; }
    }
}
