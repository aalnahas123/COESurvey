using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(QualificationPeriodMetaData))]
    public partial class QualificationPeriod
    {
        [Display(Name = "AcademicYear", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearID { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Programs", ResourceType = typeof(QualificationPeriodResources))]
        public int CollegeTypeId { get; set; }

        [Display(Name = "AcademicYearTermStartDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermStartDate { get; set; }

        [Display(Name = "AcademicYearTermEndDate", ResourceType = typeof(PeriodResources))]
        public DateTime? AcademicYearTermEndDate { get; set; }

        [Display(Name = "Colleges", ResourceType = typeof(QualificationPeriodResources))]
        public int[] SelectedCollegesIds { get; set; }
    }

    public class QualificationPeriodMetaData
    {
        [Display(Name = "PeriodCode", ResourceType = typeof(PeriodResources))]
        [MaxLength(250, ErrorMessageResourceType = typeof(PeriodResources), ErrorMessageResourceName = "PeriodCodeMaxLength")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string PeriodCode { get; set; }

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(PeriodResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int AcademicYearTermID { get; set; }

        [RequiredIf("EnrollmentEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EnrollmentStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EnrollmentStartDate { get; set; }

        [RequiredIf("EnrollmentStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EnrollmentEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("EnrollmentStartDate", ErrorMessageResourceName = "EnrollmentEndDateMustBeGreaterThanEnrollmentStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? EnrollmentEndDate { get; set; }

        [RequiredIf("CapstoneBookingEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CapstoneBookingStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CapstoneBookingStartDate { get; set; }

        [RequiredIf("CapstoneBookingStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CapstoneBookingEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("CapstoneBookingStartDate", ErrorMessageResourceName = "CapstoneBookingStartDateMustBeGreaterThanCapstoneBookingEndDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? CapstoneBookingEndDate { get; set; }

        [RequiredIf("CBTBookingEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CBTBookingStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CBTBookingStartDate { get; set; }

        [RequiredIf("CBTBookingStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CBTBookingEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("CBTBookingStartDate", ErrorMessageResourceName = "CBTBookingEndDateMustBeGreaterThanCBTBookingStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? CBTBookingEndDate { get; set; }

        [RequiredIf("PathwayChangeEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PathwayChangeStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? PathwayChangeStartDate { get; set; }

        [RequiredIf("PathwayChangeStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PathwayChangeEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("PathwayChangeStartDate", ErrorMessageResourceName = "PathwayChangeEndDateMustBeGreaterThanPathwayChangeStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? PathwayChangeEndDate { get; set; }

        [RequiredIf("TraineeStatusChangeEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TraineeStatusChangeStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? TraineeStatusChangeStartDate { get; set; }

        [RequiredIf("TraineeStatusChangeStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TraineeStatusChangeEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("TraineeStatusChangeStartDate", ErrorMessageResourceName = "TraineeStatusChangeEndDateMustBeGreaterThanTraineeStatusChangeStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? TraineeStatusChangeEndDate { get; set; }

        [RequiredIf("AppealsWindowEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AppealsWindowStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? AppealsWindowStartDate { get; set; }

        [RequiredIf("AppealsWindowStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //

        [Display(Name = "AppealsWindowEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("AppealsWindowStartDate", ErrorMessageResourceName = "AppealsWindowEndDateMustBeGreaterThanAppealsWindowStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? AppealsWindowEndDate { get; set; }

        [RequiredIf("MalpracticeWindowEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "MalpracticeWindowStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? MalpracticeWindowStartDate { get; set; }

        [RequiredIf("MalpracticeWindowStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "MalpracticeWindowEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("MalpracticeWindowStartDate", ErrorMessageResourceName = "MalpracticeWindowEndDateMustBeGreaterThanMalpracticeWindowStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? MalpracticeWindowEndDate { get; set; }

        [RequiredIf("PublishProvisionalResultEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PublishProvisionalResultStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? PublishProvisionalResultStartDate { get; set; }

        [RequiredIf("PublishProvisionalResultStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PublishProvisionalResultEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("PublishProvisionalResultStartDate", ErrorMessageResourceName = "PublishProvisionalResultEndDateMustBeGreaterThanPublishProvisionalResultStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? PublishProvisionalResultEndDate { get; set; }

        [RequiredIf("PublishFinalResultEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PublishFinalResultStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? PublishFinalResultStartDate { get; set; }

        [RequiredIf("PublishFinalResultStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "PublishFinalResultEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("PublishFinalResultStartDate", ErrorMessageResourceName = "PublishFinalResultEndDateMustBeGreaterThanPublishFinalResultStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? PublishFinalResultEndDate { get; set; }

        [RequiredIf("CapstoneReleasetoCenterEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CapstoneReleasetoCenterStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CapstoneReleasetoCenterStartDate { get; set; }

        [RequiredIf("CapstoneReleasetoCenterStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CapstoneReleasetoCenterEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("CapstoneReleasetoCenterStartDate", ErrorMessageResourceName = "CapstoneReleasetoCenterEndDateMustBeGreaterThanCapstoneReleasetoCenterStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? CapstoneReleasetoCenterEndDate { get; set; }


        [Display(Name = "CustomEventCenterStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CustomEventCenterStartDate { get; set; }

        [RequiredIf("CustomEventCenterStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CustomEventCenterEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("CustomEventCenterStartDate", ErrorMessageResourceName = "CustomEventCenterEndDateMustBeGreaterThanCustomEventCenterStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? CustomEventCenterEndDate { get; set; }


        [RequiredIf("EportfolioBookingEndDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EportfolioBookingStartDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EportfolioBookingStartDate { get; set; }

        [RequiredIf("EportfolioBookingStartDate.HasValue == true", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EportfolioBookingEndDate", ResourceType = typeof(QualificationPeriodResources))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateMustBeGreaterThan("EportfolioBookingStartDate", ErrorMessageResourceName = "EportfolioBookingEndDateMustBeGreaterThanEportfolioBookingStartDate", ErrorMessageResourceType = typeof(QualificationPeriodResources))]
        public DateTime? EportfolioBookingEndDate { get; set; }


    }

}
