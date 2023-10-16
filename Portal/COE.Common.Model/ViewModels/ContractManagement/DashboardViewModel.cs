namespace COE.Common.Model.ViewModels
{
    using COE.Common.Localization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="DashboardViewModel" />
    /// </summary>
    public class ProgramsDashboardVM : BaseViewModel
    {

        public ProgramsDashboardVM()
        {
            SubProgramsList = new List<System.Web.Mvc.SelectListItem>();
            AcademicYearIdList = new int[] { };
            AcademicYearTermIdList = new int[] { };
        }
        /// <summary>
        /// Gets or sets the SelectedProgramID
        /// </summary>
        [Display(Name = "Batch_ProgramID", ResourceType = typeof(MetaData))]
        public int? SelectedProgramID { get; set; }

        /// <summary>
        /// Gets or sets the SelectedSubProgramID
        /// </summary>
        [Display(Name = "Batch_SubProgramID", ResourceType = typeof(MetaData))]
        public int? SelectedSubProgramID { get; set; }

        /// <summary>
        /// Gets or sets the SelectedSpecializationID
        /// </summary>
        [Display(Name ="Specialization")]
        public int? SelectedSpecializationID { get; set; }

        /// <summary>
        /// Gets or sets the TotalRegisteredStudents
        /// </summary>
        public int TotalRegisteredStudents { get; set; }

        /// <summary>
        /// Gets or sets the TotalEnrolledStudents
        /// </summary>
        public int TotalEnrolledStudents { get; set; }

        /// <summary>
        /// Gets or sets the TotalDropOutStudents
        /// </summary>
        public int TotalDropOutStudents { get; set; }

        /// <summary>
        /// Gets or sets the BatchsEnrolledStudents
        /// </summary>
        public List<BatchStudentsCount> BatchesEnrolledStudents { get; set; }

        /// <summary>
        /// Gets or sets the GraduatedBatches
        /// </summary>
        public List<BatchStudentsCount> GraduatedBatches { get; set; }

        /// <summary>
        /// Gets or sets the ProgramsList
        /// </summary>
        public List<System.Web.Mvc.SelectListItem> ProgramsList { get; set; }

        /// <summary>
        /// Gets or sets the SubProgramsList
        /// </summary>
        public List<System.Web.Mvc.SelectListItem> SubProgramsList { get; set; }

        /// <summary>
        /// Gets or sets the SpecializationsList
        /// </summary>
        public List<System.Web.Mvc.SelectListItem> SpecializationsList { get; set; }

        #region AcademicYear For Muti selected
        [Display(Name = "AcademicYear", ResourceType = typeof(SharedResources))]
        public int? AcademicYearId { get; set; }
        public int[] AcademicYearIdList { get; set; }
        public string AcademicYearIdListStr { get; set; }
        #endregion

        #region AcademicYearTerm For Muti selected

        [Display(Name = "AcademicYearTerm", ResourceType = typeof(SharedResources))]
        public int? AcademicYearTermId { get; set; }
        public int[] AcademicYearTermIdList { get; set; }
        // to cast academic year term id array string comma separated
        public string AcademicYearTermIdListStr { get; set; }

        #endregion
    }
}
