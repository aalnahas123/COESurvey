using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersMgmt.Model;

namespace COE.Common.Model.CenterVMs
{
    public class WizerdVM
    {
        public BasicDetailsVM BasicDetails { get; set; }
        public AccountDetailsVM AccountDetails { get; set; }

        public TrainingCourseInfoVM TrainingCourseInfo { get; set; }

        public OTpVM OTP { get; set; }
        public ApplicationUser ApplicationUserModel { get; set; }

        public string CenterOTP { get; set; }
        public ApplicationUser NewUser { get; set; }
        public LicenseVM License { get; set; }
    }
}
