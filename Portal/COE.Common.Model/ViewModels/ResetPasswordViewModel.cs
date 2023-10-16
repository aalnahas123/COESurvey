// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using Localization;
    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    /// The forgot password view model.
    /// </summary>
    public class ResetPasswordViewModel
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UsersMgmtResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordNotMatchValidator",
             ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UsersMgmtResources))]
        [RegularExpression(@"^.{6,25}$",
             ErrorMessageResourceName = "PasswordValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        [Required]
        public Guid? UserId { get; set; }
    }
}