using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class BaseSearchViewModel
    {
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }
}
