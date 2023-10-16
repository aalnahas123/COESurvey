using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class ExamCalendarRequest
    {
        public IEnumerable<RPLExamBooking> ConfirmedBooking => this.RPLExamBookings.Where(b =>
            b.IsPaid &&
            (!b.IsRefunded.HasValue || b.IsRefunded == false) &&
            !b.CancelationReasonId.HasValue
        );

        public int ConfirmedBookingCount => ConfirmedBooking.Count();

        public int SARASConfirmedBookingCount => ConfirmedBooking.Where(b => b.IsSarasConfirmed == true).Count();

        public int SARASConfirmedBookingMaleCount => ConfirmedBooking.Where(b =>
            b.IsSarasConfirmed == true
            && (
                    this.IsMale == true
                    ||
                    (
                        this.IsMale == null
                         && (b.AspNetUser.StudentProfile.Any()
                            ? b.AspNetUser.StudentProfile.FirstOrDefault().IsMale == true
                            : true)
                    )
                )
        ).Count();
        public int SARASConfirmedBookingFemaleCount => ConfirmedBooking.Where(b =>
        b.IsSarasConfirmed == true
            && (
                    this.IsMale == false
                    ||
                    (
                        this.IsMale == null
                         && (b.AspNetUser.StudentProfile.Any()
                            ? b.AspNetUser.StudentProfile.FirstOrDefault().IsMale == false
                            : false)
                    )
                )
        ).Count();
    }
}