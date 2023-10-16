using System;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class RequestActionViewModel
    {
        public RequestActionViewModel()
        {
        }
        public long RequestActionID { get; set; }
        public long RequestID { get; set; }
        public int StageID { get; set; }
        public int? DecisionID { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime RequestActionDate { get; set; }
        public DateTime CreatedOn { get; set; }

        public string StageName { get; set; }
        public string DecisionName { get; set; }

    }
}
