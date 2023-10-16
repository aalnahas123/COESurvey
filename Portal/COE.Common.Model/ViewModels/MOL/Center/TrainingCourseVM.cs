using COE.Common.Localization;
using ExpressiveAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.CenterVMs
{
    public class TrainingCourseVM
    {
        [Display(Name = "City", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int CityID { get; set; }

        [Display(Name = "Male", ResourceType = typeof(RPLResources))]
        public bool Male { get; set; }

        [Display(Name = "Female", ResourceType = typeof(RPLResources))]
        public bool Female { get; set; }

        [Display(Name = "NumberOfTeachers", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int NumberOfTeachers { get; set; }

        [Display(Name = "NumberOfTrainees", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int NumberOfTrainees { get; set; }

        public int? ID { get; set; }
    }
}