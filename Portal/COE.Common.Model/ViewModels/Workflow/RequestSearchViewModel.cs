
namespace COE.Common.Model.ViewModels.Workflows
{
    using System;
    using System.Collections.Generic;
    using PagedList;
    using System.ComponentModel.DataAnnotations;
    using RM.Workflow;
    using System.Linq;

    /// <summary>
    /// The Request Search View Model
    /// </summary>
    /// <date>7/19/2017</date>
    /// <author>Zakaria Bahhah zbahhah@sure.com.sa</author>
    /// <seealso cref="COE.Enrollment.Model.BaseSearchViewModel" />
    public class RequestSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "WorkflowIDAsProcessName", ResourceType = typeof(InboxResources))]
        public byte? WorkflowID { get; set; }

        public long RequestID { get; set; }

        [Display(Name = "RequestName", ResourceType = typeof(InboxResources))]
        public string RequestName { get; set; }

        [Display(Name = "ProcessName", ResourceType = typeof(InboxResources))]
        public string ProcessName { get; set; }

        [Display(Name = "RequestNumber", ResourceType = typeof(InboxResources))]
        public string RequestNumber { get; set; }

        [Display(Name = "RequestDate", ResourceType = typeof(InboxResources))]
        public DateTime RequestDate { get; set; }

        [Display(Name = "OriginatorName", ResourceType = typeof(InboxResources))]
        public string OriginatorName { get; set; }

        [Display(Name = "SerialNumber", ResourceType = typeof(InboxResources))]
        public string SerialNumber { get; set; }

        [Display(Name = "ActivityName", ResourceType = typeof(InboxResources))]
        public string ActivityName { get; set; }

        [Display(Name = "UserFullName", ResourceType = typeof(InboxResources))]
        public string UserFullName { get; set; }

        [Display(Name = "AllocatedUser", ResourceType = typeof(InboxResources))]
        public string AllocatedUser { get; set; }

        public List<LookupViewModel> ProcessNames { get; set; }

        public StaticPagedList<RequestViewModel> Items { get; set; }

        public Guid? StudentUserId { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(InboxResources))]
        public string NationalId { get; set; }

        [Display(Name = "FromTaskDate", ResourceType = typeof(InboxResources))]
        public DateTime? FromTaskDate { get; set; }

        [Display(Name = "ToTaskDate", ResourceType = typeof(InboxResources))]
        public DateTime? ToTaskDate { get; set; }

        public int CollegeId { get; set; }
        public bool IsStudent { get; set; }
        public bool IsEmployer { get; set; }
        //public IEnumerable<Stage> SearchStages { get; set; }

        public List<LookupViewModel> RequestTypesList { get; set; }
        public List<LookupViewModel> StatusesList { get; set; }

        public int? SearchStatusID { get; set; }

        public List<System.Web.Mvc.SelectListItem> CollegesList { get; set; }

        public int? SearchCollegeID { get; set; }
        public bool IsCenterAdmin { get; set; }
        public bool IsSOCStudentAffairs { get; set; }
        public bool IsSOCRegistrar { get; set; }

        public string SourceControllerName { get; set; }
    }
}
