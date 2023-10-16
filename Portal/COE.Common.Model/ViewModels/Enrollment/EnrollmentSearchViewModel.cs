using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PagedList;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentSearchViewModel : BaseSearchViewModel
    {
        public EnrollmentSearchViewModel()
        {
            AcademicYearIdList = new int[] { };
            AcademicYearTermIdList = new int[] { };
        }

        [Display(Name = "College", ResourceType = typeof(EnrollmentResources))]
        public int? CollegeID { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(EnrollmentResources))]
        public int? SpecializationID { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string NationalId { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(EnrollmentResources))]
        public string FullName { get; set; }

        [Display(Name = "Stage", ResourceType = typeof(EnrollmentResources))]
        public int? StageId { get; set; }

        [Display(Name = "Stage", ResourceType = typeof(EnrollmentResources))]
        public int? RequestStageId { get; set; }

        [Display(Name = "Status", ResourceType = typeof(EnrollmentResources))]
        public short? StatusId { get; set; }

        [Display(Name = "Stage", ResourceType = typeof(EnrollmentResources))]
        public int? RequestDetailStageId { get; set; }

        #region AcademicYear For Muti selected
        [Display(Name = "AcademicYear", ResourceType = typeof(SharedResources))]
        public int? AcademicYearId { get; set; }
        public int[] AcademicYearIdList { get; set; }
        public string AcademicYearIdListStr { get; set; }
        #endregion

        #region AcademicYearTerm For Muti selected

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(SharedResources))]
        public int? AcademicYearTermId { get; set; }
        public int[] AcademicYearTermIdList { get; set; }
        // to cast academic year term id array string comma separated
        public string AcademicYearTermIdListStr { get; set; }

        #endregion

        [Display(Name = "DateFrom", ResourceType = typeof(SharedResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(SharedResources))]
        public DateTime? DateTo { get; set; }

        public bool SelectAll { get; set; }

        public StaticPagedList<EnrollmentViewModel> Items { get; set; }
        public StaticPagedList<TermEnrollmentViewModel> TermEnrollmentItems { get; set; }

        #region Change Status Filters
        public int[] StagesIds { get; set; }
        #endregion

    }
}
