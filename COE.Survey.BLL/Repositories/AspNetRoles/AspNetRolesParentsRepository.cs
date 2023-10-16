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
    public partial class AspNetRolesParentsRepository
    {
        public virtual ReturnResult Insert(AspNetRoles model)
        {
            var result = new ReturnResult();
            AspNetRolesRepository asproles = new AspNetRolesRepository(Context);
            List<AspNetRolesParent> AspNetRolesParents = new List<AspNetRolesParent>();

            //get all AspRoles by roleid ->edit mode
            var parenRoles = this.GetByQuery(x => x.AspRoleId == model.Id).ToList();

            // insert bulk with model id
            try
            {
                //delete child roles
                foreach (var item in parenRoles)
                {
                    this.DbSet.Remove(item);
                    this.Delete(item);
                }
                
                    foreach (var item in model.Roles)
                    {
                        this.Add(new AspNetRolesParent { AspRoleId = model.Id, AspRoleIdChild = item });
                    }
                
            }
            catch (Exception ex)
            {
                result.ModelState.AddModelError("AspNetRoles.Roles", SharedResources.UnexpectedError);
            }
            return result;
        }
    }
}
