

namespace COE.Survey.Web.Filters
{
    using COE.Authorization;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class ModuleAuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        private string moduleCategoryName;

        private string moduleName;

        private string actionName;
        private bool isStudent;
        public bool IsStudent
        {
            get { return isStudent; }
            set { isStudent = value; }
        }

        public string ActionName
        {
            get
            {
                return this.actionName;
            }
            set
            {
                this.actionName = value;
            }
        }
        
        public string ModuleName
        {
            get
            {
                return this.moduleName;
            }
        }

        public string ModuleCategoryName
        {
            get
            {
                return this.moduleCategoryName;
            }
        }


        private AuthorizationManager authorizationManager;

        public ModuleAuthorizeAttribute(string moduleCategoryName, string moduleName)
        {
            this.moduleName = moduleName;
            this.moduleCategoryName = moduleCategoryName;
        }        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool authorized = false;

            string username = filterContext.HttpContext.User.Identity.Name;
                        
            if (!string.IsNullOrEmpty(this.moduleCategoryName))
            {
                if (!string.IsNullOrEmpty(this.moduleName))
                {
                    this.authorizationManager = new AuthorizationManager(DependencyResolver.Current.GetService<IAuthorizationDataStore>());

                    if (!string.IsNullOrEmpty(this.actionName))
                    {
                        authorized = this.authorizationManager.UserAuthorizedToAction(username, this.moduleCategoryName, this.moduleName, this.actionName);
                    }
                    else
                    {
                        authorized = this.authorizationManager.UserAuthorizedToModule(username, this.moduleCategoryName, this.moduleName);
                    }

                    //if (isStudent && !authorized)
                    //{
                        //authorized = LookupsHelper.IsStudent(username);
                    //}
                }
            }

            if (!authorized)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "UnAuthorized" }, { "Area", string.Empty } });
            }
        }
    }
}