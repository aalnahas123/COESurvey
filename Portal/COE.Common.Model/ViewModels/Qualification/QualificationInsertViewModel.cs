using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Qualification
{
    public class QualificationInsertViewModel
    {
        public int AssmentComponentId { get; set; }
        public int CourseId { get; set; }
        public int SectorID { get; set; }
        public int ProgramSpecializationId { get; set; }
        public QualificationNossViewModel Specialization { get; set; }
    }
}
