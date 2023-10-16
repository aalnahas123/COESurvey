using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Exam.Model.ViewModels
{
    public class ExamBookingSearchViewModel
    {
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Program")]
        public int? ProgramId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "College")]
        public int? CollegeId { get; set; }

        public int[] Colleges { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public int? QualificationId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentType")]
        public int? AssessmentTypeId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentStatus")]
        public int? AssessmentStatusId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AcademicYear")]
        public int? AcademicYearId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AcademicTerm")]
        public int? TermId { get; set; }

        public Guid UserdisplayId { get; set; }
        public string FullName { get; set; }

        [Display(Name = "DateFrom", ResourceType = typeof(SharedResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(SharedResources))]
        public DateTime? DateTo { get; set; }

        public TestCenterCounts BookingsCounts { get; set; }

    }

    public class TestCenterCounts
    {
        public int OpenBookingsCount { get; set; }

        public int ConfirmedBookingsCount { get; set; }

        public int UpcomingBookingsCount { get; set; }
    }
}
