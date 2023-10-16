using System.ComponentModel.DataAnnotations;
using COE.Common.Localization;

namespace COE.Common.Model
{
    public abstract class CommonMetaData
    {

        [Display(Name = "Common_CreatedBy", ResourceType = typeof(MetaData))]
        public string CreatedBy { get; set; }

        [Display(Name = "Common_CreatedOn", ResourceType = typeof(MetaData))]
        public System.DateTime CreatedOn { get; set; }

        [Display(Name = "Common_UpdatedBy", ResourceType = typeof(MetaData))]
        public string UpdatedBy { get; set; }

        [Display(Name = "Common_UpdatedOn", ResourceType = typeof(MetaData))]
        public System.DateTime UpdatedOn { get; set; }
    }

}
