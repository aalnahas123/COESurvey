using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model.CenterVMs
{
    public class TrainersQualificationsVM
    {
        public int? ID { get; set; }

        [Display(Name = "TrainerName", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(500, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string Name { get; set; }

        [Display(Name = "TrainerLevel", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int? LevelID { get; set; }

        [Display(Name = "EducationExperience", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(255, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string EducationExperience { get; set; }

        [Display(Name = "YearsOfEducationExperience", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [NumbersOnly]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int YearsOfEducationExperience { get; set; }

        [Display(Name = "TeachingExperienceSector", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string TeachingExperienceSector { get; set; }

        [Display(Name = "ManagedUnits", ResourceType = typeof(RPLResources))]
        [StringLength(255, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string ManagedUnits { get; set; }
       
        [Display(Name = "TrainerQualification", ResourceType = typeof(RPLResources))]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int? QualificationID { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "CV", ResourceType = typeof(RPLResources))]
        [ValidateFileUpload]
        //[RequiredIf("string.IsNullOrEmpty(Convert.ToString(CV_ID))", ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase CV { get; set; }

        public Guid? CV_ID { get; set; }
    }
}
