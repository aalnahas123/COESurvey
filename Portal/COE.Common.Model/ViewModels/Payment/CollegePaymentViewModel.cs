using COE.Common.Localization;
using COE.Common.Model.ViewModels.DCS;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public class CollegePaymentViewModel : BaseViewModel
    {       
        [Required]
        [Display(Name = "Provider", ResourceType = typeof(PaymentResource))]
        public int ProviderID { get; set; }

        [Required]
        [Display(Name = "AcademicYear", ResourceType = typeof(PaymentResource))]
        public string AcademicYearID { get; set; }

        [Required]
        [Display(Name = "College", ResourceType = typeof(PaymentResource))]
        public int CollegeID { get; set; }

        [Display(Name = "Term", ResourceType = typeof(PaymentResource))]
        public int? AcademicYearTermID { get; set; }

        public string ProviderName { get; set; }

        public string AcademicYearName { get; set; }

        public string CollegeName { get; set; }

        public string AcademicYearTermName { get; set; }

       

        public List<CollegePayment> CollegePayments { get; set; }
        public List<LookupViewModel> ProvidersList { get; set; }
        public List<LookupViewModel> CollegesList { get; set; }
        public List<ExtendedLookupViewModel> AcademicYearsList { get; set; }
        public List<LookupViewModel> TermsList { get; set; }

        public bool IsStartProgress { get; set; }

        public bool IsReadyToStart { get; set; }

        public PaymentSetting PaymentSetting { get; set; }
    }
}
