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
    public class ExamBookingListViewModel
    {
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookingCode")]
        public string BookingCode { get; set; }
        public string AcademicTerm { get; set; }
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "College")]
        public string College { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentType")]
        public string AssessmentType { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentStatus")]
        public string AssessmentStatus { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedTrainees")]
        public int BookedTrainees { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedOn")]
        public DateTime BookedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "BookedFor")]
        public string BookedFor { get; set; }
        public int RequestStatusID { get; set; }
        public int ExamCalendarStatusID { get; set; }
        public bool IsRequireApproval { get; set; }
        public bool IsFlexibleDateEditing { get; set; }
        public int ID { get; set; }
        public int StudentsCount { get; set; }
        public QualificationPeriod QualificationPeriod { get; set; }
        public string AssessmentComponent { get; set; }
        public bool CanEdit { get; set; }

    }

    public class ExamBookingViewModel
    {
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "NationalId")]
        public string NationalIds { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public int SpecializationID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "College")]
        public int CollegeId { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "ExamBookingType")]
        public int ExamBookingTypeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriod")]
        public int PeriodID { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartDate")]
        public string StartDateStr { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndDate")]
        public string EndDateStr { get; set; }
        //public DateTime TestDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "StartTime")]
        public TimeSpan StartTime { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "EndTime")]
        public TimeSpan EndTime { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriod")]
        public string CalenderDate { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriod")]
        public string AssessmentPeriod { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "AssessmentPeriodCode")]
        public string AssessmentPeriodCode { get; set; }
        public bool IsFlexibleDateEditing { get; set; }
        public bool IsSaved { get; set; }

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
    }

}
