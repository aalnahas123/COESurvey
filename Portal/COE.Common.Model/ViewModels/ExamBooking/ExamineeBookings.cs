// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="SURE International Technology">
//   Copyright © 2016 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace COE.Common.Model.ViewModels.ExamBooking
{
    public class ExamineeBookings
    {
        public int ID { get; set; }
        public string ExamCode { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamLevel { get; set; }
        public bool? IsPassTheExam { get; set; }
        public string TransactionId { get; set; }
        public bool? Refuended { get; set; }
        public string CancelationReason { get; set; }
        public bool? IsReSchedule { get; set; }
    }
}