using COE.Common.DAL;
using COE.Common.Localization;
using COE.Common.Model;
using COE.Common.Model.Enums;
using COE.Common.Model.ViewModels;
using Commons.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COE.Survey.BLL.Repositories
{
    public partial class AspNetRolesRepository
    {
        public virtual ReturnResult Insert(AspNetRoles model)
        {
            var result = new ReturnResult();

            if (this.DbSet.Any(r => r.Name.ToLower().Trim() == model.Name.ToLower().Trim())) result.ModelState.AddModelError("Name", SharedResources.NameAddedBefore);
            if (!result.ModelState.IsValid) return result;

            this.Add(model);
            return result;
        }

        public virtual ReturnResult Edit(AspNetRoles model)
        {
            var result = new ReturnResult();

            if (this.DbSet.Any(r => r.Name.ToLower().Trim() == model.Name.ToLower().Trim() && r.Id != model.Id)) result.ModelState.AddModelError("Name", SharedResources.NameAddedBefore);
            if (!result.ModelState.IsValid) return result;

            this.Update(model.Id, model);
            return result;
        }

        public virtual ReturnResult Validate(PowerRoleviewModel model)
        {
            var result = new ReturnResult();
            if (model.AspNetRoles.Roles == null || model.AspNetRoles.Roles.Length <= 0)
            {
                result.ModelState.AddModelError("AspNetRoles.Roles", Common.Localization.Security.SecurityResources.SelectRoleMsg);
            }
            //if (!model.ModuleCategories.Any(a => a.IsSelected == true))
            //{
            //    result.ModelState.AddModelError("ModuleCategories", Common.Localization.Security.SecurityResources.SelectModuleCategoryMsg);
            //}
            return result;
        }

        public virtual List<Guid> GetAllowedRoleForUser(string loginName, Guid? RoleId = null)
        {
            using (var context = new COEEntities())
            {
                List<Guid> result = new List<Guid>();

                //get role id for current users
                var currentRole = context.UserDisplay.Where(x => x.LoginName == loginName)
                                                     .SelectMany(s => s.AspNetRoles).OrderBy(or => or.Priority).FirstOrDefault();

                // select all child roles
                var childRoles = context.AspNetRoles.Where(w => w.AspNetRolesParent.Any(a => a.AspRoleId == currentRole.Id)).SelectMany(x => x.AspNetRolesParent).ToList();


                result = childRoles.Select(x => x.AspRoleIdChild).ToList();
                // add the current role if system admin to allowed roles list
                if (RoleId.HasValue)
                {
                    if (currentRole.Id == RoleId.Value)
                    {
                        result.Add(currentRole.Id);
                    }
                }


                return result;
            }
        }

        public virtual List<Guid> GetCurrentUserRoles(string userName)
        {
            using (var uow = new COEUoW())
            {

                var userDisplay = uow.UserDisplay.GetByQuery(x => x.AspNetUsers.UserName.ToLower() == userName.ToLower().Trim() || x.LoginName == userName.ToLower().Trim() || x.LoginName == "coe\\" + userName.ToLower().Trim()).FirstOrDefault();

                if (userDisplay == null) return null;

                var userRoles = userDisplay.AspNetRoles.OrderBy(o => o.Priority).ToList().Where(x => x != null).Select(i => i.Id).ToList();

                return userRoles;
            }
        }

        /// <summary>
        /// Delete an course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public virtual bool Delete(int id)
        //{
        //    if (id <= 0)
        //        throw new ArgumentNullException("ID");

        //    try
        //    {
        //        using (var unit = new COEUoW())
        //        {
        //            //delete all term courses ,before deleting the course
        //            var termCourses = this.GetCourseOpenTermsById(id);
        //            foreach (var termCourse in termCourses)
        //            {
        //                unit.TermCourse.DeleteById(termCourse.ID);
        //            }
        //            if (termCourses != null && termCourses.Count > 0)
        //                unit.Save();

        //            //delete the course
        //            bool deleted = unit.Course.DeleteById(id);
        //            unit.Save();
        //            return deleted;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
