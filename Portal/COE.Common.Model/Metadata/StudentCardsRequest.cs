using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    
    [MetadataType(typeof(StudentCardsRequestMetaData))]
    public partial class StudentCardsRequest : CommonMetaData
    {
        
    }
    internal class StudentCardsRequestMetaData
    {       

        [Display(Name = "Cards_CardNo", ResourceType = typeof(StipendResources))]
        public string CardNo { get; set; }

        [Display(Name = "Cards_BankIBAN", ResourceType = typeof(StipendResources))]
        public string BankIBAN { get; set; }

        [Display(Name = "Cards_FeedbackStatus", ResourceType = typeof(StipendResources))]
        public Nullable<int> CardsFeedbackStatusID { get; set; }

        [Display(Name = "Cards_FeedbackDenialReason", ResourceType = typeof(StipendResources))]
        public Nullable<int> CardsFeedbackDenialReasonID { get; set; }
    }
}
