using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(SurveyQuestionMetadata))]
    public partial class SurveyQuestion
    {
        public string TypeText { get; set; }

        internal class SurveyQuestionMetadata
        {
            
        }
    }
}