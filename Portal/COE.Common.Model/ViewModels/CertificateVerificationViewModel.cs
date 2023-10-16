using COE.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class CertificateVerificationViewModel
    {
        public string TraineeNameEn { get; set; }
        public string TraineeNameAr { get; set; }
        public string SerialNumber { get; set; }
        public string Grade { get; set; }
        public string NationalId { get; set; }

        public string CertificateType { get; set; }

        public string CertificateDate { get; set; }
        public string CertificateDateHijri { get; set; }

        public string CertificateEndDate { get; set; }
        public string CertificateEndDateHijri { get; set; }

        public string CertificateLevel { get; set; }
        public string TheCertificateValidity { get; set; }
        public bool IsTheCertificateValid { get; set; }

        public bool IsExamCertificate { get; set; }
        public bool IsTrainingCertificate { get; set; }
    }
}