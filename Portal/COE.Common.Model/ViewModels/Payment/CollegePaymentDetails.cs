using PagedList;
using System;
namespace COE.Common.Model.ViewModels
{
    public class CollegePaymentDetails : BaseViewModel
    {          
        public string CollegeName { get; set; }
        public string AcademicYearName { get; set; }
        public string Term { get; set; }
        public double CalcualtedPaymentAmount { get; set; }
    }
}
