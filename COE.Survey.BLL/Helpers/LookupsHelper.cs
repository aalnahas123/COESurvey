// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LookupsHelper.cs" company="SURE International Technology">
//   Copyright © 2017 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Survey.BLL.Helpers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Commons.Framework.Extensions;
    using Commons.Framework.Globalization;
    using COE.Common.Localization;
    using Common.DAL;
    using Common.Model;
    using BLL;

    #endregion

    /// <summary>
    ///     The lookups helper.
    /// </summary>
    public static class LookupsHelper
    {
        public static List<SelectListItem> GetModuleCategoryList()
        {
            using (var context = new COEEntities())
            {
                var result = context.ModuleCategory.Where(x => x.IsActive == true).Select(x =>
                   new SelectListItem
                   {
                       Value = x.ID.ToString(),
                       Text = x.Name,
                   }).ToList();

                return result;
            }
        }
        public static List<SelectListItem> GetModules()
        {
            using (var context = new COEEntities())
            {
                var result = context.Module.Where(x => x.IsActive == true).Select(x =>
                   new SelectListItem
                   {
                       Value = x.ID.ToString(),
                       Text = x.Name,
                   }).ToList();

                return result;
            }
        }

        public static List<SelectListItem> GetModulesConcatinateByCategoryName()
        {
            using (var context = new COEEntities())
            {
                var result = context.Module.Select(x =>
                   new SelectListItem
                   {
                       Value = x.ID.ToString(),
                       Text = x.Name+" - "+x.ModuleCategory.Name,
                   }).ToList();

                return result;
            }
        }


        public static List<SelectListItem> GetActions()
        {
            using (var context = new COEEntities())
            {
                var result = context.Action.Where(x => x.IsActive == true).Select(x =>
                   new SelectListItem
                   {
                       Value = x.ID.ToString(),
                       Text = x.Name,
                   }).ToList();

                return result;
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


    }
}