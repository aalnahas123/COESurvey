using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.AssessmentPeriod
{
    public class ExamCalendarV
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public bool IsFlexibleDateEditing { get; set; } 
        public bool IsRequireApproval { get; set; }
    }
}
