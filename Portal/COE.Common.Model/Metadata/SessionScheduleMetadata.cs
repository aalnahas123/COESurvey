using System;
using System.Collections.Generic;
//using COE.Cources.Localization.Training;
using System.ComponentModel.DataAnnotations;
using PagedList;
//using COE.Cources.Localization;

namespace COE.Common.Model
{

    [MetadataType(typeof(SectionAttendanceSettingMetadata))]
    public partial class SectionAttendanceSetting
    {
        public string[] Days { get; set; }
        public string StartTimeValue { get; set; }
        public string EndTimeValue { get; set; }

        public string SessionDesignClass { get; set; }

        public string LecturerNameValue { get; set; }
        public string PeriodValue { get; set; }
        public string DayValue { get; set; }

        public int AppointmentCompany { get; set; }

        public int CompanyID { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

        public bool IsActiveValue { get; set; }

        public string UserId { get; set; }

        public string LecturerName { get; set; }
        public string CourseName { get; set; }

        public StaticPagedList<Course> Items { get; set; }

        internal class SectionAttendanceSettingMetadata
        {

            //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
            //public int PeriodID { get; set; }

        }
    }
}
