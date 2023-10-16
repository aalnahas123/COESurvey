using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class SectionEnrollmentDetailsViewModel
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


        public List<SectionAttendanceSetting> SectionAttendanceSettings { get; set; }
    }
}
