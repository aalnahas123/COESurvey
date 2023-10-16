using COE.Common.Model.ViewModels;
using System.Web.Mvc;
using COE.Common.Helper;
using COE.Survey.BLL;
using COE.Common.Model;
using System;
using System.Linq;
using COE.Common.Localization.Security;
using UsersMgmt.ActiveDirectory;
using System.Collections.Generic;
using Commons.Framework.Globalization;
using Commons.Framework.Data;
using PagedList;
using COE.Survey.Web.Helpers;
using COE.Survey.Web.Filters;

namespace COE.Survey.Web.Controllers
{
    [Authorize]
    public class SecurityController : BaseController<COEUoW>
    {
        private Helpers.LookupValues.Menu _menu = new Helpers.LookupValues.Menu();

        public ActionResult Index(int? success)
        {

            Session["Menu"] = null;
            var moduleActions = this.AuthManager.GetModuleActions(UserName, "Security", "Menu");
            var menu = _menu.MenuItems;
            menu = menu.Where(w => moduleActions.Select(s => s.Name).Contains(w.Name)).ToList();
            foreach (var item in menu)
            {
                foreach (var ma in moduleActions)
                {
                    if (item.Name == ma.Name)
                    {
                        item.ActionUrl = ma.ActionUrl;
                    }
                }

            }
            Session["Menu"] = menu.Where(w => moduleActions.Select(s => s.Name).Contains(w.Name)).ToList();
            if (menu.Count > 0)
            {
                return RedirectToAction(menu.FirstOrDefault().Action, menu.FirstOrDefault().Controller);
            }
            else
            {
                return View();
            }
            //this.LoadAuthorizationModuleActions("Security", "Menu");

            //var UserRoles = LookupsHelpers.GetCurrentUserRoles(User.Identity.Name);
            //Session["UserRoles"] = UserRoles;

            //if (UserRoles != null && UserRoles.Contains(Guid.Parse(Model.LookupValues.AspNetRoles.Values.SystemAdmin)))
            //{
            //    return RedirectToAction("Users", "Security");
            //}
            //else if (UserRoles != null && UserRoles.Contains(Guid.Parse(Model.LookupValues.AspNetRoles.Values.SuperCollegeAdmin)))
            //{
            //    return RedirectToAction("Index", "Staff");
            //}
            //return View();
        }

        [HttpGet]
        public ActionResult GetColleges()
        {
            return View();
        }

