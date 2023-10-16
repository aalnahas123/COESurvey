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
    public partial class StaffSearchViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? College { get; set; }
        public int? UserType { get; set; }
        public int? VisaType { get; set; }
        public int? Specialization { get; set; }
        public int? Qualification { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

        public StaticPagedList<CollegeStaff> Items { get; set; }
    }
}