using COE.Common.Localization;
using COE.Common.Localization.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
     public partial class College
    {
        public bool IsSelected { get; set; }
        public virtual List<Specialization> SpecializationsList { get; set; } = new List<Model.Specialization>();
    }
}

