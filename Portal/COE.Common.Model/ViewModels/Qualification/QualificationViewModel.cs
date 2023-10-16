using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Qualification
{
    public class QualificationViewModel : BaseViewModel
    {
        public int SpecializationID { get; set; }
        [Display(Name = "Specialization_Program", ResourceType = typeof(QualificationResources))]
        public int? ProgramSpecializationId { get; set; }

        [Display(Name = "Specialization_IsPathway", ResourceType = typeof(QualificationResources))]
        public bool IsPathway { get; set; }

        public bool IsPreRequest { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public string CourseSequenceNo { get; set; }


        [Display(Name = "Specialization_CourseId", ResourceType = typeof(QualificationResources))]
        public string CourseId { get; set; }

        public int? NossId { get; set; }

        public List<NOSSCourse> NossCourseList { get; set; }
        public List<GradingRule> GradingRuleList { get; set; }
        public List<CourseType> CourseTypeList { get; set; }
        public List<College> CollegeList { get; set; }

        public int AssmentComponentId { get; set; }

        public int SpStatusId { get; set; }

        public Specialization Specialization { get; set; }

        public List<Course> Course { get; set; }

        public List<QualificationNossViewModel> EquivalentNOSSCourseList { get; set; }
        public List<SpecializationComponentAssessment> SpecializationComponentAssessmentList { get; set; }

        public List<SpecializationUnit> SpecializationUnitList { get; set; }
    }
}
