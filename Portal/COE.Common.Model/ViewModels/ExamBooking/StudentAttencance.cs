using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels
{
    public class StudentAttencance : BaseViewModel
    {
        [Display(Name = "AttendenceStatus", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public int AttendenceStatusId { get; set; }

        public bool IsSelected { get; set; }


        [Display(Name = "TraineeName", ResourceType = typeof(DCSResources))]
        public string ViewTraineeName { get; set; }

        [Display(Name = "TraineeStatus", ResourceType = typeof(DCSResources))]
        public string ViewTraineeStatus { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(DCSResources))]
        public string ViewNationalId { get; set; }

        public string AttendenceStatusValue { get; set; }

        public bool AllowEdit { get; set; } = true;
        public int ExamCalendarRequestId { get; set; }
        public bool AllowExport { get; set; }
    }
}
