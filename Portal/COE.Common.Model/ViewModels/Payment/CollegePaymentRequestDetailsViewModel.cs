namespace COE.Common.Model.ViewModels
{
    using COE.Common.Localization;
    using COE.Common.Model;
    using PagedList;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="CollegePaymentRequestDetailsViewModel" />
    /// </summary>
    public class CollegePaymentRequestDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the CollegePaymentRequest
        /// </summary>
        public CollegePayment CollegePaymentRequest { get; set; }

        /// <summary>
        /// Gets or sets the MonthlyStudents
        /// </summary>
        public StaticPagedList<StudentMonthlyPayment> MonthlyStudents { get; set; }

        /// <summary>
        /// Gets or sets the CourseStudents
        /// </summary>
        public StaticPagedList<StudentCoursePayment> CourseStudents { get; set; }

        /// <summary>
        /// Gets or sets the PayableCounter
        /// </summary>
        [Display(Name = "MD_Payable", ResourceType = typeof(PaymentResource))]
        public int PayableCounter { get; set; }

        /// <summary>
        /// Gets or sets the RepeatedCounter
        /// </summary>
        [Display(Name = "MD_Repeated", ResourceType = typeof(PaymentResource))]
        public int RepeatedCounter { get; set; }

        /// <summary>
        /// Gets or sets the RepeatedPayableCounter
        /// </summary>
        [Display(Name = "MD_RepeatedPayable", ResourceType = typeof(PaymentResource))]
        public int RepeatedPayableCounter { get; set; }

        /// <summary>
        /// Gets or sets the PageNumber
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the PaymentSetting
        /// </summary>
        public PaymentSetting PaymentSetting { get; set; }

        /// <summary>
        /// Gets or sets the FundedHoursRegular
        /// </summary>
        [Display(Name = "MD_FundedHoursRegular", ResourceType = typeof(PaymentResource))]
        public decimal FundedHoursRegular { get; set; }

        /// <summary>
        /// Gets or sets the FundedHoursRepeat
        /// </summary>
        [Display(Name = "MD_FundedHoursRepeat", ResourceType = typeof(PaymentResource))]
        public decimal FundedHoursRepeat { get; set; }
    }
}
