using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(AcademicYearTermMetaData))]
    public partial class AcademicYearTerm
    {
        class AcademicYearTermMetaData
        {


            [Display(Name = "AcademicYearTerm_StartDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public DateTime StartDate { get; set; }

            [Display(Name = "AcademicYearTerm_EndDate", ResourceType = typeof(MetaData))]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            public DateTime EndDate { get; set; }

            [Display(Name = "AcademicYearTerm_AcademicYearID", ResourceType = typeof(MetaData))]
            public int AcademicYearID { get; set; }

            [Display(Name = "AcademicYearTerm_TermTypeID", ResourceType = typeof(MetaData))]
            public int TermTypeID { get; set; }

            [Display(Name = "AcademicYearTerm_TermOrdering", ResourceType = typeof(MetaData))]
            public int TermOrdering { get; set; }

        }
    }
}
