using COE.Common.Localization;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardsAllViewModel : CardsRequest
    {
        public int Id { get; set; }
        public string StudentName { get; set; }

        [Display(Name = "AspNetUsers_NationalId", ResourceType = typeof(MetaData))]
        public string NationalID { get; set; }

        [Display(Name = "AspNetUsers_TVTCNo", ResourceType = typeof(StipendResources))]
        public string TVTCNo { get; set; }

        [Display(Name = "Cards_Title_CardNo", ResourceType = typeof(StipendResources))]
        public string CardNo { get; set; }
        public string IBAN { get; set; }

        public string FeedbackStatus { get; set; }
        public int FeedbackStatusId { get; set; }

        public string FeedbackDenialReason { get; set; }
        public int? FeedbackDenialReasonId { get; set; }

        [Display(Name = "College_Name", ResourceType = typeof(MetaData))]
        public string CollegeName { get; set; }
        public int EnrollmentID { get; set; }
        public int? CardType { get; set; }
        public bool InStudentCard { get; set; }
        public int? StudentCardID { get; set; }
        public StudentCard StudentCard { get; set; }

        public bool HasCard { get; set; }
        public bool Selected { get; set; }
    }
}
