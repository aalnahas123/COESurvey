using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class SessionValidation
    {
        public SessionValidation Clone()
        {
            return (SessionValidation)base.MemberwiseClone();
        }
    }
}
