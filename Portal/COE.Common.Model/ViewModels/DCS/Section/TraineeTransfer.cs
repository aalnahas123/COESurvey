using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels
{
    public class TraineeTransfer
    {
        [Display(Name = "College", ResourceType = typeof(DCSResources))]
        public int CollegeId { get; set; }

        [Display(Name = "Section", ResourceType = typeof(DCSResources))]
        public int SectionId { get; set; }

        [Display(Name = "Section", ResourceType = typeof(DCSResources))]
        public string SectionCode{ get; set; }

        [Display(Name = "ToSection", ResourceType = typeof(DCSResources))]
        public int ToSectionId { get; set; }

        [Display(Name = "ToSection", ResourceType = typeof(DCSResources))]
        public string ToSectionCode { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]

        [Display(Name = "DateFrom", ResourceType = typeof(DCSResources))]
        public DateTime DateFrom { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]

        [Display(Name = "DateTo", ResourceType = typeof(DCSResources))]
        public DateTime DateTo { get; set; }

        public List<LookupViewModel> SectionsList { get; set; }

    }
}
