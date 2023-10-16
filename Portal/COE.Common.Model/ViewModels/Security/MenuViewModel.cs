using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Localization.Security;

namespace COE.Common.Model.ViewModels
{
    public class MenuViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string ActionUrl { get; set; }
        public string Action
        {
            get
            {
                string[] _split = ActionUrl.Split('/').Where(x=>x!="" && x!=null).ToArray();

                return _split.Count() > 1 ? _split[1].ToString() : "Index";
            }
        }
        public string Controller
        {
            get
            {
                string[] _split = ActionUrl.Split('/').Where(x => x != "" && x != null).ToArray();

                return _split[0].ToString();
            }
        }

    }

}
