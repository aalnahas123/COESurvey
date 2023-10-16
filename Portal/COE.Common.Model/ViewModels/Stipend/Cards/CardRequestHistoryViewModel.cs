using PagedList;
namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardRequestHistoryViewModel
    {
        public virtual AspNetUsers AspNetUsers { get; set; }
        public StaticPagedList<CardsAllViewModel> Items { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }
}