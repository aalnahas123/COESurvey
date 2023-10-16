using COE.Common.Localization;
using COE.Common.Model.ViewModels.Enrollment;
using PagedList;
using RM.Workflow;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Workflows
{
    public class EnrollmentStatisticViewModel
    {
        public EnrollmentStatistic EnrollmentStatistic { get; set; }

        public DecisionViewModel Decision { get; set; }

        public List<RequestActionViewModel> RequestActionList { get; set; }

    }
}
