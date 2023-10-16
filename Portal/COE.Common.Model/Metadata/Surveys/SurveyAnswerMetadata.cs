using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(SurveyAnswerMetadata))]
    public partial class SurveyAnswer
    {
        public string SurveyText { get; set; }

        internal class SurveyAnswerMetadata
        {
            
        }
    }
}