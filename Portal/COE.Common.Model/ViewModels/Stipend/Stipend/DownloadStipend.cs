using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class DownloadStipend
    {
        public string Student { get; set; }
        public string NationalId { get; set; }
        public string TVTCNo { get; set; }
    }
    public class DownloadStipendAll
    {
        public string StipendNo { get; set; }
        public string CollegeName { get; set; }
        public string NoOfStudents { get; set; }
        public string NoOfAccepted { get; set; }
        public string NoOfRejected { get; set; }
     }
}
