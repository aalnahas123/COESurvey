using COE.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class OSHRPLGraduatesView
    {
        public bool IsExamCertificate => TYPE == OSHRPLGraduatesViewCertificateTypes.RPL.ToString();
        public bool IsTrainingCertificate => TYPE == OSHRPLGraduatesViewCertificateTypes.OSH.ToString();
    }
}