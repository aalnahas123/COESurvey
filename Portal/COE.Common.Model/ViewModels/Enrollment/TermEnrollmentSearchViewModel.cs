using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class TermEnrollmentSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "FullName", ResourceType = typeof(EnrollmentResources))]
        public string FullName { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(EnrollmentResources))]
        public string NationalId { get; set; }

        [Display(Name = "College", ResourceType = typeof(EnrollmentResources))]
        public int? CollegeID { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(EnrollmentResources))]
        public int? SpecializationID { get; set; }

        [Display(Name = "Stage", ResourceType = typeof(EnrollmentResources))]
        public int? StageId { get; set; }

        [Display(Name = "Status", ResourceType = typeof(EnrollmentResources))]
        public short? StatusId { get; set; }

        [Required]
        [Display(Name = "AcademicYear", ResourceType = typeof(EnrollmentResources))]
        public int? AcademicYearTermId { get; set; }

        public int? AcademicYearId { get; set; }

        public StaticPagedList<TermEnrollmentViewModel> Items { get; set; }
    }
}
