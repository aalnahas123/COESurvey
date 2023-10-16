using COE.Common.Localization;
using COE.Common.Model.Enums;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasExamBookingViewModel
    {
        private DateTime examDate;
        private DateTime endDateTime;

        public string ScheduleCode { get; set; }
        public string ExamCode { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get => examDate.Hour == 0 ? examDate + ExamStartTime : examDate; set => examDate = value; }
        public DateTime EndDateTime { get => endDateTime.Hour == 0 ? endDateTime + ExamEndTime : endDateTime; set => endDateTime = value; }
        public string ExamCenterCode { get; set; }
        public string ExamCenterName { get; set; }
        public string ExamCenterLocationUrl { get; set; }
        public string QualificationCode { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public string PaymentAmount { get; set; }
        public string PaymentMaskedPAN { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPaid { get; set; }
        public int ExamBookingId { get; set; }
        public string LevelName { get; set; }
        public string CityName { get; set; }
        public string StatusName => ExamBookingId > 0
            ? IsPassTheExam.HasValue
                ? ExamBookingResources.Completed
                : (IsPaid && !IsCanceled
                    ? (IsSarasConfirmed.GetValueOrDefault() ? ExamBookingResources.Confirmed : ExamBookingResources.PaymentConfirmed)
                    : IsPaid && IsCanceled
                        ? (CancelationReason.HasValue && CancelationReason.Value == (int)RPLExamBookingCancelationReasons.ByAdmin ? ExamBookingResources.EmergencyCancelled : ExamBookingResources.Canceled)
                        : ExamBookingResources.Pending)
            : string.Empty;
        public string StatusColor => ExamBookingId > 0
           ? IsPassTheExam.HasValue
                ? "royalblue"
                : (IsPaid && !IsCanceled
                    ? (IsSarasConfirmed.GetValueOrDefault() ? "green" : "yellow")
                    : IsPaid && IsCanceled
                        ? (CancelationReason.HasValue && CancelationReason.Value == (int)RPLExamBookingCancelationReasons.ByAdmin ? "red" : "gray")
                        : ExamBookingResources.Pending)
            : string.Empty;
        public int ExamCalendarRequestId { get; set; }
        public bool ExamBookingConfirmied { get; set; } = false;
        public TimeSpan ExamStartTime { get; set; }
        public TimeSpan ExamEndTime { get; set; }
        public string ExamCenterAddress { get; set; }
        public string ExamCenterMobile { get; set; }

        public bool CanReschedule { get; set; }

        public string ExamURL { get; set; }
        public bool? IsSarasConfirmed { get; set; }

        [Display(Name = "ExamLanguage", ResourceType = typeof(ExamBookingResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public bool IsArabic { get; set; }

        [Display(Name = "IsAgreeOnPayPolicy", ResourceType = typeof(ExamBookingResources))]
        [MustBeTrue(ErrorMessageResourceType = typeof(ExamBookingResources), ErrorMessageResourceName = "MustAgreeOnPayPolicy")]
        public bool IsAgreeOnPayPolicy { get; set; }

        public bool? IsPassTheExam { get; set; }

        public string ExamResult => this.IsPassTheExam.HasValue
            ? (this.IsPassTheExam.Value ? ExamBookingResources.Pass : ExamBookingResources.Fail)
            : ExamBookingResources.PendingResult;

        public bool CanCancel { get; set; }
        public int? CancelationReason { get; set; }
        public int LevelId { get; set; }
        public bool CanReTakeExam { get; set; }
        public bool? isMale { get; set; }

        public string Gender => isMale.HasValue
            ? (isMale.Value ? AppResources.MaleColleges : AppResources.FemaleColleges)
            : $"{AppResources.MaleColleges} - {AppResources.FemaleColleges}";
    }
}
