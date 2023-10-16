using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Model;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StipendNewRequestViewModel
    {
        public bool SelectAll { get; set; }
        public string SearchIds { get; set; }
        public int CollegeID { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }

        public StaticPagedList<StudentStipendViewModel> Items { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
    }
}
