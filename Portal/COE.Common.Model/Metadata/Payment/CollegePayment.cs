namespace COE.Common.Model
{
    using COE.Common.Localization;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="CollegePayment" />
    /// </summary>
    [MetadataType(typeof(CollegePaymentMetaData))]
    public partial class CollegePayment
    {
        /// <summary>
        /// Gets or sets the Validations
        /// </summary>
        public List<string> Validations { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="CollegePaymentMetaData" />
    /// </summary>
    public class CollegePaymentMetaData
    {
        /// <summary>
        /// Gets or sets the PaymentRequestStatusID
        /// </summary>
        [Display(Name = "MD_PaymentRequestStatus", ResourceType = typeof(PaymentResource))]
        public int PaymentRequestStatusID { get; set; }

        /// <summary>
        /// Gets or sets the CollegeID
        /// </summary>
        [Display(Name = "MD_College", ResourceType = typeof(PaymentResource))]
        public int CollegeID { get; set; }

        /// <summary>
        /// Gets or sets the AcademicYearTermID
        /// </summary>
        [Display(Name = "MD_Term", ResourceType = typeof(PaymentResource))]
        public int AcademicYearTermID { get; set; }

        /// <summary>
        /// Gets or sets the ActualPaymentAmount
        /// </summary>
        [Display(Name = "MD_ActualPaymentAmount", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> ActualPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the CalculatedPaymentAmount
        /// </summary>
        [Display(Name = "MD_CalculatedPaymentAmount", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> CalculatedPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the PaidAmount
        /// </summary>
        [Display(Name = "PaidAmount", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the PaidAmountComment
        /// </summary>
        [Display(Name = "PaidAmountComment", ResourceType = typeof(PaymentResource))]
        public string PaidAmountComment { get; set; }

        /// <summary>
        /// Gets or sets the EffectivePaymentAmount
        /// </summary>
        [Display(Name = "MD_MinimumGuarantee", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> EffectivePaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the OJTPaymentAmount
        /// </summary>
        [Display(Name = "MD_OJTPaymentAmount", ResourceType = typeof(PaymentResource))]
        public Nullable<decimal> OJTPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "MD_CreatedOn", ResourceType = typeof(PaymentResource))]
        public System.DateTime CreatedOn { get; set; }
    }
}