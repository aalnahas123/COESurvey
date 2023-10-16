using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;
using PagedList;
using COE.Common.Localization;

namespace COE.Common.Model.ViewModels
{
    public class AspNetUsersSearchModel
    {
        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        //public string UserName { get; set; }
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName != null ? _userName.Trim() : "";
            }
            set
            {
                _userName = value;
            }
        }


        [Display(Name = "UserName", ResourceType = typeof(SecurityResources))]
        public string UserNameOnline { get; set; }

        [Display(Name = "UserType", ResourceType = typeof(SecurityResources))]
        public string UserType { get; set; }

        [Display(Name = "Email", ResourceType = typeof(SecurityResources))]
        private string _email;
        public string Email
        {
            get
            {
                return _email != null ? _email.Trim() : "";
            }
            set
            {
                _email = value;
            }
        }
        [Display(Name = "Phone", ResourceType = typeof(SecurityResources))]
        public string Phone { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(SecurityResources))]
        public string NationalId { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(SecurityResources))]
        public Guid? RoleId { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(SecurityResources))]
        public Guid? ADRoleId { get; set; }

        [Display(Name = "College", ResourceType = typeof(SecurityResources))]
        public int? CollegeId { get; set; }

        [Display(Name = "College", ResourceType = typeof(SecurityResources))]
        public int? ADCollegeId { get; set; }



        public List<AllUsersModel> AllUsersList { get; set; }

        public StaticPagedList<AllUsersModel> AllUsers { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }

    public class UserType
    {
        [Display(Name = "ActiveDirectoryUser", ResourceType = typeof(SecurityResources))]
        public int ActiveDirectoryUser { get; set; }

        [Display(Name = "OnlineUser", ResourceType = typeof(SecurityResources))]
        public int OnlineUser { get; set; }
    }
}
