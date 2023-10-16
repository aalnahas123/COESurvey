using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model
{
    [MetadataType(typeof(RequestMetaData))]
    public partial class Request : CommonMetaData
    {
        internal class RequestMetaData
        {

            [Display(Name = "Request_RequestNumber", ResourceType = typeof(MetaData))]
            public string RequestNumber { get; set; }

        }
    }
}
