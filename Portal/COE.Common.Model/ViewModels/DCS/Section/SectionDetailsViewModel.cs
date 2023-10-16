using COE.Common.Localization;
using Commons.Framework.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionDetailsViewModel
    {
        public int ID { get; set; }

        [Display(Name = "SectionCode", ResourceType = typeof(DCSResources))]
        public string SectionCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "TotalHours", ResourceType = typeof(DCSResources))]
        public decimal TotalHours { get; set; }

        [Display(Name = "CourseCode", ResourceType = typeof(DCSResources))]
        public string CourseCode { get; set; }

        [Display(Name = "CourseName", ResourceType = typeof(DCSResources))]
        public string CourseName { get; set; }

        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public string CollegeName { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(DCSResources))]
        public string Specialization { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "CreatedOn", ResourceType = typeof(DCSResources))]
        public string CreatedOn { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public string AcademicYear { get; set; }

        [Display(Name = "Term", ResourceType = typeof(DCSResources))]
        public string AcademicTerm { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "SectionStartDate", ResourceType = typeof(DCSResources))]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "SectionEndDate", ResourceType = typeof(DCSResources))]
        public DateTime EndDate { get; set; }

        [Display(Name = "SectionStartDate", ResourceType = typeof(DCSResources))]
        public string StartDateString { get { return DateTimeHelper.FromHijriDateToMiladiString(StartDate); } }


        [Display(Name = "SectionEndDate", ResourceType = typeof(DCSResources))]
        public string EndDateString { get { return DateTimeHelper.FromHijriDateToMiladiString(EndDate); } }

        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }

        public string LecturerName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public Guid LecturerId { get; set; }
        public int ScheduleId { get; set; }

        public string DayWeek { get; set; }

        public DateTime SessionDay { get; set; }
        public List<SectionAttendanceSetting> SectionAttendanceSettings { get; set; }
    }
}
