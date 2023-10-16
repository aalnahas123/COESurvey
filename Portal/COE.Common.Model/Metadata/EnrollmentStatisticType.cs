using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(EnrollmentStatisticTypeMetaData))]
    public partial class EnrollmentStatisticType : CommonMetaData
    {
        internal class EnrollmentStatisticTypeMetaData
        {

            [Display(Name = "EnrollmentStatisticType_Name", ResourceType = typeof(MetaData))]
            public string Name { get; set; }
        }
    }
}

