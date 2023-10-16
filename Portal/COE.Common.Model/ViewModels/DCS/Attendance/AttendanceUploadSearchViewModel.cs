using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.DCS
{
    public class AttendanceUploadSearchViewModel
    {
        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public int CollegeId { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public int AcademicYearId { get; set; }


        [Display(Name = "Term", ResourceType = typeof(DCSResources))]
        public int TermId { get; set; }


        [Display(Name = "AcademicYear", ResourceType = typeof(DCSResources))]
        public int CollegeAcademicYearId { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; }

        public List<LookupViewModel> CollegesList { get; set; }

        public List<LookupViewModel> CollegeAcademicYearsList { get; set; }

        public List<LookupViewModel> TermsList { get; set; }

        public UploadViewModel UploadViewModel { get; set; }

        [Display(Name = "DateFrom", ResourceType = typeof(DCSResources))]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(DCSResources))]
        public DateTime? DateTo { get; set; }

        public string UserName { get; set; }


    }
}
