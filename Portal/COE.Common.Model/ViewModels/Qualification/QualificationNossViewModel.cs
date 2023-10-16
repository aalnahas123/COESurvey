using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Qualification
{
    public class QualificationNossViewModel
    {
        public int SpecializationID { get; set; }
        public int CourseID { get; set; }
        public string Code { get; set; }
        public int CollegeID { get; set; }
        public string CourseCode { get; set; }
        public int CourseLevelID { get; set; }
        public string CourseSequenceNo { get; set; }
        public int CreditHours { get; set; }
        public int NOSSCourseID { get; set; }
        public string Name { get; set; }
        public int SubProgramID { get; set; }
        public int CourseTypeID { get; set; }
        public int UnitID { get; set; }
    }
}