        [ModuleAuthorize("Security", "User", ActionName = "Search")]
        public ActionResult Users(AspNetUsersSearchModel model)
        {
            this.LoadAuthorizationModuleActions("Security", "User");
            if (Session["Message"] != null)
            {
                Header.ShowSuccess(Session["Message"].ToString(), true);
                Session["Message"] = null;
            }

            if (Request.HttpMethod == "POST")
            {
                if (RouteData.Values["id"] != null)
                {
                    return RedirectToAction("users", "security", new { id = string.Empty });
                }
            }

            if (model.UserType == null)
            {
                model.UserType = ((int)Common.Model.Enums.Enum.UserType.Online).ToString();
            }

            if (Request.QueryString["UserType"] != null)
            {
                if (Request.QueryString["UserType"].ToString() == ((int)COE.Common.Model.Enums.Enum.UserType.Online).ToString())
                {
                    model.UserType = ((int)Common.Model.Enums.Enum.UserType.Online).ToString();
                }
                else
                {
                    model.UserType = ((int)Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString();
                }
            }

            var CurrentUserColleges = UnitOfWork.College.GetListByUserId(User.Identity.Name).Select(X => X.Value).ToList();
            var allowedRoles = UnitOfWork.AspNetRoles.GetAllowedRoleForUser(User.Identity.Name);
            var isAdmin = LookupsHelper.GetCurrentUserRoles(User.Identity.Name).Contains(Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));

            //search in AD or ASPNetUsers 
            if (model.UserType == ((int)Common.Model.Enums.Enum.UserType.ActiveDirectory).ToString())
            {
                //AD User
                ViewBag.DisplayAD = "display:block";
                ViewBag.DisplayOnline = "display:none";


                var users = UnitOfWork.UserDisplay.GetAll();
                if (!isAdmin)
                {
                    users = users.Where(x => x.AspNetUsers == null
                             && (x.UserCollege.Any(uc => CurrentUserColleges.Contains(uc.College.ID)))
                             && (x.AspNetRoles.Any(ar => allowedRoles.Contains(ar.Id)))
                             //allowedRoles.Contains(x.AspNetRoles.OrderBy(o => o.Priority).FirstOrDefault().Id)
                             );
                }
                else
                {
                    users = users.Where(x => x.AspNetUsers == null);
                    // && (x.UserCollege.Any(uc => CurrentUserColleges.Contains(uc.College.ID))));
                }

                if (Request.QueryString["uid"] != null)
                {
                    Guid uid = new Guid(Request.QueryString["uid"].ToString());
                    users = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == uid);
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

                if (users != null)
                {
                    //Add The Result To Unified Users List [ID-Name]
                    var AllUsers = users.Select(cc => new AllUsersModel
                    {
                        Id = cc.ID,
                        DisplayId = cc.ID,
                        UserName = cc.LoginName,
                        FullName = cc.DisplayName,
                        Colleges = cc.UserCollege.Count(),
                        QualificationsCount = cc.UserSpecialization.Count(),
                        Type = (int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory,
                        IsActive = cc.IsActive,
                        CreatedBy = cc.CreatedBy
                    });

                    var results = AllUsers.GetPaged(
                         o => o.Id,
                         true,
                         model.PageNumber,
                        BLL.AppSettings.DefaultPagerPageSize);

                    model.AllUsers = new StaticPagedList<AllUsersModel>(results, model.PageNumber, results.PageSize, results.TotalItemCount);
                }
            }
            else
            {
                //online user
                ViewBag.DisplayAD = "display:none";
                ViewBag.DisplayOnline = "display:block";


                if (Request.QueryString["uid"] != null)
                {
                    Guid gUserId = new Guid(Request.QueryString["uid"].ToString());

                    //get asp users 
                    var singleUser = UnitOfWork.UserDisplay.GetByQuery(x => x.ID == gUserId);
                    if (singleUser != null)
                    {
                        if (singleUser.Select(x => x.AspNetUsers).Count() > 0)
                        {
                            var AllUsers = singleUser.Select(cc => new AllUsersModel
                            {
                                Id = cc.AspNetUsers.Id,
                                DisplayId = cc.ID,
                                FullName = cc.AspNetUsers.FullName,
                                UserName = cc.AspNetUsers.UserName,
                                Email = cc.AspNetUsers.Email,
                                Colleges = cc.UserCollege.Count(),
                                QualificationsCount = cc.UserSpecialization.Count(),
                                IsActive = cc.IsActive,
                                Type = (int)COE.Common.Model.Enums.Enum.UserType.Online,
                                CreatedBy = cc.CreatedBy
                            });
                            var results = AllUsers.GetPaged(
                                                                  o => o.Id,
                                                                  true,
                                                                  model.PageNumber,
                                                                 BLL.AppSettings.DefaultPagerPageSize);

                            model.AllUsers = new StaticPagedList<AllUsersModel>(results, model.PageNumber, results.PageSize, results.TotalItemCount);
                        }
                        else
                        {
                            var AllUsers = singleUser.Select(cc => new AllUsersModel
                            {
                                Id = cc.ID,
                                DisplayId = cc.ID,
                                UserName = cc.AspNetUsers.UserName,
                                Colleges = cc.UserCollege.Count(),
                                QualificationsCount = cc.UserSpecialization.Count(),
                                Type = (int)COE.Common.Model.Enums.Enum.UserType.ActiveDirectory,
                                IsActive = cc.IsActive,
                            });
                            var results = AllUsers.GetPaged(
                                                            o => o.Id,
                                                            true,
                                                            model.PageNumber,
                                                            BLL.AppSettings.DefaultPagerPageSize);

                            model.AllUsers = new StaticPagedList<AllUsersModel>(results, model.PageNumber, results.PageSize, results.TotalItemCount);

                        }
                        return View(model);
                    }
                }

                //get users with roles <= current user rol 
                //get users with current user colleges
                var query = UnitOfWork.UserDisplay.GetAll();
                if (!isAdmin)
                {
                    query = query.Where(x => x.AspNetUsers != null
                             && (x.UserCollege.Any(uc => CurrentUserColleges.Contains(uc.College.ID)))
                             && (x.AspNetRoles.Any(ar => allowedRoles.Contains(ar.Id)) || x.AspNetRoles.Count <= 0)
                             //allowedRoles.Contains(x.AspNetRoles.OrderBy(o => o.Priority).FirstOrDefault().Id)
                             );
                }
                else
                {
                    query = query.Where(x => x.AspNetUsers != null
                             && ((x.UserCollege.Any(uc => CurrentUserColleges.Contains(uc.College.ID))) || (x.UserCollege.Count <= 0)));
                }

                if (model.RoleId != null)
                {
                    query = query.Where(x => x.AspNetRoles.Select(o => o.Id).ToList().Contains(model.RoleId.Value));
                }
                if (model.CollegeId != null)
                {
                    query = query.Where(x => x.UserCollege.Select(c => c.CollegeID).ToList().Contains(model.CollegeId.Value));
                }
                if (!string.IsNullOrEmpty(model.UserNameOnline))
                {
                    query = query.Where(a => a.AspNetUsers.UserName.Trim().ToLower().Contains(model.UserNameOnline.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }

                if (!string.IsNullOrEmpty(model.Email))
                {
                    query = query.Where(a => a.AspNetUsers.Email.ToLower().Contains(model.Email.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    query = query.Where(a => a.AspNetUsers.PhoneNumber.Contains(model.Phone.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }
                if (!string.IsNullOrEmpty(model.NationalId))
                {
                    query = query.Where(a => a.AspNetUsers.NationalId.Contains(model.NationalId.ToLower().Trim())).OrderBy(x => x.AspNetUsers.Id);
                }

                //var users = UnitOfWork.AspNetUsers.GetByQuery(x => x.Email == model.Email.Trim() || x.NationalId == model.NationaId.Trim() || x.FullName.ToLower().Contains(model.UserName.Trim()) || x.PhoneNumber == model.Phone.Trim());
                if (query != null)
                {
                    var AllUsers = query.Select(cc => new AllUsersModel
                    {
                        Id = cc.AspNetUsers.Id,
                        DisplayId = cc.ID,
                        FullName = cc.AspNetUsers.FullName,
                        UserName = cc.AspNetUsers.UserName,
                        Email = cc.AspNetUsers.Email,
                        Colleges = cc.UserCollege.Count(),
                        QualificationsCount = cc.UserSpecialization.Count(),
                        Type = (int)COE.Common.Model.Enums.Enum.UserType.Online,
                        IsActive = cc.IsActive,
                        NationalId = cc.AspNetUsers.NationalId,
                        CreatedBy = cc.CreatedBy
                    });



                    var results = AllUsers.GetPaged(
                          o => o.Id,
                          true,
                          model.PageNumber,
                         BLL.AppSettings.DefaultPagerPageSize);

                    model.AllUsers = new StaticPagedList<AllUsersModel>(results, model.PageNumber, results.PageSize, results.TotalItemCount);

                }

            }
            return View(model);
        }

        [ModuleAuthorize("Security", "User", ActionName = "UserCollege")]
        public ActionResult AddCollege(Guid? id, int? type)
        {
            if (id == null)
            {
                return RedirectToAction("users");
            }

            if (Session["Message"] != null)
            {
                Header.ShowSuccess(Session["Message"].ToString(), true);
                Session["Message"] = null;
            }
            if (Session["MessageError"] != null)
            {
                Header.ShowError(Session["MessageError"].ToString(), true);
                Session["MessageError"] = null;
            }
            var isAdmin = LookupsHelper.GetCurrentUserRoles(User.Identity.Name).Contains(Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));

            var CurrentUserColleges = isAdmin ? UnitOfWork.College.GetByQuery(c => true).Select(X => X.ID).ToList()
                                        : UnitOfWork.College.GetListByUser(User.Identity.Name).Select(X => X.ID).ToList();
            TempData["type"] = type;

            //Get All Providers With Colleges
            var providers = UnitOfWork.Provider.GetProvidersWithColleges(CurrentUserColleges);

            var collegesAssignedToCurrentUser = UnitOfWork.UserCollege.GetByQuery(u => u.UserDisplayID == id).Select(x => x.College.ID).ToList();
            foreach (var provider in providers)
            {
                foreach (var college in provider.CollegeList)
                {
                    foreach (var userCollegeID in collegesAssignedToCurrentUser)
                    {
                        if (userCollegeID == college.ID)
                        {
                            college.IsSelected = true;
                            provider.IsSelected = true;
                        }
                    }
                }
            }

            return View(providers);
        }

        [HttpPost]
        public ActionResult AddCollege(Guid? id, List<Provider> model)
        {

            string userId = id.Value.ToString();

            //Get Checked Colleges And Add To User Colleges Table
            if (model != null)
            {
                //get selected colleages from model
                var selectedColleges = model.Where(x => x.IsSelected).SelectMany(y => y.CollegeList.Where(z => z.IsSelected == true)).ToList();

                List<UserCollege> obj = new List<UserCollege>();

                if (selectedColleges.Count() > 0)
                {

                    //Delete All User Colleges
                    var userColleges = UnitOfWork.UserCollege.GetByQuery(x => x.UserDisplayID == new Guid(userId)).ToList();
                    UnitOfWork.UserCollege.Delete(userColleges);

                    //Save
                    UnitOfWork.Save();

                    foreach (var item in selectedColleges)
                    {
                        UnitOfWork.UserCollege.Add(new UserCollege
                        {
                            CollegeID = item.ID,
                            UserDisplayID = new Guid(userId),
                            CreatedBy = UserName,
                            UpdatedBy = UserName,
                            IsActive = true
                        });
                    }
                    try
                    {
                        //Save
                        UnitOfWork.Save();
                        Session["Message"] = SecurityResources.CollegeSavedSuccessMessage;
                        return RedirectToAction("addCollege", "Security", new { @type = TempData.Peek("type").ToString() });
                    }
                    catch (Exception ex)
                    {
                        Session["MessageError"] = Common.Localization.SharedResources.UnexpectedError;
                        return RedirectToAction("addCollege", "Security", new { @type = TempData.Peek("type").ToString() });
                    }
                }
                else
                {
                    Session["Message"] = "Please Select College";
                    return RedirectToAction("addCollege", "Security", new { @type = TempData.Peek("type").ToString() });
                }
            }
            return View(model);
        }

        [ModuleAuthorize("Security", "User", ActionName = "UserCollege")]
        public ActionResult AddQualification(Guid? id, int? type)
        {
            if (id == null)
            {
                return RedirectToAction("users");
            }

            if (Session["Message"] != null)
            {
                Header.ShowSuccess(Session["Message"].ToString(), true);
                Session["Message"] = null;
            }
            if (Session["MessageError"] != null)
            {
                Header.ShowError(Session["MessageError"].ToString(), true);
                Session["MessageError"] = null;
            }
            //var isAdmin = LookupsHelpers.GetCurrentUserRoles(User.Identity.Name).Contains(Guid.Parse(COE.Security.Model.LookupValues.AspNetRoles.Values.SystemAdmin));

            //var CurrentUserSpecialization = isAdmin ? UnitOfWork.Specialization.GetByQuery(c => true).Select(X => X.ID).ToList()
            //                            : UnitOfWork.Specialization.GetListByUser(User.Identity.Name).Select(X => X.ID).ToList();

            var isAdmin = LookupsHelper.GetCurrentUserRoles(User.Identity.Name).Contains(Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));

            var currentLogedInUserColleges = isAdmin ? UnitOfWork.College.GetByQuery(c => true).Select(X => X.ID).ToList()
                                        : UnitOfWork.College.GetListByUser(User.Identity.Name).Select(X => X.ID).ToList();

            //var CurrentUserSpecialization = UnitOfWork.Specialization.GetListByUser(id.Value).Select(X => X.ID).ToList();

            TempData["type"] = type;

            //Get All Colleges With Specializations
            var colleges = UnitOfWork.College.GetCollegesWithSpecializationsByUserID(id.Value, currentLogedInUserColleges);

            var specializationAssignedToCurrentUser = UnitOfWork.UserSpecialization.GetByQuery(u => u.UserDisplayID == id).Select(x => x.SpecializationID).ToList();
            foreach (var college in colleges)
            {
                foreach (var collegeSpecialization in college.SpecializationsList)
                {
                    foreach (var userspecializationID in specializationAssignedToCurrentUser)
                    {
                        if (userspecializationID == collegeSpecialization.ID)
                        {
                            collegeSpecialization.IsSelected = true;
                            college.IsSelected = true;
                        }
                    }
                }
            }

            return View(colleges);
        }

        [HttpPost]
        public ActionResult AddQualification(Guid? id, List<College> model)
        {

            string userId = id.Value.ToString();

            //Get Checked Specializations And Add To User Specializations Table
            if (model != null)
            {
                //get selected Specializations from model
                var selectedSpecializations = model.Where(x => x.IsSelected).SelectMany(y => y.SpecializationsList.Where(z => z.IsSelected == true)).ToList();

                List<UserSpecialization> obj = new List<UserSpecialization>();

                //if (selectedSpecializations.Count() > 0)
                {

                    //Delete All User Specializations
                    var userSpecializations = UnitOfWork.UserSpecialization.GetByQuery(x => x.UserDisplayID == new Guid(userId)).ToList();
                    UnitOfWork.UserSpecialization.Delete(userSpecializations);

                    //Save
                    UnitOfWork.Save();

                    foreach (var item in selectedSpecializations)
                    {
                        UnitOfWork.UserSpecialization.Add(new UserSpecialization
                        {
                            SpecializationID = item.ID,
                            UserDisplayID = new Guid(userId),
                            CreatedBy = UserName,
                            UpdatedBy = UserName,
                            IsActive = true
                        });
                    }
                    try
                    {
                        //Save
                        UnitOfWork.Save();
                        Session["Message"] = SecurityResources.QualificationSavedSuccessMessage;
                        return RedirectToAction("AddQualification", "Security", new { @type = TempData.Peek("type").ToString() });
                    }
                    catch (Exception ex)
                    {
                        Session["MessageError"] = Common.Localization.SharedResources.UnexpectedError;
                        return RedirectToAction("AddQualification", "Security", new { @type = TempData.Peek("type").ToString() });
                    }
                }
                //else
                //{
                //    Session["Message"] = "Please Select Qualification";
                //    return RedirectToAction("AddQualification", "Security", new { @type = TempData.Peek("type").ToString() });
                //}
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult UserRole(Guid? id, List<AspNetRoles> model)
        {
            Guid uid = id.Value;
            string type = TempData.Peek("type").ToString();

            //get all selected Roles
            var selectedRoles = model.Where(x => x.IsSelected == true).ToList();
            var selectedUser = UnitOfWork.UserDisplay.GetById(uid);

            //delete all user roles
            var userRole = UnitOfWork.UserDisplay.GetById(uid).AspNetRoles.ToList();
            if (userRole.Count > 0)
            {
                foreach (var item in userRole)
                {
                    selectedUser.AspNetRoles.Remove(item);
                }
                //commit delete
                UnitOfWork.Save();
            }

            using (var ctx = new Common.DAL.COEEntities())
            {
                var user = ctx.UserDisplay.FirstOrDefault(x => x.ID == uid);

                foreach (var item in selectedRoles)
                {
                    var role = ctx.AspNetRoles.Find(item.Id);
                    role.CreatedBy = UserName;
                    role.UpdatedBy = UserName;
                    role.UpdatedOn = DateTime.Now;
                    role.UserDisplay.Add(user);
                }

                try
                {
                    ctx.SaveChanges();
                    TempData["SuccessMessage"] = SecurityResources.RoleSavedSuccessMessage;
                    return RedirectToAction("UserRole", "Security", new { @type = type });
                }
                catch (Exception)
                {
                    TempData["SuccessMessage"] = SecurityResources.ErrorOccured;
                    return RedirectToAction("UserRole", "Security", new { @type = type });
                }
            }

        }

        [ModuleAuthorize("Security", "User", ActionName = "UserRole")]
        public ActionResult UserRole(Guid? id, int? type)
        {
            if (id == null)
            {
                return RedirectToAction("users");
            }

            TempData["type"] = type;

            // Get All Roles

            var allowedRoles = UnitOfWork.AspNetRoles.GetAllowedRoleForUser(User.Identity.Name, Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));
            var data = UnitOfWork.AspNetRoles.GetByQuery(q => allowedRoles.Contains(q.Id)).ToList();

            //get user roles
            var userRole = UnitOfWork.UserDisplay.GetById(id).AspNetRoles.ToList();
            var currentUserRoleIds = userRole.Select(x => x.Id);

            foreach (var item in data)
            {
                foreach (var userId in currentUserRoleIds)
                {
                    if (item.Id == userId)
                    {
                        item.IsSelected = true;
                    }
                }
            }
            return View(data.OrderBy(o => o.Priority.Value).ToList());
        }

        [HttpGet]
        public ActionResult RoleAction(Guid? id)
        {
            TempData.Keep();
            TempData["roleId"] = id;
            //get role of current user
            var currentRole = LookupsHelper.GetCurrentUserRoles(User.Identity.Name);

            var currentRoleActions = UnitOfWork.RolePermission.GetByQuery(x => x.RoleID == id).Select(x => x.ModuleAction).ToList();

            var allRoleActions = UnitOfWork.RolePermission.GetByQuery(x => x.RoleID == currentRole.FirstOrDefault()).Select(x => x.ModuleAction).ToList();
            var moduleIds = allRoleActions.Select(s => s.Module.ID).ToList();
            var ids = allRoleActions.Select(cr => cr.ID).ToList();
            var moduleCategories = UnitOfWork.ModuleAction.GetByQuery(qq => ids.Contains(qq.ID) && qq.Module.ModuleAction.Count > 0)
                .Select(s => s.Module.ModuleCategory)
                .Where(w => w.Module.Count > 0).Distinct().ToList();
            foreach (var mcategory in moduleCategories)
            {
                foreach (var module in mcategory.Module)
                {
                    if (moduleIds.Contains(module.ID))
                    {
                        if (module.ModuleAction.Count > 0)
                        {
                            mcategory.ModuleList.Add(module);

                            foreach (var maction in module.ModuleAction)
                            {
                                if (ids.Contains(maction.ID))
                                {
                                    module.ModuleActionList.Add(maction);
                                }
                            }
                        }
                    }
                }
            }

            //var moduleCategories = UnitOfWork.ModuleCategory.GetByQuery(q => q.Module.Count > 0).ToList().Select(x => new ModuleCategory
            //{
            //    ID = x.ID,
            //    Name = x.Name,
            //    ModuleList = x.Module.Where(w => w.ModuleAction.Count > 0).Select(y => new Module
            //    {
            //        ID = y.ID,
            //        Name = y.Name,
            //        ModuleActionList = y.ModuleAction.Where(w => w.RolePermission.Any(a => a.RoleID == id)).ToList()
            //    }).ToList()
            //}).ToList();

            foreach (var currentAction in currentRoleActions)
            {
                foreach (var category in moduleCategories)
                {
                    foreach (var module in category.ModuleList)
                    {
                        foreach (var action in module.ModuleActionList)
                        {
                            if (currentAction.ID == action.ID)
                            {
                                action.IsSelected = true;
                                module.IsSelected = true;
                                category.IsSelected = true;
                            }
                        }
                    }
                }
            }

            return View(moduleCategories);
        }
        [HttpPost]
        public ActionResult RoleAction(List<ModuleCategory> model)
        {
            Guid roleId = new Guid(TempData["roleId"].ToString());

            List<RolePermission> rolePermissions = new List<RolePermission>();
            var selectedModuleActions = model.Where(x => x.IsSelected == true).SelectMany(z => z.ModuleList).ToList().SelectMany(y => y.ModuleActionList).Where(w => w.IsSelected == true).ToList();

            var currentpermissions = UnitOfWork.RolePermission.GetByQuery(x => x.RoleID == roleId).ToList();


            foreach (var item in selectedModuleActions)
            {
                rolePermissions.Add(new RolePermission { ModuleActionID = item.ID, RoleID = roleId, IsActive = true, CreatedBy = UserName, UpdatedBy = UserName, UpdatedOn = DateTime.Now });
            }
            if (currentpermissions.Count > 0)
            {
                //delete RolePermission data by role id
                UnitOfWork.RolePermission.Delete(currentpermissions);
                UnitOfWork.Save();
            }

            UnitOfWork.RolePermission.Add(rolePermissions);
            int success = UnitOfWork.Save();

            if (success > 0)
            {
                success = (int)COE.Common.Model.Enums.Enum.RowStaus.Success;
            }
            return RedirectToAction("ViewUserRoles", new { success = success });
        }

        [HttpPost]
        public JsonResult CheckUserExist(string userName, string userId, int userType, string email, string controller, string action)
        {
            //Check if USer Exist
            UserDisplay user = new UserDisplay();
            if (userType == (int)COE.Common.Model.Enums.Enum.UserType.Online)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    user = UnitOfWork.UserDisplay.GetByQuery(x => x.AspNetUserID == new Guid(userId) && x.IsActive == true).FirstOrDefault();
                }

                if (user == null)
                {

                    Guid AspUser = new Guid(userId);
                    user = UnitOfWork.UserDisplay.Add(new UserDisplay

                    { LoginName = userName, DisplayName = userName, ID = Guid.NewGuid(), AspNetUserID = AspUser, CreatedBy = userName, UpdatedOn = DateTime.Now, UpdatedBy = userName, IsActive = true });


                    UnitOfWork.Save();
                }
            }
            else
            {
                Guid AdUserID = new Guid(userId);
                user.ID = AdUserID;
            }
            if (user.ID != null)
            {
                TempData["uid"] = user.ID;
            }
            return Json(new { success = "Success", Result = Url.Action(action, controller, new { id = user.ID, type = userType }), ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetModuleActions(int CategoryId)
        {
            //Get Modules And Module Actions
            var modules = UnitOfWork.Module.GetByQuery(x => x.ModuleCategoryID == CategoryId).ToList().Select(x => new Module
            {
                ID = x.ID,
                Name = x.Name,
                ModuleAction = x.ModuleAction.Select(y => new ModuleAction
                {
                    ID = y.ID,
                    Name = y.Name,
                    ModuleID = y.ModuleID
                }).ToList()
            }).ToList();
            return Json(new { success = "Success", Result = modules, ErrorMessage = string.Empty }, JsonRequestBehavior.AllowGet);
        }

        [ModuleAuthorize("Security", "RoleAction", ActionName = "Search")]
        [HttpGet]
        public ActionResult ViewUserRoles(Guid? id, int? success)
        {
            this.LoadAuthorizationModuleActions("Security", "RoleAction");
            string successMessage = string.Empty;
            switch (success)
            {
                case (int)Common.Model.Enums.Enum.RowStaus.Success:
                    successMessage = SecurityResources.RoleActionsSavedSuccessMessage;
                    break;

                default:
                    break;
            }
            ViewBag.SuccessMessage = successMessage;

            List<AspNetRoles> roles = new List<AspNetRoles>();

            if (success != null)
            {
                ViewBag.Success = (int)COE.Common.Model.Enums.Enum.RowStaus.Success;
            }
            if (id != null)
            {
                roles = UnitOfWork.UserDisplay.GetById(id).AspNetRoles.ToList();
            }
            else
            {
                var allowedRoles = UnitOfWork.AspNetRoles.GetAllowedRoleForUser(User.Identity.Name, Guid.Parse(Helpers.LookupValues.AspNetRoles.Values.SystemAdmin));

                roles = UnitOfWork.AspNetRoles.GetByQuery(q => allowedRoles.Contains(q.Id)).OrderBy(x => x.Priority).ToList();
            }
            return View(roles);
        }

        [HttpPost]
        public JsonResult ActiveRole(Guid? id, bool? activeValue)
        {
            try
            {
                var role = UnitOfWork.AspNetRoles.GetById(id);
                role.IsActive = activeValue.Value;
                UnitOfWork.AspNetRoles.Update(role);
                UnitOfWork.Save();

                return Json(new
                {
                    success = true,
                    Result = activeValue.Value ? Common.Model.Enums.Enum.SaveStaus.ItemActivated : Common.Model.Enums.Enum.SaveStaus.ItemDeactivated,
                    ResultMessage = activeValue.Value ? SecurityResources.ItemActivatedSuccessMessage : SecurityResources.ItemDeactivatedSuccessMessage,
                    ErrorMessage = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    Result = Common.Model.Enums.Enum.SaveStaus.ItemError,
                    ErrorMessage = SecurityResources.ErrorOccured
                }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult ActiveDeActiveUser(bool stateParam, Guid? userId)
        {
            try
            {
                //AD Users
                var aspUser = UnitOfWork.AspNetUsers.GetById(userId);
                if (aspUser == null)
                {

                    var userdisplay = UnitOfWork.UserDisplay.GetById(userId);
                    userdisplay.IsActive = stateParam;
                    UnitOfWork.UserDisplay.Update(userdisplay);
                    UnitOfWork.Save();
                    return Json(new
                    {
                        success = true,
                        Result = "",
                        ResultMessage = "",
                        ErrorMessage = string.Empty
                    }, JsonRequestBehavior.AllowGet);
                }

                //Online Users
                else
                {

                    var onlineUser = UnitOfWork.AspNetUsers.GetById(userId);
                    onlineUser.IsActive = stateParam;
                    onlineUser.UserDisplay.FirstOrDefault().IsActive = stateParam;
                    UnitOfWork.AspNetUsers.Update(onlineUser);
                    UnitOfWork.Save();

                    return Json(new
                    {
                        success = true,
                        Result = "",
                        ResultMessage = "",
                        ErrorMessage = string.Empty
                    }, JsonRequestBehavior.AllowGet);


                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    Result = Common.Model.Enums.Enum.SaveStaus.ItemError,
                    ErrorMessage = SecurityResources.ErrorOccured
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [ModuleAuthorize("Security", "User", ActionName = "Details")]
        [HttpGet]
        public ActionResult UserDetails(Guid? id)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Roles = UnitOfWork.UserDisplay.GetById(id).AspNetRoles.ToList();
            userDetails.Colleges = UnitOfWork.UserCollege.
                GetByQuery(u => u.UserDisplayID == id).
                Select(x => new { x.College.ID, x.College.Name }).
                AsEnumerable().Select(c => new College
                {
                    ID = c.ID,
                    Name = c.Name
                }).ToList();
            userDetails.Qualifications =
                UnitOfWork.UserSpecialization.GetByQuery(us => us.UserDisplayID == id).
                Select(us => new { us.Specialization.Name }).AsEnumerable().
                Select(s => new Specialization { Name = s.Name }).ToList();
            userDetails.User = UnitOfWork.UserDisplay.GetById(id);
            userDetails.UserId = id.Value;
            ViewBag.UserDisplayForCurrentUser = UnitOfWork.UserDisplay.GetByQuery(x => x.LoginName == User.Identity.Name).Select(s => s.ID).FirstOrDefault();
            return View(userDetails);
        }
    }
}