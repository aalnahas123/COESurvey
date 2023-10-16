using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceDetailsViewModel
    {       

        [Display(Name = "SectionCode", ResourceType = typeof(DCSResources))]
        public string SectionCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "AttendedHours", ResourceType = typeof(DCSResources))]
        public decimal AttendedHours { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "ExcusedHours", ResourceType = typeof(DCSResources))]
        public decimal ExcusedHours { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "ExtraHours", ResourceType = typeof(DCSResources))]
        public decimal ExtraHours { get; set; }

        [Display(Name = "OJT", ResourceType = typeof(DCSResources))]
        public int OJT { get; set; }

        [Display(Name = "CourseCode", ResourceType = typeof(DCSResources))]
        public string CourseCode { get; set; }       

        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public string CollegeName { get; set; }

        [Display(Name = "Specialization", ResourceType = typeof(DCSResources))]
        public string Specialization { get; set; }
                
        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public string AcademicYear { get; set; }

        [Display(Name = "Term", ResourceType = typeof(DCSResources))]
        public string AcademicTerm { get; set; }
       
        [Display(Name = "Period", ResourceType = typeof(DCSResources))]
        public string Period
        {
            get
            {
                return PeriodStartDate.ToString("dd-MM-yyyy") + "/" + PeriodEndDate.ToString("dd-MM-yyyy");
            }
        }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(DCSResources))]
        public string NationalId { get; set; }

    }
}
