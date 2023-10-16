using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Model;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class StipendRequestDetailsViewModel
    {
        public StipendsRequest StipendsRequest { get; set; }
        public StipendsRequest StipendsNewRequest { get; set; }
        public string SearchIds { get; set; }
        public StaticPagedList<StudentStipendsRequest> Items { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

        public bool? IsStartProgress { get; set; }
    }
}
