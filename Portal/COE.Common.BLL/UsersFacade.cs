using System;
using System.Collections.Generic;
using UsersMgmt.Model;

namespace COE.Common.BLL
{
    using Common.Localization;
    using Commons.Framework;
    using Commons.Framework.Data;
    using Microsoft.AspNet.Identity.Owin;
    using System.Linq;
    using System.Web;
    using UsersMgmt;


    using Microsoft.AspNet.Identity;

    using System.Data.Entity.Infrastructure.Interception;

    using System.Transactions;



    /// <summary>
    /// The users facade.
    /// </summary>
    public static class UsersFacade
    {
        /// <summary>
        ///     The current user.
        /// </summary>
        public static ApplicationUser CurrentUser => UserManager?.CurrentUser;

        /// <summary>
        ///     The current user id.
        /// </summary>
        public static Guid? CurrentUserId => UserManager?.CurrentUserId;

        /// <summary>
        ///     Gets the current user name.
        /// </summary>
        public static string CurrentUserName => UserManager?.CurrentUserName;

        /// <summary>
        /// The current user roles.
        /// </summary>
        public static List<ApplicationRole> CurrentUserRoles => UserManager.CurrentUserRoles;

        /// <summary>
        /// The current user roles.
        /// </summary>
        public static bool IsActiveDirectoryUser = false;


        /// <summary>
        ///     The user manager.
        /// </summary>
        private static ApplicationUserManager UserManager
            => HttpContext.Current?.GetOwinContext()?.GetUserManager<ApplicationUserManager>();

        /// <summary>
        /// The activate user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult ActivateUser(Guid userId)
        {
            return UserManager.UpdateUserActivationState(userId, true);
        }

        /// <summary>
        /// The change password.
        /// </summary>
        /// <param name="currentPassword">
        /// The current password.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult ChangePassword(string currentPassword, string newPassword)
        {
            return UserManager.ChangePassword(currentPassword, newPassword);
        }
        public static ReturnResult ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            return UserManager.ChangePasswordForUser(userId, currentPassword, newPassword);
        }
        /// <summary>
        /// The reset password.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult ResetPassword(Guid userId, string newPassword)
        {
            return UserManager.ResetPassword(userId, newPassword);
        }

        /// <summary>
        /// The confirm user email.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="paymentRequired">
        /// The payment required.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult ConfirmUserEmail(Guid userId, int code, bool paymentRequired)
        {
            return UserManager.ConfirmUserEmail(
                userId,
                code,
                paymentRequired ? ConfirmEmailType.ConfirmSuccessEmail : ConfirmEmailType.WelcomeNewUserEmail);
        }

        /// <summary>
        /// The de activate user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="reason">
        /// The reason.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult DeActivateUser(Guid userId, string reason)
        {
            return UserManager.UpdateUserActivationState(userId, false, reason);
        }


        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="ApplicationUser"/>.
        /// </returns>
        public static ApplicationUser FindById(Guid userId)
        {
            return UserManager.FindById(userId);
        }

        /// <summary>
        /// The find by name.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="ApplicationUser"/>.
        /// </returns>
        public static ApplicationUser FindByName(string userName)
        {
            return UserManager.GetByName(userName);
        }

        /// <summary>
        /// The get localized user role names.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<string> GetLocalizedUserRoleNames(ApplicationUser user)
        {
            return UserManager.GetLocalizedUserRoleNames(user);
        }

        /// <summary>
        /// The get localized user role names.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<string> GetLocalizedUserRoleNames(Guid userId)
        {
            return UserManager.GetLocalizedUserRoleNames(userId);
        }


        /// <summary>
        /// The get users.
        /// </summary>
        /// <param name="createdBy">
        /// The created by.
        /// </param>
        /// <param name="pageNum">
        /// The page num.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
        public static PagedList<ApplicationUser> GetUsers(string createdBy, int pageNum, int pageSize)
        {
            return UserManager.Users.Where(u => u.CreatedBy == createdBy)
                .GetPaged(u => u.CreatedOn, true, pageNum, pageSize);
        }

        /// <summary>
        /// The get users in role.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="pageNum">
        /// The page num.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
        public static PagedList<ApplicationUser> GetUsersInRole(Guid roleId, int pageNum, int pageSize)
        {
            return UserManager.GetUsersInRole(roleId, pageNum, pageSize);
        }

        /// <summary>
        /// The get users in role.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <param name="pageNum">
        /// The page num.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
        public static PagedList<ApplicationUser> GetUsersInRole(string roleName, int pageNum, int pageSize)
        {
            return UserManager.GetUsersInRole(roleName, pageNum, pageSize);
        }

        /// <summary>
        /// The is current user in role.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsCurrentUserInRole(RoleName roleName)
        {
            return UserManager.IsCurrentUserInRole(roleName);
        }

        //public static bool IsAdmin(string systemAdminRoleName = null)
        //{
        //    using (var ctx = new Unit())
        //    {
        //        return ctx..UserDisplay.GetByQuery(x => x.AspNetUsers.UserName.ToLower() == userName.ToLower().Trim() || x.LoginName == userName.ToLower().Trim() || x.LoginName == "coe\\" + userName.ToLower().Trim()).FirstOrDefault();

        //    }
        //}


