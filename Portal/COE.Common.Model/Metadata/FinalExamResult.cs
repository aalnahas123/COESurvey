using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(FinalExamResultMetaData))]
    public partial class FinalExamResult : CommonMetaData
    {
        public string IncomingPortfolioResult { get; set; }
        public string IncomingCapstoneResult { get; set; }
        public string IncomingCBTResult { get; set; }

        public string PortfolioResult { get; set; }
        public string CapstoneResult { get; set; }
        public string CBTResult { get; set; }
        public int PortfolioResultId { get; set; }
        public int CapstoneResultId { get; set; }
        public int CBTResultId { get; set; }

        public int VersionsNum { get; set; }

        public int StatusId { get; set; }
        public string StatusText { get; set; }

        public List<string> SelectedNationalIds { get; set; }

        internal class FinalExamResultMetaData
        {
           

        }
    }
}