using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using PagedList;
using RM.Workflow;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class EnrollmentStatisticSearchViewModel : BaseSearchViewModel
    {
        public EnrollmentStatisticSearchViewModel()
        {
            this.CollegesList = new List<LookupViewModel>();
            this.EnrollmentStatisticTypeList = new List<LookupViewModel>();
            this.AcademicYearsList = new List<LookupViewModel>();
            this.AcademicYearTermsList = new List<LookupViewModel>();
        }

        public EnrollmentStatistic EnrollmentStatistic { get; set; }

        public StaticPagedList<EnrollmentStatistic> Items { get; set; }

        [Display(Name = "College_Name", ResourceType = typeof(MetaData))]
        public int? CollegeID { get; set; }

        [Display(Name = "EnrollmentStatisticType_Name", ResourceType = typeof(MetaData))]
        public int? EnrollmentStatisticTypeID { get; set; }

        public int? AcademicYearTermID { get; set; }

        public int? AcademicYearID { get; set;}

        public List<LookupViewModel> CollegesList { get; set; }

        public List<LookupViewModel> EnrollmentStatisticTypeList { get; set; }

        public List<LookupViewModel> AcademicYearsList { get; set; }

        public List<LookupViewModel> AcademicYearTermsList { get; set; }
    }
}
