using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(AcademicYearTermPeriodMetaData))]
    public partial class AcademicYearTermPeriod
    {
        [Display(Name = "CollegeType", ResourceType = typeof(PeriodResources))]
        public int? CollegeTypeId { get; set; }

        [Display(Name = "AcademicYearTermStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermStartDate { get; set; }

        [Display(Name = "AcademicYearTermEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermEndDate { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearID { get; set; }

        [Display(Name = "Colleges", ResourceType = typeof(PeriodResources))]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int[] SelectedCollegesIds { get; set; }
    }

    class AcademicYearTermPeriodMetaData
    {
        [Display(Name = "PeriodCode", ResourceType = typeof(PeriodResources))]
        [MaxLength(250, ErrorMessageResourceType = typeof(PeriodResources), ErrorMessageResourceName = "PeriodCodeMaxLength")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string PeriodCode { get; set; }

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearTermID { get; set; }

        [RequiredIf("AdmissionEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AdmissionStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("RegistrationStartDate", ErrorMessageResourceName = "AdmissionStartDateMustBeGreaterThanRegistrationStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionStartDate { get; set; }

        [RequiredIf("AdmissionStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AdmissionEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("AdmissionStartDate", ErrorMessageResourceName = "AdmissionEndDateMustBeGreaterThanAdmissionStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionEndDate { get; set; }

        [RequiredIf("AdmissionStartDate.HasValue == true || RegistrationEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RegistrationStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationStartDate { get; set; }

        [RequiredIf("RegistrationStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RegistrationEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("RegistrationStartDate", ErrorMessageResourceName = "RegistrationStartDateMustBeGreaterThanRegistrationStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? RegistrationEndDate { get; set; }

        [RequiredIf("DissmisEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DissmisStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DissmisStartDate { get; set; }

        [RequiredIf("DissmisStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DissmisEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("DissmisStartDate", ErrorMessageResourceName = "DissmisEndDateMustBeGreaterThanDissmisStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DissmisEndDate { get; set; }

        [RequiredIf("TransferEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TransferStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? TransferStartDate { get; set; }

        [RequiredIf("TransferStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TransferEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("TransferStartDate", ErrorMessageResourceName = "TransferEndDateMustBeGreaterThanTransferStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? TransferEndDate { get; set; }

        [RequiredIf("DeferralEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DeferralStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeferralStartDate { get; set; }

        [RequiredIf("DeferralStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "DeferralEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("DeferralStartDate", ErrorMessageResourceName = "DeferralEndDateMustBeGreaterThanDeferralStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DeferralEndDate { get; set; }

        [RequiredIf("ExamEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExamStartDate { get; set; }

        [RequiredIf("ExamStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ExamEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("ExamStartDate", ErrorMessageResourceName = "ExamEndDateMustBeGreaterThanExamStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? ExamEndDate { get; set; }

        [RequiredIf("WithDrawEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WithDrawStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? WithDrawStartDate { get; set; }

        [RequiredIf("WithDrawStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "WithDrawEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("WithDrawStartDate", ErrorMessageResourceName = "WithDrawEndDateMustBeGreaterThanWithDrawStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? WithDrawEndDate { get; set; }

        [RequiredIf("NoShowEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NoShowStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? NoShowStartDate { get; set; }

        [RequiredIf("NoShowStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NoShowEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("NoShowStartDate", ErrorMessageResourceName = "NoShowEndDateMustBeGreaterThanNoShowStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? NoShowEndDate { get; set; }

        [RequiredIf("ChangeStatusEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ChangeStatusStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ChangeStatusStartDate { get; set; }

        [RequiredIf("ChangeStatusStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ChangeStatusEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("ChangeStatusStartDate", ErrorMessageResourceName = "ChangeStatusEndDateMustBeGreaterThanChangeStatusStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? ChangeStatusEndDate { get; set; }

        [RequiredIf("RenistateEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RenistateStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RenistateStartDate { get; set; }

        [RequiredIf("RenistateStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RenistateEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("RenistateStartDate", ErrorMessageResourceName = "RenistateEndDateMustBeGreaterThanRenistateStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? RenistateEndDate { get; set; }

    }

}
