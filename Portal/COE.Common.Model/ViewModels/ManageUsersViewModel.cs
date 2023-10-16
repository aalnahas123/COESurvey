// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageUsersViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The user inbox view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using System.ComponentModel.DataAnnotations;

    using Commons.Framework.Web.Mvc.DataAnnotations;
    using Commons.Framework.Web.Mvc.Helpers;

    using PagedList;

    using Localization;
    using UsersMgmt.Model;

    #endregion

    /// <summary>
    ///     The users Management view model.
    /// </summary>
    public class ManageUsersViewModel
    {
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [EmailAddress(ErrorMessageResourceName = "EmailValidator", ErrorMessageResourceType = typeof(UsersMgmtResources))]
        [Display(Name = "Email", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(60, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        [Display(Name = "FullName", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(150, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        [DisableScripts]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the is activated.
        /// </summary>
        [Display(Name = "ActiveStatus", ResourceType = typeof(UsersMgmtResources))]
        public bool? IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        public StaticPagedList<ApplicationUser> Items { get; set; }

        /// <summary>
        ///     Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        ///     Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Gets or sets the identity Number.
        /// </summary>
        [ValidatePhoneNumber(ErrorMessageResourceName = "InvalidMobileNumber",
            ErrorMessageResourceType = typeof(UsersMgmtResources), NumberType = NumberType.MOBILE, CountryCode = "SA")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(UsersMgmtResources))]
        [StringLength(15, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(SharedResources))]
        public string PhoneNumber { get; set; }


    }
}