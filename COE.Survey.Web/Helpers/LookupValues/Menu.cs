using COE.Common.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace COE.Survey.Web.Helpers.LookupValues
{
    
    public class Menu 
    { 
        private List<MenuViewModel> lst; 
        public Menu() 
        {
            lst = new List<MenuViewModel>();
        } 
        public List<MenuViewModel> MenuItems 
        { 
            get 
            { 
                return GetMenuItems(); 
            }
        } 
        public List<MenuViewModel> GetMenuItems() 
        {
            if (lst.Count > 0) { lst.Clear(); } 
            lst.Add(new MenuViewModel { Name = "staff", Title = "Staff Managment", Icon = "fa-users" }); 
            lst.Add(new MenuViewModel { Name = "Users", Title = "Search Users", Icon = "fa-search" }); 
            lst.Add(new MenuViewModel { Name = "Add", Title = "Create User", Icon = "fa-user-plus" }); 
            lst.Add(new MenuViewModel { Name = "ViewUserRoles", Title = "Role Permissions", Icon = "fa-key" }); 
            lst.Add(new MenuViewModel { Name = "PowerRole", Title = "Power Roles", Icon = "fa-object-group" }); 
            lst.Add(new MenuViewModel { Name = "Role", Title = "Roles", Icon = "fa-object-group" }); 
            lst.Add(new MenuViewModel { Name = "ModuleCategory", Title = "Module Category", Icon = "fa-sitemap" }); 
            lst.Add(new MenuViewModel { Name = "Module", Title = "Module", Icon = "fa-cubes" }); 
            lst.Add(new MenuViewModel { Name = "Action", Title = "Actions", Icon = "fa-flash" }); 
            lst.Add(new MenuViewModel { Name = "ModuleAction", Title = "Module Action", Icon = "fa-folder-open" }); 
            return lst; 
        } 
    }

    
}