using COE.Common.DAL;
using COE.Common.Localization;
using COE.Common.Model;
using COE.Common.Model.Enums;
using COE.Common.Model.ViewModels;
using Commons.Framework;
using System;
using System.Linq;

namespace COE.Survey.BLL.Repositories
{
    public partial class AspNetUsersRepository
    {
        /// <summary>
        /// Search Users
        /// </summary>
        /// <param name="model"></param>
        /// <returns>IQueryable<AspNetUsers></returns>
        public virtual IQueryable<AllUsersModel> Search(AspNetUsersSearchModel model, string UserName)
        {
            var unitOfWork = new COEUoW();

            var allowedRoles = unitOfWork.AspNetRoles.GetAllowedRoleForUser(UserName);
            var isAdmin = unitOfWork.AspNetRoles.GetCurrentUserRoles(UserName).Contains(Guid.Parse(LookupValues.AspNetRoles.Values.SystemAdmin));

            var users = unitOfWork.UserDisplay.GetAll();

            //search in AD or ASPNetUsers 
            if (model.UserType == ((int)Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString())
            {
                if (!isAdmin)
                {
                    users = users.Where(x => x.AspNetUsers == null
                             && (x.AspNetRoles.Any(ar => allowedRoles.Contains(ar.Id))));
                }
                else
                {
                    users = users.Where(x => x.AspNetUsers == null);
                }

                if (!string.IsNullOrEmpty(model.UserName))
                {
                    users = users.Where(a => a.LoginName.ToLower().Contains(model.UserName.ToLower().Trim())).OrderBy(x => x.ID);
                }
                if (model.ADRoleId != null)
                {
                    users = users.Where(x => x.AspNetRoles.Select(o => o.Id).ToList().Contains(model.ADRoleId.Value));
                }
                if (model.ADCollegeId != null)
                {
                    users = users.Where(x => x.UserCollege.Select(c => c.CollegeID).ToList().Contains(model.ADCollegeId.Value));
                }
            }
            else
            {
                //get users with roles <= current user rol 
                //get users with current user colleges
                if (!isAdmin)
                {
                    users = users.Where(x => x.AspNetUsers != null
                             && (x.AspNetRoles.Any(ar => allowedRoles.Contains(ar.Id)))
                             );
                }
               

                if (model.RoleId != null)
                {
                    users = users.Where(x => x.AspNetRoles.Select(o => o.Id).ToList().Contains(model.RoleId.Value));
                }
                if (model.CollegeId != null)
                {
                    users = users.Where(x => x.UserCollege.Select(c => c.CollegeID).ToList().Contains(model.CollegeId.Value));
                }
                if (!string.IsNullOrEmpty(model.UserNameOnline))
                {
                    users = users.Where(a => a.AspNetUsers.UserName.ToLower().Contains(model.UserNameOnline.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }

                if (!string.IsNullOrEmpty(model.Email))
                {
                    users = users.Where(a => a.AspNetUsers.Email.ToLower().Contains(model.Email.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    users = users.Where(a => a.AspNetUsers.PhoneNumber.Contains(model.Phone.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }
                if (!string.IsNullOrEmpty(model.NationalId))
                {
                    users = users.Where(a => a.AspNetUsers.NationalId.Contains(model.NationalId.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }
            }
            if (users != null)
            {
                //Add The Result To Unified Users List [ID-Name]
                var AllUsers = users.Select(cc => new AllUsersModel
                {
                    Id = cc.ID,
                    Email = cc.AspNetUsers.Email ?? "",
                    DisplayId = cc.ID,
                    UserName = cc.LoginName,
                    FullName = cc.AspNetUsers.FullName == null ? cc.DisplayName : cc.AspNetUsers.FullName,
                    Type = (int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory,
                    IsActive = cc.IsActive,
                    CreatedBy = cc.CreatedBy
                });
                return AllUsers;
            }
            else
            {
                return null;
            }

        }
    }
}
