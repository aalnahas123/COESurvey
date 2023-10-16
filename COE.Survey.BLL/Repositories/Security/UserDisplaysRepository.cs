using COE.Common.DAL;
using COE.Common.Model;
using COE.Common.Model.ViewModels.Enrollment;
using Commons.Framework.Data;
using Commons.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using COE.Common.BLL;

namespace COE.Survey.BLL.Repositories
{
    public partial class UserDisplaysRepository
    {

        private string domainName = @"coe\";

        public virtual bool HasUserDisplay(string username)
        {
            bool result = false;
            try
            {
                var userNameWithoutDomain = username.ToLower().Replace(domainName, "");
                result = this.GetByQuery(uD => uD.LoginName.ToLower() == username.ToLower()).Any()
                    || this.GetByQuery(uD => uD.LoginName.ToLower() == userNameWithoutDomain).Any();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public virtual List<UserDisplayViewModel> GetUserByCollegeAndRole(int collegeId, Guid roleId)
        {
            //try
            //{
            using (var context = new COEEntities())
            {
                var userModel = context.uspGetUsersByCollegeIdAndRoleId(collegeId, roleId).Select(ud => new UserDisplayViewModel()
                {
                    ID = ud.ID,
                    LoginName = ud.LoginName,
                    Email = ud.Email,
                    FullName = ud.FullName,
                    IsActiveDirectory = ud.IsActiveDirectory == 0 ? false : true,
                    DisplayName = ud.DisplayName,
                    IsActive = ud.IsActive,
                    AspNetUserID = ud.AspNetUserID,
                    CreatedBy = ud.CreatedBy,
                    CreatedOn = ud.CreatedOn,
                    UpdatedBy = ud.UpdatedBy,
                    UpdatedOn = ud.UpdatedOn
                }).ToList();

                return userModel;
            }
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }

        public virtual List<int> GetCollegeIdsByUserLoginName(string loginName)
        {
            using (var context = new COEEntities())
            {
                var userNameWithoutDomain = loginName.ToLower().Replace(domainName, "");

                var query = (from college in context.College
                             join userCollege in context.UserCollege on college.ID equals userCollege.CollegeID
                             join user in context.UserDisplay on userCollege.UserDisplayID equals user.ID
                             where (user.LoginName == loginName || user.LoginName.ToLower() == userNameWithoutDomain)
                             orderby college.Name
                             select college.ID);

                return query.Distinct().ToList();
            }
        }


        public virtual bool IsUserInRole(string userName, AspNetRolesNames roleName)
        {
            var userNameWithoutDomain = userName.ToLower().Replace(domainName, "");
            var code = (int)roleName;
            return
                base.GetAll()
                .Any(x => x.LoginName.ToLower() == userName.ToLower()
                && x.AspNetRoles.Any(r => r.Code == code))
                ||
                base.GetAll()
                .Any(x => x.LoginName.ToLower() == userNameWithoutDomain.ToLower()
                && x.AspNetRoles.Any(r => r.Code == code));
            //return UserManager.IsUserInRole(userName, roleName.ToString());
        }

    }
}
