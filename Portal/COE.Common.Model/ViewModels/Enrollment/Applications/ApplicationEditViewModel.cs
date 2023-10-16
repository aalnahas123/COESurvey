using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ApplicationEditViewModel
    {
        public EnrollmentRequest EnrollmentRequest { get; set; }
        public StudentChoicesEditViewModel StudentChoices { get; set; }
    }
}
