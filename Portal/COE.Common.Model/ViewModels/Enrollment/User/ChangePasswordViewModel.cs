using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(UsersMgmtResources))]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,25})",
        //ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UsersMgmtResources))]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,25})",
        ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordNotMatchValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string ConfirmPassword { get; set; }
    }
}
