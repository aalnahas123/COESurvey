//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COE.Common.Model
{
    using System;
    
    public partial class GetTeacherLectures_Result
    {
        public Nullable<System.Guid> lecturerid { get; set; }
        public int InstanceID { get; set; }
        public int SectionAttendanceSettingID { get; set; }
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        public int CollegeID { get; set; }
        public string SectionCode { get; set; }
        public string CourseName { get; set; }
        public string CollegeName { get; set; }
        public Nullable<System.DateTime> SessionDay { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<int> DayWeekID { get; set; }
    }
}
