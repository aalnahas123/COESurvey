namespace COE.Common.Model.ViewModels.Stipend
{
    public class SelectedUser : BaseViewModel
    {
        public int EnrollmentId { get; set; }
        public string NationalId { get; set; }

        public bool HasCard { get; set; }

        public bool IsChecked { get; set; }

        public int? StudentCardID { get; set; }

        public int RequestType { get; set; }
        public bool InStudentCard { get; set; }


        #region Student Stipend
        public int StipendsRequestID { get; set; }
        public int PeriodID { get; set; }
        public int PaidAmount { get; set; }
        public int DeductedAmount { get; set; }
        public int StipendFeedbackStatusID { get; set; }
        public int StipendPaymentMethodID { get; set; }
        #endregion

    }
}
