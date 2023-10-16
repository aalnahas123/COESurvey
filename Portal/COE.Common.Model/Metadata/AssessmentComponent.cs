using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(AssessmentComponentMetaData))]
    public partial class AssessmentComponent : CommonMetaData
    {
        public int? Weight { get; set; } = 0;
        public int? GradingRuleID { get; set; } = -1;

        internal class AssessmentComponentMetaData
        {
             
        }
    }
}
