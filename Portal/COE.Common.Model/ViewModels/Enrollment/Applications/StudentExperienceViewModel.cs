using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using Commons.Framework.Web.Mvc.Helpers;
using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Common.Model
{
    public class StudentExperienceViewModel
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ApplicantResources), Name = "Region")]
        public int RegionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(ApplicantResources), Name = "City")]
        public int CityID { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "IsArabicSpeaking", ResourceType = typeof(ApplicantResources))]
        public bool IsArabicSpeaking { get; set; }

        [Range(0, 1)]
        [NumbersOnly]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public short Experience { get; set; } = 1;

        [Range(0, 40)]
        [NumbersOnly]
        [Display(Name = "ExperienceYears", ResourceType = typeof(ApplicantResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public short ExperienceYears { get; set; }

        [Range(0, 12)]
        [NumbersOnly]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public Nullable<short> ExperienceMonths { get; set; }

        [Range(0, 30)]
        [NumbersOnly]
        [Display(Name = "OSHExperienceYears", ResourceType = typeof(ApplicantResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public Nullable<short> OSHExperienceYears { get; set; }

        [Range(0, 12)]
        [NumbersOnly]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public Nullable<short> OSHExperienceMonths { get; set; }

        [Display(Name = "WarrantAllInformationCorrect", ResourceType = typeof(RPLResources))]
        [MustBeTrue(ErrorMessageResourceType = typeof(RPLResources), ErrorMessageResourceName = "MustWarrantAllInformationCorrect")]
        public bool WarrantAllInformationCorrect { get; set; }

    }
}
