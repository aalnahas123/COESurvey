using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class CertificateViewModel
    {
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CertificateDate { get; set; }
        public DateTime CertificateDateHijri { get; set; }
        public string NationalId { get; set; }
        public string CertificateType { get; set; }
        public string CertificateTypeAr { get; set; }
        public string LevelName { get; set; }
        public string LevelNameAr { get; set; }


    }
}
