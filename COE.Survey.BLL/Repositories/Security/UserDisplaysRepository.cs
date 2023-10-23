using COE.Common.BLL;
using System;
using System.Linq;

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
