using COE.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class RPLExamBooking
    {
        public bool CanReTakeExam =>
            IsPaid == true && IsSarasConfirmed == true && CancelationReasonId == null && RetakeExamBookingId == null &&
            (AttendanceStatusId == (int)ExamBookingAttendanceStatus.Absent ||
            RPLExamResult.Any(r => r.StageID == (int)RPLExamResultStatus.Fail)) &&
            !RetakeExamBookingList.Any(b => b.CancelationReasonId == null || b.CancelationReasonId == (int)RPLExamBookingCancelationReasons.ByUser);

        private DateTime ExamDateTime => ExamCalendarRequest.ExamCalendar.StartDate.Hour == 0
                                    ? ExamCalendarRequest.ExamCalendar.StartDate + ExamCalendarRequest.ExamCalendar.TimeFrom
                                    : ExamCalendarRequest.ExamCalendar.StartDate;
        public string ExamDate => $"{ExamDateTime.ToString("dd-MM-yyyy hh:mm ", new CultureInfo("en-US"))}{ExamDateTime.ToString("tt", new CultureInfo("ar-SA"))}";
        public string CenterName => ExamCalendarRequest.College.NameAr;
        public string CenterLocationUrl => ExamCalendarRequest.College.CollegeContactDetail?.FirstOrDefault()?.Location ?? String.Empty;
        public string StudentName => !string.IsNullOrEmpty(AspNetUser.RPLApplicant?.FirstOrDefault(a => RPLRequestId.HasValue && a.RPLRequest.Any(r => r.ID == RPLRequestId))?.FirstNameAr?.Trim())
            ? AspNetUser.RPLApplicant?.FirstOrDefault(a => RPLRequestId.HasValue && a.RPLRequest.Any(r => r.ID == RPLRequestId))?.FirstNameAr.Trim()
            : (!string.IsNullOrEmpty(AspNetUser.StudentProfile?.FirstOrDefault()?.FirstNameAr?.Trim())
                ? AspNetUser.StudentProfile?.FirstOrDefault()?.FirstNameAr.Trim()
                : AspNetUser.FullName.Split(' ').Where(s => !string.IsNullOrEmpty(s.Trim())).Select(s => s.Trim()).ToArray()[0]);

        //public string StudentLastName => !string.IsNullOrEmpty(AspNetUser.RPLApplicant.FirstOrDefault()?.FourthNameAr?.Trim())
        //   ? AspNetUser.RPLApplicant?.FirstOrDefault()?.FourthNameAr.Trim()
        //   : (!string.IsNullOrEmpty(AspNetUser.StudentProfile.FirstOrDefault()?.FourthNameAr?.Trim())
        //       ? AspNetUser.StudentProfile?.FirstOrDefault()?.FourthNameAr.Trim()
        //       : AspNetUser.FullName.Split(' ').Where(s => !string.IsNullOrEmpty(s.Trim())).Select(s => s.Trim()).ToArray().Last());
    }
}