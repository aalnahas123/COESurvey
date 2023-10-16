using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public class CollegeViewModel : BaseViewModel
    {

        public CollegeViewModel()
        {
            this.CollegeRepresentiveDetail = new CollegeRepresentiveDetail();
            this.CollegeContactDetail = new CollegeContactDetail();
            this.College = new College();
        }

        public College College { get; set; }

        public CollegeContactDetail CollegeContactDetail { get; set; }
        public CollegeRepresentiveDetail CollegeRepresentiveDetail { get; set; }

        public StaticPagedList<College> Items { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }
}
