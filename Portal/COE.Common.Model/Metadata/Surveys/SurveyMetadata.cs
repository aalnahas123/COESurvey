using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COE.Common.Model
{
    [MetadataType(typeof(SurveyMetadata))]
    public partial class Survey
    {
        public string ModuleText { get; set; }
        public string SurveyLink { get; set; }

        public bool IsActive { get; set; }
        public bool CanEdit { get; set; }

        public string SurveyDirection { get; set; }

        internal class SurveyMetadata
        {
            
        }
    }
}