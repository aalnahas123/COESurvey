using PagedList;
using COE.Common.Localization;
using COE.Common.Model.ViewModels;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Commons.Framework.Configuration;
using System.Linq;

namespace COE.Common.Model
{
    public class ApplicationsAllViewModel : BaseViewModel
    {
        public string NationalId { get; set; }
        public string UserName { get; set; }
        public string CollegeName { get; set; }
        public string CertificateTitle { get; set; }
        public int ApplicationId { get; set; }
        public string EducationLevel { get; set; }
        public string CertificateLevelName { get; set; }
        public bool IsStudent { get; set; }
        public int SttausId { get; set; }

        public int StageId { get; set; }
        public int? QualificationLevelId { get; set; }
        public int? CertificateTypeId { get; set; }

        public int RequestId { get; set; }
        public string FullName { get; set; }
        public string CreatedOnStr { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public DateTime? ApprovalDate { get; set; }

        public bool IsExamQualified => 
            !HasExamResult &&
            ApprovalDate.GetValueOrDefault() > new DateTime(2022, 09, 02) && 
            ! SystemSettingsHelper.Get<string>("PrintCertificateExceptionNationalIDs","MOL").Split(',').Contains(NationalId);

        public StaticPagedList<ApplicationsAllViewModel> Items { get; set; }
        public ApplicationsAllViewModel SearchModel { get; set; }
        public bool HasExamResult { get; set; }
    }
}
