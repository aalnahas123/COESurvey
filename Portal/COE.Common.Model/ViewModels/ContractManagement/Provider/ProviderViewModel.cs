using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COE.Common.Model;

namespace COE.Common.Model.ViewModels.ContractManagement
{
    public class ProviderViewModel 
    {
        public ProviderViewModel()
        {
            ProviderInfo = new Model.Provider();
            ProviderContact = new ProviderContactDetail();
            ProviderRepresentive = new ProviderRepresentiveDetail();
        }
        //public string UserName { get; set; }
        public Model.Provider ProviderInfo { get; set; }
        public Model.ProviderContactDetail ProviderContact { get; set; }
        public Model.ProviderRepresentiveDetail ProviderRepresentive { get; set; }
    }
}
