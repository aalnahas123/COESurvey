using COE.Common.Localization;
using PagedList;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course : CommonMetaData
    {
        public int? NossId { get; set; } = -1;
        public HttpPostedFileBase AttachedFile { get; set; }

        public string NationalID { get; set; }

        public string FullName { get; set; }

        public int[] UserProgramsIds { get; set; }


        //public int? SubProgramId { get; set; }
        public int? CourseId { get; set; }
        public int? CenterId { get; set; }

        public int SessionId { get; set; }

        public int ScheduleId { get; set; }

        public int? SettingScheduleId { get; set; }

        public Guid? UserId { get; set; }
        public int? MainProgramId { get; set; }

        public string CenterNameValue { get; set; }
        public string CourseNameValue { get; set; }
        public string CityNameValue { get; set; }
        public string SubProgramNameValue { get; set; }
        public string ProgramNameValue { get; set; }
        public string ProviderNameValue { get; set; }

        public string StatusValue { get; set; }


        public Nullable<System.DateTime> CourseStartDate { get; set; }
        public Nullable<System.DateTime> CourseEndDate { get; set; }


        public string CourseStartDateStr { get; set; }
        public string CourseEndDateStr { get; set; }

        public int? CityId { get; set; }

        public int? ProviderId { get; set; }

      
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

        public Nullable<int> NotificationStatusId { get; set; }

        public string PercentType { get; set; }

        public StaticPagedList<Course> Items { get; set; }
        internal class CourseMetaData
        {
             
        }
    }
}
