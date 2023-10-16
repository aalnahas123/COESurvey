using COE.Common.Model.ViewModels.Workflows;
using System;
using System.Collections.Generic;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentChangeStatusRequestViewModel
    {
        public int ID { get; set; }
        public int EnrollmentID { get; set; }
        public long WorkflowRequestID { get; set; }
        public int AcademicYearTermId { get; set; }
        public int PrevStageID { get; set; }
        public int CurrentStageID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual AcademicYearTerm AcademicYearTerm { get; set; }
        public virtual EnrollmentViewModel Enrollment { get; set; }
        public virtual RequestViewModel Request { get; set; }
        public List<RequestActionViewModel> RequestActionList { get; set; }

        public string AcademicYearTermName { get; set; }
        public string PrevStageName { get; set; }
        public string CurrentStageName { get; set; }

    }
}
