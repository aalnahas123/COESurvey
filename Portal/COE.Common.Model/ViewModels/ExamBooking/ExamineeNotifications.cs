// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="SURE International Technology">
//   Copyright © 2016 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace COE.Common.Model.ViewModels.ExamBooking
{
    public class ExamineeNotifications
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public DateTime? SendTime { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ExamCode { get; set; }
    }
}