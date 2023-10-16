//using COE.Common.Model.ViewModels.Enrollment;

using COE.Common.Model.CenterVMs;
using PagedList;
using System.Collections.Generic;

namespace COE.Common.Model
{
    public class CenterProfileViewModel
    {
        public College Center { get; set; }

        public AspNetUsers AspNetUser { get; set; }

        public LicenseVM LicenseDetails { get; set; }

        public TrainersQualificationsDetailsVM TrainersQualificationsDetails { get; set; }

        public TrainingCourseInfoVM TrainingCourseDetails { get; set; }

        public bool IsCenter { get; set; }
        public bool HasActiveRequest { get; set; }
    }
}
