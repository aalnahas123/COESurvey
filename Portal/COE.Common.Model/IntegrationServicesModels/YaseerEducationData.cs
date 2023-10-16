using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public class YaseerEducationData
    {
        public string SchoolName { get; set; }
        public int SchoolAreaId { get; set; }
        public int SchoolTypeId { get; set; }
        public string StudentAchievment { get; set; }
        public string GPA { get; set; }
        public string Qiyas { get; set; }
        //public AcademicYearEntity AcademicYear { get; set; }

        public string SchoolAreaCode { get; set; }

        public string SchoolTypeCode { get; set; }

        public string AcademicYearValues { get; set; }
    }
}
