using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class AcademicYearTermViewModel : BaseViewModel
    {
        public AcademicYearTermViewModel()
        {
        }
        public int AcademicYearID { get; set; }

        public int TermTypeID { get; set; }

        [Required]
        public System.DateTime StartDate { get; set; }

        [Required]
        public System.DateTime EndDate { get; set; }

        public int TermOrdering { get; set; }

        public int? SelectedTermTypeID { get; set; }

    }
}
