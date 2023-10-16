using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class BatchViewModel : BaseViewModel
    {
        public BatchViewModel()
        {
            this.SubProgramsList = new List<System.Web.Mvc.SelectListItem>();
            this.CollegesList = new List<System.Web.Mvc.SelectListItem>();
            this.IntakeAcademicYearTermList = new List<System.Web.Mvc.SelectListItem>();
            this.GraduatedAcademicYearTermList = new List<System.Web.Mvc.SelectListItem>();
            this.IntakeAcademicYearList = new List<System.Web.Mvc.SelectListItem>();
            this.GraduatedAcademicYearList = new List<System.Web.Mvc.SelectListItem>();
        }

        [Display(Name = "Batch_BatchName", ResourceType = typeof(MetaData))]
        //[Required]
        public string BatchName { get; set; }

        [Display(Name = "Batch_BatchCode", ResourceType = typeof(MetaData))]
        public string BatchCode { get; set; }

        [Display(Name = "Batch_ProgramID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedProgramID { get; set; }

        [Display(Name = "Batch_SubProgramID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedSubProgramID { get; set; }

        [Display(Name = "Batch_CollegeSpecializationID", ResourceType = typeof(MetaData))]
        public int? CollegeSpecializationID { get; set; }

        public int? SpecializationID { get; set; }

        [Display(Name = "Batch_CollegeID", ResourceType = typeof(MetaData))]
        public int? CollegeID { get; set; }

        [Display(Name = "Batch_IntakeTermID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedIntakeTermID { get; set; }

        [Display(Name = "Batch_IntakeYearID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedIntakeYearID { get; set; }

        [Display(Name = "Batch_GraduatedTermID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedGraduatedTermID { get; set; }

        [Display(Name = "Batch_GraduatedYearID", ResourceType = typeof(MetaData))]
        [Required]
        public int? SelectedGraduatedYearID { get; set; }

        [Required]
        public int? SelectedSectionTypeID { get; set; }

        [Required]
        public int? MinSeat { get; set; }

        [Required]
        public int? MaxSeat { get; set; }

        public List<System.Web.Mvc.SelectListItem> SubProgramsList { get; set; }

        public List<System.Web.Mvc.SelectListItem> CollegesList { get; set; }
        public int[] SelectedColleges { get; set; }

        public List<System.Web.Mvc.SelectListItem> IntakeAcademicYearTermList { get; set; }

        public List<System.Web.Mvc.SelectListItem> GraduatedAcademicYearTermList { get; set; }

        //
        public List<System.Web.Mvc.SelectListItem> GraduatedAcademicYearList { get; set; }

        public List<System.Web.Mvc.SelectListItem> IntakeAcademicYearList { get; set; }

    }
}
