using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(sp_CalculateFinalExamResult_ResultMetaData))]
    public partial class sp_CalculateFinalExamResult_Result : CommonMetaData
    {
        public int VersionsNum { get; set; }

        public int StatusId { get; set; }
        public string StatusText { get; set; }

        public List<string> SelectedNationalIds { get; set; }

        internal class sp_CalculateFinalExamResult_ResultMetaData
        {
           

        }
    }
}