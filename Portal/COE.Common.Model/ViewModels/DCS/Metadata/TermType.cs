using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(TermTypeMetaData))]
    public partial class TermType
    {
        class TermTypeMetaData
        {
            [Display(Name = "MD_TermType_Name", ResourceType = typeof(DCSResources))]
            
            public string Name { get; set; }
        }
    }
}
