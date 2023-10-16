﻿using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class PaymentRequestsSearchViewModel
    {

        [Display(Name = "College", ResourceType = typeof(PaymentResource))]
        public int? CollegeId { get; set; }      

        [Display(Name = "Term", ResourceType = typeof(PaymentResource))]
        public int? TermId { get; set; }

        [Display(Name = "AcademicYear", ResourceType = typeof(PaymentResource))]
        public int? CollegeAcademicYearId { get; set; }

        [Display(Name = "Approved", ResourceType = typeof(PaymentResource))]
        public int? IsApproved { get; set; }
 
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; }

        public List<LookupViewModel> CollegesList { get; set; }

        public List<LookupViewModel> CollegeAcademicYearsList { get; set; }

        public List<LookupViewModel> TermsList { get; set; }
        public List<LookupViewModel> ApproveList { get; set; }

        public StaticPagedList<CollegePayment> Items { get; set; }

        public string UserName { get; set; }
    }
}
