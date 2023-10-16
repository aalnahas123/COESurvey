using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(StudentMonthlyPaymentMetaData))]
    public partial class StudentMonthlyPayment
    {

        public string Repeated
        {
            get
            {
                return (RepetitionFactor == 2 ? "Yes" : "No");
            }
        }

        public string Payable
        {
            get
            {
                return (PayableFactor == 1 ? "Yes" : "No");
            }
        }

        public string Month
        {
            get
            {
                return StartDate.ToString("dd-MM-yyyy")+ " / " + EndDate.ToString("dd-MM-yyyy");
            }
        }
    

        public decimal GetTotalOffered(int courseId,int academicYearTermID,DateTime startDate,DateTime endDate)
        {

            return Enrollment.SectionEnrollment.Where(se => se.Section.TermCourse.AcademicYearTermID == academicYearTermID && se.Section.TermCourse.CourseID == courseId)
                                                               .Sum(se => se.SectionEnrollmentAttendance
                                                               .Where(a => a.SectionAttendanceSetting.StartDate == startDate && a.SectionAttendanceSetting.EndDate == endDate)
                                                               .Sum(a => a.SectionAttendanceSetting.OfferedHours));
           
        }
        public decimal GetTotalAttended(int courseId, int academicYearTermID, DateTime startDate, DateTime endDate)
        {
            return Enrollment.SectionEnrollment.Where(se => se.Section.TermCourse.AcademicYearTermID == academicYearTermID && se.Section.TermCourse.CourseID ==  courseId)
                                                                   .Sum(se => se.SectionEnrollmentAttendance
                                                                   .Where(a => a.SectionAttendanceSetting.StartDate == startDate && a.SectionAttendanceSetting.EndDate == endDate)
                                                                   .Sum(a => a.Attended));
        }
        public decimal GetTotalExcused(int courseId, int academicYearTermID, DateTime startDate, DateTime endDate)
        {
            return Enrollment.SectionEnrollment.Where(se => se.Section.TermCourse.AcademicYearTermID == academicYearTermID && se.Section.TermCourse.CourseID == courseId)
                                                                  .Sum(se => se.SectionEnrollmentAttendance
                                                                  .Where(a => a.SectionAttendanceSetting.StartDate == startDate && a.SectionAttendanceSetting.EndDate == endDate)
                                                                  .Sum(a => a.Excused));
        }
        public decimal GetTotalExtra(int courseId, int academicYearTermID, DateTime startDate, DateTime endDate)
        {
            return Enrollment.SectionEnrollment.Where(se => se.Section.TermCourse.AcademicYearTermID == academicYearTermID && se.Section.TermCourse.CourseID == courseId)
                                                                 .Sum(se => se.SectionEnrollmentAttendance
                                                                 .Where(a => a.SectionAttendanceSetting.StartDate == startDate && a.SectionAttendanceSetting.EndDate == endDate)
                                                                 .Sum(a => a.Extra));
        }
        public int GetTotalOJT(int courseId, int academicYearTermID, DateTime startDate, DateTime endDate)
        {
            return Enrollment.SectionEnrollment.Where(se => se.Section.TermCourse.AcademicYearTermID == academicYearTermID && se.Section.TermCourse.CourseID == courseId)
                                                                .Sum(se => se.SectionEnrollmentAttendance
                                                                .Where(a => a.SectionAttendanceSetting.StartDate == startDate && a.SectionAttendanceSetting.EndDate == endDate)
                                                                .Sum(a => a.OJT));
        }
    }


    public class StudentMonthlyPaymentMetaData
    {
        [Display(Name = "MD_CalculatedPaymentAmount", ResourceType = typeof(PaymentResource))]
        public double CalculatedAmount { get; set; }

        [Display(Name = "MD_Repeated", ResourceType = typeof(PaymentResource))]
        public string Repeated { get; }

        [Display(Name = "MD_Payable", ResourceType = typeof(PaymentResource))]
        public string Payable { get; }

        [Display(Name = "MD_Month", ResourceType = typeof(PaymentResource))]
        public string Month { get; }

        [Display(Name = "MD_Course", ResourceType = typeof(PaymentResource))]
        public int CourseID { get; set; }
    }
}
