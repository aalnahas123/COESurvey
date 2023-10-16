using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.MOL.ExamRequest
{
    public class ExamRequestViewModel
    {
        public ExamRequestViewModel()
        {
            TermsOfServices = new TermsOfServices();
            StudentIdentity = new RequesterIdentityViewModel();
            StudentInfo = new RequesterInfoViewModel();
            Attachments = new RequesterAttachmentsViewModel();
        }
        // 1 :- Terms Of Services
        public TermsOfServices TermsOfServices { get; set; }

        public RequesterIdentityViewModel StudentIdentity { get; set; }

        // 2 :- Personal Information (Integration wiht Yakeen) === > (SQL Student Profile Table)
        public RequesterInfoViewModel StudentInfo { get; set; }

        // 3 :- HighSchool Information (Integration wiht NOOR & Qiyas) === > (SQL Student Profile Table)
        public RequesterAttachmentsViewModel Attachments { get; set; }

        public RPLExamRequest ExamRequest { get; set; }

        public int? ID { get; set; }
        public string NextTab { get; set; }
        public string HasAttachment { get; set; }

        public bool Gender { get; set; }
    }
}
