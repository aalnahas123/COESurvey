// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LookupsHelper.cs" company="SURE International Technology">
//   Copyright © 2017 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Survey.Web.Helpers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Commons.Framework.Globalization;
    using Common.Localization;
    using COE.ContractManagement.BLL;
    using Commons.Framework.Extensions;
    using Common.BLL;
    using Commons.Framework.Configuration;
    using System.Data.Entity;
    using BLL;
    using DevExpress.XtraReports.Parameters;
    using Microsoft.AspNet.Identity;

    #endregion


    /// <summary>
    ///     The lookups helper.
    /// </summary>
    public static class LookupsHelper
    {
        /// <summary>
        ///     Gets the user id.
        /// </summary>
        public static Guid UserId => System.Web.HttpContext.Current.User.Identity.GetUserId().To<Guid>();
        public static string UserName => System.Web.HttpContext.Current.User.Identity.GetUserName().To<string>();


        public static List<SelectListItem> GetUserTypes()
        {
            using (var uow = new COEUoW())
            {
                return uow.StaffType.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }
        public static List<SelectListItem> GetGenders()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem { Text = Common.Localization.Security.SecurityResources.Male, Value = "0" });
            result.Add(new SelectListItem { Text = Common.Localization.Security.SecurityResources.Female, Value = "1" });

            return result;
        }

        public static List<SelectListItem> GetVisaTypes()
        {
            using (var uow = new COEUoW())
            {
                return uow.VisaType.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }

        public static List<SelectListItem> GetLevels()
        {
            using (var uow = new COEUoW())
            {
                return uow.StaffLevel.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }
        public static List<SelectListItem> GetQualifications()
        {
            using (var uow = new COEUoW())
            {
                return uow.StaffQualification.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }
        public static List<SelectListItem> GetSpecializations()
        {
            using (var uow = new COEUoW())
            {
                return uow.StaffSpecialization.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }
        public static List<SelectListItem> GetLeaveReasons()
        {
            using (var uow = new COEUoW())
            {
                return uow.LeaveReason.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }
        public static List<SelectListItem> GetJobTypes()
        {
            using (var uow = new COEUoW())
            {
                return uow.JobType.GetAll().Select(c =>
                     new SelectListItem
                     {
                         Value = c.ID.ToString(),
                         Text = c.Name
                     }).ToList();
            }
        }

        /// <summary>
        /// get all current user roles
        /// </summary>
        public static List<Guid> CurrentUserRoles
        {
            get
            {
                using (var uow = new COEUoW())
                {

                    var userDisplay = uow.UserDisplay.GetAll().Where(u => u.AspNetUserID == UserId).FirstOrDefault();

                    if (userDisplay == null)
                    {
                        //check user display by name
                        userDisplay = uow.UserDisplay.GetByQuery(q => q.LoginName == UserName).FirstOrDefault();
                    }
                    var userRoles = userDisplay.AspNetRoles.ToList().Where(x => x != null).Select(i => i.Id).ToList();

                    return userRoles;
                }
            }
        }

        public static List<Guid> GetCurrentUserRoles(string userName)
        {
            using (var uow = new COEUoW())
            {

                var userDisplay = uow.UserDisplay.GetByQuery(x => x.AspNetUsers.UserName.ToLower() == userName.ToLower().Trim() || x.LoginName == userName.ToLower().Trim() || x.LoginName == "coe\\" + userName.ToLower().Trim()).FirstOrDefault();

                if (userDisplay == null) return null;

                var userRoles = userDisplay.AspNetRoles.OrderBy(o => o.Priority).ToList().Where(x => x != null).Select(i => i.Id).ToList();

                return userRoles;
            }
        }
        public static Guid? GetPowerRoleForCurrentUser(string userName)
        {
            using (var uow = new COEUoW())
            {

                var userDisplay = uow.UserDisplay.GetByQuery(x => x.AspNetUsers.UserName.ToLower() == userName.ToLower().Trim() || x.LoginName == userName.ToLower().Trim() || x.LoginName == "coe\\" + userName.ToLower().Trim()).FirstOrDefault();

                if (userDisplay == null) return null;

                var userRoleWithHeightPriority = userDisplay.AspNetRoles.Where(x => x != null).OrderBy(or => or.Priority).FirstOrDefault();

                var powerRoleList = userRoleWithHeightPriority.AspNetRolesParent.Where(x => x.AspRoleIdChild == userRoleWithHeightPriority.Id).Select(s => s.AspRoleId);
                var powerRole = uow.AspNetRoles.GetByQuery(q => powerRoleList.Contains(q.Id)).OrderBy(o => o.Priority).Select(s => s.Id).FirstOrDefault();

                return powerRole;
            }
        }
        public static Guid? GetPowerRoleForAnotherRole(Guid? roleId)
        {
            using (var uow = new COEUoW())
            {
                var powerRole = uow.AspNetRolesParent.GetByQuery(x => x.AspRoleIdChild == roleId).Select(s => s.AspRoleId).FirstOrDefault();
                return powerRole;
            }
        }


        public static List<SelectListItem> GetAspNetRoles()
        {
            using (var uow = new COEUoW())
            {
                var result = uow.AspNetRoles.GetByQuery(w => w.IsActive == true && !CurrentUserRoles.Contains(w.Id)).OrderBy(o => o.Priority).Select(c =>
                                new SelectListItem
                                {
                                    Value = c.Id.ToString(),
                                    Text = c.Name
                                }).ToList();

                return result;
            }
        }

        public static List<SelectListItem> GetAllowedRoles(string loginName)
        {
            using (var context = new COEUoW())
            {
                var isAdmin = GetCurrentUserRoles(loginName).Contains(Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));

                //get role id for current users
                var currentRole = context.UserDisplay.GetByQuery(x => x.LoginName == loginName)
                                                     .SelectMany(s => s.AspNetRoles).OrderBy(or => or.Priority).FirstOrDefault();

                // select all child roles
                var aspNetRolesParent = context.AspNetRoles.GetByQuery(w => w.AspNetRolesParent.Any(a => a.AspRoleId == currentRole.Id)).SelectMany(x => x.AspNetRolesParent).ToList();
                var child = aspNetRolesParent.Select(s => s.AspRoleIdChild).ToList();
                var result = context.AspNetRoles.GetByQuery(q => child.Contains(q.Id));


                var data = result.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                if (isAdmin)
                {
                    data.Insert(0, new SelectListItem { Text = currentRole.Name, Value = currentRole.Id.ToString() });
                }
                return data;
                ////get role id for current users
                //var currentRole = context.UserDisplay.GetByQuery(x => x.LoginName == loginName)
                //        .SelectMany(s => s.AspNetRoles).OrderBy(or => or.Priority).FirstOrDefault();
                //if (GetCurrentUserRoles(loginName).Contains(Guid.Parse(Model.LookupValues.AspNetRoles.Values.SystemAdmin)))
                //{
                //    //get all allowed roles under this role => code > current role code
                //    return context.AspNetRoles.GetByQuery(x => x.Priority >= currentRole.Priority).OrderBy(o => o.Priority).Select(c => new SelectListItem
                //    {
                //        Value = c.Id.ToString(),
                //        Text = c.Name
                //    }).ToList();
                //}
                //else
                //{ //get all allowed roles under this role => code >= current role code
                //    return context.AspNetRoles.GetByQuery(x => x.Priority > currentRole.Priority).OrderBy(o => o.Priority).Select(c => new SelectListItem
                //    {
                //        Value = c.Id.ToString(),
                //        Text = c.Name
                //    }).ToList();
                //}

            }
        }

        public static bool IsCurrentUserAdmin()
        {
            try
            {
                if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    return false;
                }

                var roles = GetCurrentUserRoles(System.Web.HttpContext.Current.User.Identity.Name);
                if (roles == null || !roles.Any())
                {
                    return false;
                }

                return roles.Contains(Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}