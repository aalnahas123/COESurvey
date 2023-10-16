namespace COE.Common.Model.ViewModels.Security
{
    public class PagedResultBase
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

    }
}
