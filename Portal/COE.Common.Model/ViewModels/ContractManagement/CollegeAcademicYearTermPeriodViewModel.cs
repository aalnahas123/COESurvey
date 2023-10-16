using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class CollegeAcademicYearTermPeriodViewModel : BaseViewModel
    {
        public CollegeAcademicYearTermPeriodViewModel()
        {
        }
        public int CollegeAcademicYearID { get; set; }
        public int AcademicYearTermID { get; set; }
        public Nullable<System.DateTime> AdmissionStartDate { get; set; }
        public Nullable<System.DateTime> AdmissionEndDate { get; set; }
        public Nullable<System.DateTime> RegistrationStartDate { get; set; }
        public Nullable<System.DateTime> RegistrationEndDate { get; set; }
        public Nullable<System.DateTime> DissmisStartDate { get; set; }
        public Nullable<System.DateTime> DissmisEndDate { get; set; }
        public Nullable<System.DateTime> TransferStartDate { get; set; }
        public Nullable<System.DateTime> TransferEndDate { get; set; }
        public Nullable<System.DateTime> DeferralStartDate { get; set; }
        public Nullable<System.DateTime> DeferralEndDate { get; set; }
        public Nullable<System.DateTime> ExamStartDate { get; set; }
        public Nullable<System.DateTime> ExamEndDate { get; set; }
        public Nullable<System.DateTime> WithDrawStartDate { get; set; }
        public Nullable<System.DateTime> WithDrawEndDate { get; set; }

    }
}
