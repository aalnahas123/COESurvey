using COE.Common.Localization;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardsSearchViewModel : PagedResultBase
    {

        [Display(Name = "Cards_Title_NationalId", ResourceType = typeof(StipendResources))]
        public string NationalID { get; set; }

        [Display(Name = "Cards_Title_TVTC", ResourceType = typeof(StipendResources))]
        public string TVTCNo { get; set; }

        [Display(Name = "Cards_Title_IBAN", ResourceType = typeof(StipendResources))]
        public string IBAN { get; set; }

        [Display(Name = "Cards_Title_CardNo", ResourceType = typeof(StipendResources))]
        public string CardNo { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public int CollegeId { get; set; }

        [Display(Name = "Cards_CardStudentType", ResourceType = typeof(StipendResources))]
        public int? CardStudentType { get; set; }

        public StaticPagedList<CardsAllViewModel> Items { get; set; }

        public int TotalItemCount { get; set; }
        public bool Selected { get; set; }
        public bool SelectAll { get; set; }
    }
}
