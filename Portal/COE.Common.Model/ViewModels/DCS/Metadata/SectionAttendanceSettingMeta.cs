using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class SectionAttendanceSetting : ICloneable
    {
        public string UserId { get; set; }
        public string LecturerName { get; set; }

        public bool IsScheduled { get; set; }

        public int SessionID { get; set; }

        public long AttendanceCount { get; set; }

        public string AttendanceDescription => $"#P={AttendanceCount}";

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
