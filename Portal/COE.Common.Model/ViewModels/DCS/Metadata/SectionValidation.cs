using COE.Common.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(SectionValidationMetaData))]
    public partial class SectionValidation
    {
        class SectionValidationMetaData
        {

            [Display(Name = "MD_SectionValidation_CourseCode", ResourceType = typeof(DCSResources))]
            public string CourseCode { get; set; }


            [Display(Name = "MD_SectionValidation_SectionCode", ResourceType = typeof(DCSResources))]
            public string SectionCode { get; set; }


            [Display(Name = "MD_SectionValidation_FirstMonth", ResourceType = typeof(DCSResources))]
            public Nullable<decimal> FirstMonth { get; set; }


            [Display(Name = "MD_SectionValidation_SecondMonth", ResourceType = typeof(DCSResources))]
            public Nullable<decimal> SecondMonth { get; set; }

 
            [Display(Name = "MD_SectionValidation_ThirdMonth", ResourceType = typeof(DCSResources))]
            public Nullable<decimal> ThirdMonth { get; set; }

            [Display(Name = "MD_SectionValidation_FourthMonth", ResourceType = typeof(DCSResources))]
            public Nullable<decimal> FourthMonth { get; set; }
        }
    }
}