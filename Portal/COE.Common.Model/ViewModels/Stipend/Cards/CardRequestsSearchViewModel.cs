using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace COE.Common.Model.ViewModels.Stipend
{
    public class CardRequestsSearchViewModel : PagedResultBase
    {
        [Display(Name = "Common_RequestNo", ResourceType = typeof(StipendResources))]
        public string RequestNo  { get; set; }

        [Display(Name = "Common_RequestType", ResourceType = typeof(StipendResources))]
        public int? RequestTypeID { get; set; }

        [Display(Name = "Common_RequestStatus", ResourceType = typeof(StipendResources))]
        public int? RequestStatusID { get; set; }

        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public int? CollegeID { get; set; }

        public StaticPagedList<CardsRequest> Items { get; set; }        
    }
  }
