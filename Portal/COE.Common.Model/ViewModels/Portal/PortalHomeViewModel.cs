using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class PortalHomeViewModel
    {
        public List<BulletinViewModel> Bulletins { get; set; }
        public List<AnnouncementViewModel> Announcements { get; set; }
        public List<HomePageModule> HomeIcons { get; set; }
        public HomePageModule AddModule { get; set; }
        public string Name { get; set; }

    }
}
