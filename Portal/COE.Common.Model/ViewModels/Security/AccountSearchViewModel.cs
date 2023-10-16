// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountViewModel.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Common.Model.ViewModels
{
    #region

    using PagedList;

    #endregion

    /// <summary>
    ///     The account view model.
    /// </summary>
    public partial class AccountSearchViewModel
    {
        public string NationalID { get; set; }
        public string UserName { get; set; }

        public int? GenderId { get; set; }
        public int? StateId { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

        public StaticPagedList<AccountViewModel> Items { get; set; }


    }
}