using COE.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.MOL
{
    public class ExamUserTypeViewModel
    {
        public int Id { get; set; }
        public RPLCertificateTypes level { get; set; }
        public bool IsRPL { get; set; }
        public bool IsETraining{ get; set; }

        public string levelName { get; set; }

        public string QualificationCode { get; set; }
        public string NationalId { get; set; }
        public bool MultiLevel { get; set; }
        public bool IsOSHTraining { get; set; }
        public bool? IsMale { get; set; }
    }
}
