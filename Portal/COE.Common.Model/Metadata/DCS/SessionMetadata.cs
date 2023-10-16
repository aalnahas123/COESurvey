using System;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;
//using COE.Cources.Localization.Training;

//using COE.Cources.Localization;
using PagedList;
using System.Collections.Generic;
using COE.Common.Model.ViewModels;
using COE.Common.Localization;

namespace COE.Common.Model
{
    [MetadataType(typeof(SectionMetadata))]
    public partial class Section
    {

        public int[] UserProgramsIds { get; set; }

        public int? PreservedSeats { get; set; }
        public bool? JoinedByCurrentUser { get; set; }

        public bool? StatusValue { get; set; }

        public int? ToClassId { get; set; }
        public int? FromClassId { get; set; }

        public int? SubProgramId { get; set; }
        public int? CourseId { get; set; }

        public int TraineeTypeId { get; set; }

        public int TraineesCount { get; set; }

        public string TraineeName { get; set; }

        public string TraineeClass { get; set; }

        public string TraineeCenter { get; set; }

        public int? MainProgramId { get; set; }

        public string CenterNameValue { get; set; }
        public string SessionNameAr { get; set; }

        public string CourseNameValue { get; set; }
        public string SubProgramNameValue { get; set; }
        public string ProgramNameValue { get; set; }

        //  [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public string nationalIds { get; set; }

        public Nullable<System.DateTime> CourseStartDate { get; set; }
        public Nullable<System.DateTime> CourseEndDate { get; set; }


        public string CourseStartDateStr { get; set; }
        public string CourseEndDateStr { get; set; }

        public int CourseCollengeId { get; set; }

        public string TodayDayStr { get; set; }
        public string TodayDateStr { get; set; }

        public string SessionTimeStr { get; set; }

        public string NationalId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public int? ClassSessionId { get; set; }
        public decimal SectionCreditHours { get; set; }


        #region Filters  Properties 

        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public int? FilterClassId { get; set; }

        [Display(Name = "Courses", ResourceType = typeof(DCSResources))]
        public int? FilterCentersCourseId { get; set; }

        [Display(Name = "Status", ResourceType = typeof(DCSResources))]
        public byte? FilterStatus { get; set; }

        [Display(Name = "ClassType", ResourceType = typeof(DCSResources))]
        public int? FilterTraineeTypeId { get; set; }

        [Display(Name = "Centers", ResourceType = typeof(DCSResources))]
        public int? FilterCenterId { get; set; }

        [Display(Name = "Cities", ResourceType = typeof(DCSResources))]
        public int? FilterCityId { get; set; }

        [Display(Name = "Branches", ResourceType = typeof(DCSResources))]
        public int? FilterAreaId { get; set; }


        #endregion

        #region View  Properties 

        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public string ViewClassTime { get; set; }

        [Display(Name = "Courses", ResourceType = typeof(DCSResources))]
        public string ViewCourses { get; set; }

        [Display(Name = "Programme", ResourceType = typeof(DCSResources))]
        public string ViewProgramme { get; set; }

        [Display(Name = "Centers", ResourceType = typeof(DCSResources))]
        public string ViewCenter { get; set; }

        [Display(Name = "Cities", ResourceType = typeof(DCSResources))]
        public string ViewCity { get; set; }

        [Display(Name = "Branches", ResourceType = typeof(DCSResources))]
        public string ViewAreaName { get; set; }

        [Display(Name = "Status", ResourceType = typeof(DCSResources))]
        public string ViewAStatus { get; set; }

        [Display(Name = "ClassType", ResourceType = typeof(DCSResources))]
        public string ViewTraineeType { get; set; }

        [Display(Name = "ClassStartDate", ResourceType = typeof(DCSResources))]
        public string ViewStartDate { get; set; }

        [Display(Name = "ClassEndDate", ResourceType = typeof(DCSResources))]
        public string ViewEndDate { get; set; }

        [Display(Name = "ClassStartTime", ResourceType = typeof(DCSResources))]
        public string ViewStartTime { get; set; }

        [Display(Name = "ClassOfDays", ResourceType = typeof(DCSResources))]
        public string ViewClassDays { get; set; }

        [Display(Name = "ClassEndTime", ResourceType = typeof(DCSResources))]
        public string ViewEndTime { get; set; }

        [Display(Name = "NumberSeats", ResourceType = typeof(DCSResources))]
        public byte ViewNumberSeats { get; set; }

        #endregion

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

        public StaticPagedList<Section> Items { get; set; }
        public List<SectionEnrollment> Students { get; set; }

        public List<TeacherAttendance> TeachersAttendance { get; set; }
        public List<TeacherAttendance> SubsituteTeachers { get; set; }

        public StaticPagedList<AccountViewModelUserAdmin> CenterStudents { get; set; }

        public StaticPagedList<SessionAttendanceSettingSchedule> AttendenceDays { get; set; }

        public List<SessionAttendanceSettingSchedule> StudentAttendenceDays { get; set; }

        public TimeSpan MinimumTime { get; set; }
        public TimeSpan MaximumTime { get; set; }

        internal class SectionMetadata
        {
            //[Range(1, 999)]
            //[NumbersOnly, Display(Name = "NumberSeats", ResourceType = typeof(TrainingResource))]
            //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
            //public int SeatsCount { get; set; }

            //[Display(Name = "TraineeType", ResourceType = typeof(TrainingResource))]
            //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
            //public int TraineeTypeId { get; set; }

        }
    }
}
