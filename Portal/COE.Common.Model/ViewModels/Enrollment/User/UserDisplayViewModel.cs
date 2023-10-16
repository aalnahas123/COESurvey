using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class UserDisplayViewModel: UserDisplay
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsActiveDirectory { get; set; }
        public string Mobile { get; set; }

        public int? ProgramStatusId { get; set; }
        public Guid UserdisplayId { get; set; }
        public string NationalId { get; set; }
    }
}
