using System;
using System.ComponentModel.DataAnnotations;
using Commons.Framework.Web.Mvc.DataAnnotations;

using PagedList;
using System.Collections.Generic;

namespace COE.Common.Model
{
    [MetadataType(typeof(TeacherAttendanceMetadata))]
    public partial class TeacherAttendance
    {
        public string AttendanceStatusStr { get; set; }

        public int AttendanceCount { get; set; }
        public int AbsenceCount { get; set; }

        public string Daystr { get; set; }

        public string TeacherName { get; set; }
        public string TeacherNationalId { get; set; }

        public Guid? ViewTeacherId { get; set; }

        internal class TeacherAttendanceMetadata
        {
           

        }
    }
}
