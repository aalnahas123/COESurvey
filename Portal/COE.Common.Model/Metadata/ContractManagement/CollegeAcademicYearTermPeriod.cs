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
    [MetadataType(typeof(CollegeAcademicYearTermPeriodMetaData))]
    public partial class CollegeAcademicYearTermPeriod
    {
        [Display(Name = "AcademicYear", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearID { get; set; }

        //public int CollegeID { get; set; }

        //[Display(Name = "Term", ResourceType = typeof(PeriodResources))]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //public int TermID { get; set; }

        [Display(Name = "AcademicYearTermStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermStartDate { get; set; }

        [Display(Name = "AcademicYearTermEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermEndDate { get; set; }
    }

    class CollegeAcademicYearTermPeriodMetaData
    {
        [Display(Name = "College", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CollegeAcademicYearID { get; set; }

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearTermID { get; set; }

        [Display(Name = "AdmissionStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionStartDate { get; set; }

        [Display(Name = "AdmissionEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("AdmissionStartDate", ErrorMessageResourceName = "AdmissionEndDateMustBeGreaterThanAdmissionStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? AdmissionEndDate { get; set; }

        [Display(Name = "RegistrationStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? RegistrationStartDate { get; set; }

        [Display(Name = "RegistrationEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("RegistrationStartDate", ErrorMessageResourceName = "RegistrationStartDateMustBeGreaterThanRegistrationStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? RegistrationEndDate { get; set; }

        [Display(Name = "DissmisStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DissmisStartDate { get; set; }

        [Display(Name = "DissmisEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("DissmisStartDate", ErrorMessageResourceName = "DissmisEndDateMustBeGreaterThanDissmisStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DissmisEndDate { get; set; }

        [Display(Name = "TransferStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? TransferStartDate { get; set; }

        [Display(Name = "TransferEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("TransferStartDate", ErrorMessageResourceName = "TransferEndDateMustBeGreaterThanTransferStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? TransferEndDate { get; set; }

        [Display(Name = "DeferralStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DeferralStartDate { get; set; }

        [Display(Name = "DeferralEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("DeferralStartDate", ErrorMessageResourceName = "DeferralEndDateMustBeGreaterThanDeferralStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? DeferralEndDate { get; set; }

        [Display(Name = "ExamStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? ExamStartDate { get; set; }

        [Display(Name = "ExamEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("ExamStartDate", ErrorMessageResourceName = "ExamEndDateMustBeGreaterThanExamStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? ExamEndDate { get; set; }

        [Display(Name = "WithDrawStartDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? WithDrawStartDate { get; set; }

        [Display(Name = "WithDrawEndDate", ResourceType = typeof(PeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DateMustBeLessThan("AcademicYearTermEndDate", ErrorMessageResourceName = "DateMustBeLessThanAcademicYearTermEndDate", ErrorMessageResourceType = typeof(PeriodResources))]
        [DateMustBeGreaterThan("WithDrawStartDate", ErrorMessageResourceName = "WithDrawEndDateMustBeGreaterThanWithDrawStartDate", ErrorMessageResourceType = typeof(PeriodResources))]
        public DateTime? WithDrawEndDate { get; set; }


    }

}
