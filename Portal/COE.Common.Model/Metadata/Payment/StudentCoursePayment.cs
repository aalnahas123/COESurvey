using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(StudentCoursePaymentMetaData))]
    public partial class StudentCoursePayment
    {    

        public string Repeated
        {
            get
            {
                return (RepetitionFactor == 2 ? "Yes": "No");
            }
        }

        public string Payable
        {
            get
            {
                return (PayableFactor == 1 ? "Yes" : "No");
            }
        }

    }


    public class StudentCoursePaymentMetaData
    {
        [Display(Name = "MD_CalculatedPaymentAmount", ResourceType = typeof(PaymentResource))]
        public double CalculatedAmount { get; set; }

        [Display(Name = "MD_Repeated", ResourceType = typeof(PaymentResource))]
        public string Repeated { get; }

        [Display(Name = "MD_Payable", ResourceType = typeof(PaymentResource))]
        public string Payable { get; }

    }

}
