//using COE.Common.Model.ViewModels.Enrollment;

using PagedList;
using System.Collections.Generic;

namespace COE.Common.Model
{
    public class RPLRequestViewModel
    {
        public RPLRequestViewModel()
        {
            StudentIdentity = new StudentIdentityViewModel();
            StudentInfo = new StudentInformationViewModel();
            StudentCertificateInfo = new CertificateInformationViewModel();
            QualificationsInfo = new QualificationsViewModel();
            Qualifications = new List<Model.QualificationsViewModel>();
            //StudentChoices = new StudentChoicesViewModel();
        }
        // 1 :- Yakeen Input (NationalID , BirthYear) + (Student MobileNumber , Student Email in case the registration by college admin)
        public StudentIdentityViewModel StudentIdentity { get; set; }
        // 2 :- Personal Information (Integration wiht Yakeen) === > (SQL Student Profile Table)
        public StudentInformationViewModel StudentInfo { get; set; }
        // 3 :- HighSchool Information (Integration wiht NOOR & Qiyas) === > (SQL Student Profile Table)
        public CertificateInformationViewModel StudentCertificateInfo { get; set; }

        public QualificationsViewModel QualificationsInfo { get; set; }
        public StaticPagedList<RPLRequestViewModel> Items { get; set; }

        public List<QualificationsViewModel> Qualifications { get; set; }

        public int ApplicationId { get; set; }

        public int RequestId { get; set; }

        public string HasAttachment { get; set; }

        public string NextTab { get; set; }

        public bool CanEdit { get; set; } 

    }
}
