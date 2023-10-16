namespace COE.Common.Model.ViewModels
{
    using COE.Common.Localization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="PaymentSettingViewModel" />
    /// </summary>
    public class PaymentSettingViewModel
    {       
        /// <summary>
        /// Gets or sets the CollegeAcademicYearId
        /// </summary>
        [Required]
        [Display(Name = "AcademicYear", ResourceType = typeof(PaymentResource))]
        public int CollegeAcademicYearId { get; set; }

        /// <summary>
        /// Gets or sets the CollegesList
        /// </summary>
        public List<LookupViewModel> CollegesList { get; set; }

        /// <summary>
        /// Gets or sets the CollegeAcademicYearsList
        /// </summary>
        public List<LookupViewModel> CollegeAcademicYearsList { get; set; }

        /// <summary>
        /// Gets or sets the TermsList
        /// </summary>
        public List<LookupViewModel> TermsList { get; set; }      

        /// <summary>
        /// Gets or sets the PaymentSetting
        /// </summary>
        public PaymentSetting PaymentSetting { get; set; }
    }
}