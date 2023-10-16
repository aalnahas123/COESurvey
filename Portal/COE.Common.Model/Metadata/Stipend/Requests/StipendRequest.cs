using COE.Common.Localization;
using COE.Common.Model.ViewModels.Stipend;
using PagedList;
using System;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(StipendsRequestMetadata))]
    public partial class StipendsRequest : PagedResultBase
    {
        [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
        public string CollegeName { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public string MonthName { get; set; }

        [Display(Name = "HijriMonth", ResourceType = typeof(StipendResources))]
        public int? MonthId { get; set; }

        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public string YearName { get; set; }

        [Display(Name = "HijriYear", ResourceType = typeof(StipendResources))]
        public int? YearId { get; set; }

        [Display(Name = "Cards_Title_NationalId", ResourceType = typeof(StipendResources))]
        public int? NationalId { get; set; }

        public StaticPagedList<StipendsRequest> Items { get; set; }
        class StipendsRequestMetadata
        {
            [Display(Name = "Common_College", ResourceType = typeof(StipendResources))]
            public int? CollegeID { get; set; }

            [Display(Name = "CardsRequest_NoOfStudents", ResourceType = typeof(StipendResources))]
            public int? NoOfStudents { get; set; }

            [Display(Name = "CardsRequest_NoOfRejected", ResourceType = typeof(StipendResources))]
            public int? NoOfRejected { get; set; }

            [Display(Name = "CardsRequest_NoOfAccepted", ResourceType = typeof(StipendResources))]
            public int? NoOfAccepted { get; set; }

            [Display(Name = "Common_FeedbackStatus", ResourceType = typeof(StipendResources))]
            public int? StipendFeedbackStatusID { get; set; }

            [Display(Name = "Common_RequestStatus", ResourceType = typeof(StipendResources))]
            public int? RequestStatusID { get; set; }

            [Display(Name = "Common_StipendNo", ResourceType = typeof(StipendResources))]
            public int RequestNo { get; set; }

        }
    }

}