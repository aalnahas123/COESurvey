using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class CreditsViewModel
    {
        public int ExamBookingPaymentId { get; set; }
        public int? ExamBookingId { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public string Amount { get; set; }
        public bool? TraineeRequestRefund { get; set; }
        public bool? IsRefunded { get; set; }

        public string IsRefundedText => IsRefunded.GetValueOrDefault()
                                            ? ExamBookingResources.SuccessfulRefund
                                            : ExamBookingResources.NotRefunded;
        public string TraineeRequestRefundText => TraineeRequestRefund.GetValueOrDefault()
                                           ? ExamBookingResources.IsRequestedRefund
                                           : ExamBookingResources.NotRequestedRefund;

        public string InvoiceID { get; set; }
        public string CreditNoteID { get; set; }
        //public CreditsViewModel(int examBookingPaymentId, int? examBookingId, string code, DateTime startDate, string amount, bool? traineeRequestRefund, bool? isRefunded)
        //{
        //    ExamBookingPaymentId = examBookingPaymentId;
        //    ExamBookingId = examBookingId;
        //    Code = code;
        //    StartDate = startDate;
        //    Amount = amount;
        //    TraineeRequestRefund = traineeRequestRefund;
        //    IsRefunded = isRefunded;
        //}

        //public override bool Equals(object obj)
        //{
        //    return obj is CreditsViewModel other &&
        //           ExamBookingPaymentId == other.ExamBookingPaymentId &&
        //           ExamBookingId == other.ExamBookingId &&
        //           Code == other.Code &&
        //           StartDate == other.StartDate &&
        //           Amount == other.Amount &&
        //           TraineeRequestRefund == other.TraineeRequestRefund &&
        //           IsRefunded == other.IsRefunded;
        //}

        //public override int GetHashCode()
        //{
        //    int hashCode = 594900840;
        //    hashCode = hashCode * -1521134295 + ExamBookingPaymentId.GetHashCode();
        //    hashCode = hashCode * -1521134295 + ExamBookingId.GetHashCode();
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
        //    hashCode = hashCode * -1521134295 + StartDate.GetHashCode();
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Amount);
        //    hashCode = hashCode * -1521134295 + TraineeRequestRefund.GetHashCode();
        //    hashCode = hashCode * -1521134295 + IsRefunded.GetHashCode();
        //    return hashCode;
        //}
    }
}
