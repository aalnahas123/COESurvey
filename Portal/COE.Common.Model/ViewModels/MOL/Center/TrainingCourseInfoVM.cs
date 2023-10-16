using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public class TrainingCourseInfoVM : BaseRegistrationStepVM
    {
        public TrainingCourseInfoVM()
        {
            StepNumber = 3;
        }

        public IEnumerable<TrainingCourseVM> TrainingCourses { get; set; }

        public bool ForRegistration { get; set; } = true;

        public int CenterID { get; set; }
    }
}
