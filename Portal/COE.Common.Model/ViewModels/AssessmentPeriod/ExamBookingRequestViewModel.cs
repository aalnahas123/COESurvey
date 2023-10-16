using COE.Common.Localization;
using COE.Common.Model;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Exam.Model.ViewModels
{
    public class ExamBookingRequestViewModel
    {
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriod")]
        public string AssessmentPeriod { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "ExamBookingType")]
        public int ExamBookingTypeID { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "ExamBookingType")]
        public string ExamBookingType { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookingCode")]
        public string BookingCode { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookingStatus")]
        public string BookingStatus { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentComponent")]
        public string AssessmentComponent { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookingType")]
        public string BookingType { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedTrainees")]
        public int BookedTrainees { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedOn")]
        public string BookedOn { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedFor")]
        public string BookedFor { get; set; }
        public int ID { get; set; }
        public int SpecializationId { get; set; }
        public int AcademicYearTermId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public int QualificationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "College")]
        public int CollegeId { get; set; }
        public int AssessmentComponentId { get; set; }
        public int AssessmentPeriodId { get; set; }
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartDate")]
        public string StartDateStr { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndDate")]
        public string EndDateStr { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartTime")]
        public TimeSpan StartTime { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndTime")]
        public TimeSpan EndTime { get; set; }
        public List<StudentExamBookingViewModel> Students { get; set; }

        public bool IsFlexibleDateEditing { get; set; }

        public string CalenderDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriodCode")]
        public string AssessmentPeriodCode { get; set; }

        public DateTime testDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "NewState")]
        public bool New { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Resit")]
        public bool Resit { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "NationalId")]
        public string NationalIds { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "MaxSlotsNumber")]
        [NumbersOnly]
        public int MaxSlotsNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "MinSlotsNumber")]
        [NumbersOnly]
        public int MinSlotsNumber { get; set; }

        [Display(ResourceType = typeof(AppResources), Name = "Gender")]
        public bool? IsMale { get; set; }
        public string AccessCode { get; set; }
        public bool CanViewAccessCode { get; set; }
        public List<ExamCalendarRequestComments> Comments { get; set; }
        public bool CanComment { get; set; }
    }
}