using System;
using System.ComponentModel.DataAnnotations;
using RM.Workflow;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class RequestListViewModel
    {
        public long RequestId { get; set; }
        public int RequestDetailId { get; set; }
        public int CollegeId { get; set; }
        public string NationalId { get; set; }
        public string CollegeName { get; set; }
        [Display(Name = "RequestName", ResourceType = typeof(InboxResources))]
        public string RequestName { get; set; }

        public string RequestNumber { get; set; }

        [Display(Name = "StageName", ResourceType = typeof(InboxResources))]
        public string RequestStageName { get; set; }
        public string Term { get; set; }
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }

        public byte WorkflowID { get; set; }
        public int StatusID { get; set; }

    }
}
