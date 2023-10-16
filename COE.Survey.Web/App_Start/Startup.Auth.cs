// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.Auth.cs" company="SURE International Technology">
//   Copyright © 2016 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using UsersMgmt;

namespace COE.Survey.Web
{
   

    using UsersMgmt.Model;

    /// <summary>
    ///     The startup.
    /// </summary>
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
        /// <summary>
        /// The configure auth.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(UsersMgmtDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            // app.UseCookieAuthentication(
            // new CookieAuthenticationOptions
            // {
            // AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, 
            // LoginPath = new PathString("/Login"), 
            // CookieName = ".ASPXFORMSAUTH", 
            // Provider =
            // new CookieAuthenticationProvider
            // {
            // OnValidateIdentity =
            // SecurityStampValidator
            // .OnValidateIdentity<ApplicationUserManager,ApplicationUser,Guid>(
            // TimeSpan.FromMinutes(
            // 30), 
            // (manager, user) =>
            // user
            // .GenerateUserIdentityAsync
            // (manager))
            // }
            // });
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    CookieName = "SCTH.Auth",
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider =
                            new CookieAuthenticationProvider
                            {
                                // Enables the application to validate the security stamp when the user logs in.
                                // This is a security feature which is used when you change a password or add an external login to your account.  
                                OnValidateIdentity =
                                        SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, Guid>
                                        (
                                            TimeSpan.FromMinutes(30),
                                            (manager, user) => user.GenerateUserIdentityAsync(manager),
                                            id => Guid.Parse(id.GetUserId()))
                            }
                });

            // app.UseCookieAuthentication(new CookieAuthenticationOptions
            // {
            // AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            // LoginPath = new PathString("/Account/Search")
            // });

            // PathString path = new PathString("/Account/Login");
            // if (GlobalExtensions.WindowsAuthActive)
            // path = new PathString("/Windows/Login");

            // app.UseCookieAuthentication(new CookieAuthenticationOptions
            // {
            // AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            // //LoginPath = new PathString("/Account/Login")
            // LoginPath = new PathString("/Account/Search") 
            // });
            // Use a 
            // ==
            // app.UseCookieAuthentication(new CookieAuthenticationOptions
            // {
            // AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            // LoginPath = new PathString("/Account/Login")
            // });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            //var facebookOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = AppSettings.FacebookAppId,
            //    AppSecret = AppSettings.FacebookAppSecret,
            //    //BackchannelHttpHandler = new FacebookBackChannelHandler(),
            //    UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,email,first_name,last_name"
            //};

            //facebookOptions.Scope.Add("email");
            //facebookOptions.Scope.Add("first_name");
            //facebookOptions.Scope.Add("last_name");

            //app.UseFacebookAuthentication(facebookOptions);


            //app.UseTwitterAuthentication(consumerKey: AppSettings.TwitterAppId, consumerSecret: AppSettings.TwitterAppSecret);
        }
    }
}