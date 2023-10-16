using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.DCS
{
    public class SessionUploadItem
    {
        public string SectionCode { get; set; }
        public TimeSpan? fromTime { get; set; }
        public TimeSpan? toTime { get; set; }       
        public string SundayCourse { get; set; }
        public string MondayCourse { get; set; }
        public string TuesdayCourse { get; set; }
        public string WednesdayCourse { get; set; }
        public string ThursdayCourse { get; set; }

        public string SundayInstructor { get; set; }
        public string MondayInstructor { get; set; }
        public string TuesdayInstructor { get; set; }
        public string WednesdayInstructor { get; set; }
        public string ThursdayInstructor { get; set; }
        public Section Sundaysection { get; set; }
        public Section Mondaysection { get; set; }
        public Section Tuesdaysection { get; set; }
        public Section Wednesdaysection { get; set; }
        public Section Thursdaysection { get; set; }

    }
}
