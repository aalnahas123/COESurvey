using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class CollegeViewModel
    {
        public College College { get; set; }

        public IList<College> Colleges { get; set; }
    }
}
