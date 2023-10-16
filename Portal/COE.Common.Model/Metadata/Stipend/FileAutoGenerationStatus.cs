using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(FileAutoGenerationStatusMetaData))]
    public partial class FileAutoGenerationStatus
    {
        class FileAutoGenerationStatusMetaData
        {
            [Display(Name = "Common_FileGenerationStatus", ResourceType = typeof(StipendResources))]
            public int Name { get; set; }

        }
    }

}
