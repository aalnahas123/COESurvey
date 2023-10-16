using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(EnrollmentMetaData))]
    public partial class Enrollment : CommonMetaData
    {

    }
    internal class EnrollmentMetaData
    {

        [Display(Name = "Enrollment_TVTCStudentNo", ResourceType = typeof(StipendResources))]
        public Nullable<int> TVTCStudentNo { get; set; }       
    }
}
