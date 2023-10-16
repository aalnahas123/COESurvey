namespace COE.Common.Model.ViewModels
{
    using COE.Common.Localization;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="GraduatedBatche" />
    /// </summary>
    public class BatchStudentsCount
    {
        /// <summary>
        /// Gets or sets the BatchCode
        /// </summary>
        [Display(Name = "Batch_BatchCode", ResourceType = typeof(MetaData))]
        public string BatchCode { get; set; }

        /// <summary>
        /// Gets or sets the StudentsCount
        /// </summary>
        public int StudentsCount { get; set; }

        public StudentStatus StudentsCountType { get; set; }

        public string Category { get; set; } = "ITC";
    }

    public enum StudentStatus
    {
        Registered,
        Enrolled,
        Graduated
    }
}
