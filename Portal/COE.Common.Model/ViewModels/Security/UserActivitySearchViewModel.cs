using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class UserActivitySearchViewModel : BaseSearchViewModel
    {
        public StaticPagedList<COE.Common.Model.UserActivity> Items { get; set; }
    }
}
