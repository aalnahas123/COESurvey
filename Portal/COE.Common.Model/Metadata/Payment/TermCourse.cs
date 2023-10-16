using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(TermCourseMetaData))]
    public partial class TermCourse
    {
    }
    public class TermCourseMetaData
    {
        [Display(Name = "MD_Course", ResourceType = typeof(PaymentResource))]
        public int CourseID { get; set; }

    }
}
