using PagedList;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class NewRequestViewModel : PagedResultBase
    {
        public int CollegeID { get; set; }
        
        public CardsRequest CardsRequest { get; set; }
        public StaticPagedList<AspNetUsers> Items { get; set; }
    }
}
