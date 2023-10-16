using COE.Common.Localization;
using COE.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Exam.Model.ViewModels
{
    public class StudentExamBookingViewModel
    {
        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "NationalId")]
        public string NationalId { get; set; }
        public int ID { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "TraineeName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "IntakeBatch")]
        public string IntakeBatch { get; set; }

        [Display(ResourceType = typeof(ExamBookingAdminResources), Name = "Status")]
        public string Status { get; set; }

       

      
    }


}
