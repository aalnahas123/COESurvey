using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(AcademicYearMetaData))]
    public partial class AcademicYear
    {
        class AcademicYearMetaData
        {

            [Display(Name = "MD_AcademicYear_Name", ResourceType = typeof(DCSResources))]
            public string Name { get; set; }

            [Display(Name = "AcademicYear_StartDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public DateTime StartDate { get; set; }

            [Display(Name = "AcademicYear_EndDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public DateTime EndDate { get; set; }
        }
    }
}
