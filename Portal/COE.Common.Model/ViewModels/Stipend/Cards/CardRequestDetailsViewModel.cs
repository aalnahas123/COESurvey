using COE.Common.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardRequestDetailsViewModel
    {
        public bool IsFileGenerationInProgress { get; set; }
        public bool IsFileGenerationCompleted { get; set; }
        public bool IsStartProgress { get; set; }

        public bool IsGenerateFile { get; set; }


        public CardsRequest CardsRequest { get; set; }
        public StaticPagedList<StudentCardsRequest> Items { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }


    }
}
