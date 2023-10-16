using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public abstract class BaseRegistrationStepVM
    {
        public string PrevBtn { get; set; }
        public string NextBtn { get; set; }
        public int StepNumber { get; set; }
        public bool IsFirst { get { return StepNumber == 1; }  } 
        public bool IsLast { get { return StepNumber == 5; } }
    }
}
