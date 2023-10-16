using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class Section
    {
        public int ClassSessionId { get; set; }
        public int TraineesCount { get; set; }
        public string CourseNameValue { get; set; }
        public string CenterNameValue { get; set; }
        public string SessionNameAr { get; set; }
        public List<SectionEnrollment> Students { get; set; }

    }
}
