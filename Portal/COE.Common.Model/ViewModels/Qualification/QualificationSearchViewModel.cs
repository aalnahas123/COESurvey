using COE.Common.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Qualification
{
    public class QualificationSearchViewModel : BaseSearchViewModel
    {
        [Display(Name = "Specialization_Level", ResourceType = typeof(QualificationResources))]
        public string LevelName { get; set; }

        public int SpecializationParentID { get; set; }

        [Display(Name = "SpecializationParentName", ResourceType = typeof(QualificationResources))]
        public string SpecializationParentName { get; set; }

        public int ID { get; set; }

        [Display(Name = "QualificationName", ResourceType = typeof(QualificationResources))]
        public string Name { get; set; }

        [Display(Name = "Specialization_Code", ResourceType = typeof(QualificationResources))]
        public string SpecializationCode { get; set; }

        [Display(Name = "Specialization_Level", ResourceType = typeof(QualificationResources))]
        public int? LevelID { get; set; }

        [Display(Name = "QualificationSector", ResourceType = typeof(QualificationResources))]
        public int? SectorID { get; set; }

        [Display(Name = "Specialization_StatusID", ResourceType = typeof(QualificationResources))]
        public int? StatusID { get; set; }

        [Display(Name = "Specialization_StatusID", ResourceType = typeof(QualificationResources))]
        public string StatusName { get; set; }

        [Display(Name = "Specialization_IsPathway", ResourceType = typeof(QualificationResources))]
        public int? IsPathway { get; set; }

        [Display(Name = "Specialization_TotalLearningHours", ResourceType = typeof(QualificationResources))]
        public int LearningHours { get; set; }

        public int CollegeCount { get; set; }

        public string CollegeName { get; set; }

        public bool IsDateExpired { get; set; }
        public bool CanStartWorkflow { get; set; }

        public bool CanRenew { get; set; }

    }
}