        /// <summary>
        /// Register user.
        ///     For registering internal users, facility, and contact officer user
        /// </summary>
        /// <param name="newUser">
        /// The new user.
        /// </param>
        /// <param name="identityFile">
        /// The identity File.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static ReturnResult RegisterUser(
            ApplicationUser newUser,
            List<RoleName> roles)
        {
            // Method input validation
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            //if (roles == null)
            //{
            //    throw new ArgumentNullException(nameof(roles));
            //}

            //if (!roles.Any())
            //{
            //    throw new ArgumentNullException(nameof(roles));
            //}

            // Open Db Contexts and start tranaction over them
            // var appDbContext = HttpContext.Current.GetOwinContext().Get<UsersMgmtDbContext>();
            // using (var transaction = appDbContext.Database.BeginTransaction())

            using (
                var scope = new TransactionScope(
                    TransactionScopeOption.Suppress))
            using (var cxt = new Unit())
            {
                // Adding User
                try
                {
                    //ignor CreatedOn & UpdatedOn columns (because of these columns are system versionned)
                    // DbInterception.Add(new TemporalTableCommandTreeInterceptor());

                    // Register User using UsersMgmt library
                    var returnResult = UserManager.RegisterUser(newUser, roles);

                    // Register user in custom table UserDisplay in Security Scema If User Not A Student
                    #region Register user in custom table UserDisplay in Security Scema If User Not A Student
                    /*var returnUserDisplayResult = cxt.UserDisplay.Create(new Model.UserDisplay()
                    {
                        ID = Guid.NewGuid(),
                        AspNetUserID = newUser.Id,
                        LoginName = newUser.UserName,
                        DisplayName = newUser.FullName,
                        IsActive = true,
                        CreatedBy = newUser.UserName,
                        UpdatedBy = newUser.UserName
                    });

                    if (!returnUserDisplayResult.IsValid)
                    {
                        return returnUserDisplayResult;
                    }*/
                    #endregion

                    if (!returnResult.IsValid)
                    {
                        return returnResult;
                    }

                    //UserManager.SendValidateUserEmail(newUser);

                    // save DbContexts and commit transaction
                    cxt.Save(CurrentUserName ?? newUser.UserName);
                    scope.Complete();
                    return returnResult;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Get Current LogedIn User ActivationCode 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ActivationCode GetCurrentUserActivation(Guid userId, string userName)
        {
            return UserManager.GetCurrentUserActivation(userId, userName);
        }

        /// <summary>
        /// Delete Current User Activation Code
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ReturnResult DeleteCurrentUserActivationCode(Guid userId, string userName)
        {
            return UserManager.DeleteCurrentUserActivationCode(userId, userName);
        }

        /// <summary>
        /// The resend validate user email.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        public static ReturnResult ResendValidateUserEmail(Guid userId)
        {
            var returnResult = new ReturnResult();
            using (var cxt = new Unit())
            {
                var user = UserManager.FindById(userId);
                if (user == null)
                {
                    returnResult.ModelState.AddModelError(string.Empty, UsersMgmtResources.UserNotFound);
                    return returnResult;
                }

                UserManager.SendValidateUserEmail(user);
            }

            return returnResult;
        }

        /// <summary>
        /// The search users.
        /// </summary>
        /// <param name="usersSearchQuery">
        /// The users search query.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
        public static PagedList<ApplicationUser> SearchUsers(UsersSearchQuery usersSearchQuery)
        {
            return UserManager.SearchUsers(usersSearchQuery);
        }

        /// <summary>
        /// Get the role id by 
        /// </summary>
        /// <param name="roleName">the role name from AspNetRolesNames enumeration</param>
        /// <returns>the Id of role as Guid</returns>
        public static Guid GetRoleIdByRoleName(AspNetRolesNames roleName)
        {
            return UserManager.GetRoleByRoleCode((int)roleName).Id;
        }

        public static bool IsUserInRole(string userName, AspNetRolesNames roleName)
        {
            return UserManager.IsUserInRole(userName, roleName.ToString());
        }

        /// <summary>
        /// The update user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="identityFile">
        /// The identity file.
        /// </param>
        /// <param name="selectedRoles">
        /// The selected roles.
        /// </param>
        /// <returns>
        /// The <see cref="ReturnResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static ReturnResult UpdateUser(
            ApplicationUser user,
            HttpPostedFileBase identityFile = null,
            List<RoleName> selectedRoles = null)
        {
            // Method input validation
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using (
                var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    TransactionScopeAsyncFlowOption.Enabled))
            using (var cxt = new Unit())
            {
                //ignor CreatedOn & UpdatedOn columns (because of these columns are system versionned)
                DbInterception.Add(new TemporalTableCommandTreeInterceptor());

                // Adding User
                try
                {
                    // Register User using UsersMgmt library

                    var currentUserRoles = UserManager.GetUserRoles(user).Select(r => (RoleName)r.Code).ToList();

                    var returnResult = new ReturnResult();


                    returnResult = UserManager.UpdateUser(user, selectedRoles);
                    if (!returnResult.IsValid)
                    {
                        return returnResult;
                    }

                    // save DbContexts and commit transaction
                    cxt.Save();
                    scope.Complete();
                    return returnResult;
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }


    }
}
