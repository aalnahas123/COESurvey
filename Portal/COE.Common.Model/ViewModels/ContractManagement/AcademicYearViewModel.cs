using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class AcademicYearViewModel : BaseViewModel
    {
        public AcademicYearViewModel()
        {
            this.AcademicYearTerms = new List<AcademicYearTermViewModel>();
        }

        //[Required]
        //public string Name { get; set; }

        //[Required]
        //public string NameAr { get; set; }

       
        public Nullable<bool> IsCurrent { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public System.DateTime StartDate { get; set; }

        [Required]
        public System.DateTime EndDate { get; set; }

        public List<AcademicYearTermViewModel> AcademicYearTerms { get; set; }

    }
}
