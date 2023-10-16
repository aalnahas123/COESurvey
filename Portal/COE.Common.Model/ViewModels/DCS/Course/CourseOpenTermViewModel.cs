using System;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class CourseOpenTermViewModel:BaseViewModel
    {
        public string AcademicYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TermStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TermEndDate { get; set; }
        public string Term { get; set; }
    }
}
