using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;
//using COE.Cources.Localization.Training;
using PagedList;

namespace COE.Common.Model.ViewModels
{
    public class AttendanceSheet
    {
        public int SessionStudentID { get; set; }
        public int AttendenceStatusId { get; set; }
        public int SessionID { get; set; }
        public int SessionScheduleID { get; set; }
        public Guid TraineeId { get; set; }
        public string NationalId { get; set; }
        public string TraineeName { get; set; }
        public int SessionScheduleAttendanceSettingID { get; set; }
        public string SectionCode { get; set; }
        public int SectionID { get; set; }

    }
}
