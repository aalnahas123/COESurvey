using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(BondMetaData))]
    public partial class Bond
    {
        class BondMetaData
        {

            [Display(Name = "Bond_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }

            [Display(Name = "Bond_TypeID", ResourceType = typeof(MetaData))]
            public int TypeID { get; set; }

            [Display(Name = "Bond_Value", ResourceType = typeof(MetaData))]
            public decimal Value { get; set; }

            [Display(Name = "Bond_ExpiryDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public System.DateTime ExpiryDate { get; set; }

            [Display(Name = "Bond_SubmissionDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public System.DateTime SubmissionDate { get; set; }


            [Display(Name = "Bond_BankID", ResourceType = typeof(MetaData))]
            public int BankID { get; set; }


            [Display(Name = "Bond_ContractID", ResourceType = typeof(MetaData))]
            public int ContractID { get; set; }


        }
    }

}
