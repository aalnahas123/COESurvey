using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class SponserViewModel
    {
        public SponserViewModel()
        {
            Sponser = new Sponser();
            SponserContact = new SponserContactDetail();
            SponserRepresentive = new SponserRepresentiveDetail();
        }
        public Sponser Sponser { get; set; }
        public SponserContactDetail SponserContact { get; set; }
        public SponserRepresentiveDetail SponserRepresentive { get; set; }
    }
}   
