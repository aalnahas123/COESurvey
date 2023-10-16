using COE.Common.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RM.Workflow;
using ExpressiveAnnotations.Attributes;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class DecisionViewModel
    {
        public DecisionViewModel()
        {
        }
        public long RequestId { get; set; }
        public int RequestType { get; set; }
        public List<SelectListItem> ActionList { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RequestAction", ResourceType = typeof(AppResources))]
        public string  SelectedAction { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string ActionComment { get; set; }
        
        [Display(Name = "SerialNumber", ResourceType = typeof(WithdrawRequestResources))]
        public string SerialNumber { get; set; }

        #region Students Disability Request Property
        // Custom property for student disability request
        [Display(Name = "StudentsDisabilityLevel", ResourceType = typeof(StudentsDisabilityRequestResource))]
        [RequiredIf("RequestType == 9", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public int? StudentsDisabilityLevelId { get; set; }

        public bool IsStudentAffairsSpecialistActivity { get; set; } 
        #endregion

    }
}
