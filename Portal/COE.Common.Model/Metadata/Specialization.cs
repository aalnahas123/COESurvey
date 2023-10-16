using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace COE.Common.Model
{
    [MetadataType(typeof(SpecializationMetaData))]
    public partial class Specialization : CommonMetaData
    {
        public bool IsSelected { get; set; }
       
        internal class SpecializationMetaData
        {
            [Display(Name = "QualificationName", ResourceType = typeof(QualificationResources))]
            public string Name { get; set; }

            [Display(Name = "QualificationName", ResourceType = typeof(QualificationResources))]
            public string NameAr { get; set; }

            [Display(Name = "Specialization_Code", ResourceType = typeof(QualificationResources))]
            public string SpecializationCode { get; set; }

            [Display(Name = "Specialization_Sector", ResourceType = typeof(QualificationResources))]
            public int SectorID { get; set; }

            [Required]
            [Display(Name = "Specialization_Level", ResourceType = typeof(QualificationResources))]
            public int LevelID { get; set; }

            [Display(Name = "Specialization_SAQFLevel", ResourceType = typeof(QualificationResources))]
            public Nullable<int> SAQFLevel { get; set; }

            [Display(Name = "Specialization_PreRequisiteLevelID", ResourceType = typeof(QualificationResources))]
            public Nullable<int> PreRequisiteLevelID { get; set; }

            [Display(Name = "Specialization_IsAssesmentAvailable", ResourceType = typeof(QualificationResources))]
            public Nullable<bool> IsAssesmentAvailable { get; set; }

            [Display(Name = "Specialization_IsEndorsed", ResourceType = typeof(QualificationResources))]
            public Nullable<bool> IsEndorsed { get; set; }

            [Display(Name = "Specialization_TotalLearningHours", ResourceType = typeof(QualificationResources))]
            public Nullable<int> TotalLearningHours { get; set; } = 0;

            [Display(Name = "Specialization_IsTestAvailable", ResourceType = typeof(QualificationResources))]
            public Nullable<bool> IsTestAvailable { get; set; }

            [Display(Name = "Specialization_RegulatoryAuthority", ResourceType = typeof(QualificationResources))]
            public string RegulatoryAuthority { get; set; }

            [Display(Name = "Specialization_Version", ResourceType = typeof(QualificationResources))]
            public string Version { get; set; }

            [Display(Name = "Specialization_IsPublic", ResourceType = typeof(QualificationResources))]
            public Nullable<bool> IsPublic { get; set; }

            [DataType(DataType.MultilineText)]
            [AllowHtml]
            [Display(Name = "Specialization_SpecializationRationle", ResourceType = typeof(QualificationResources))]
            public string SpecializationRationle { get; set; }

            [DataType(DataType.MultilineText)]
            [AllowHtml]
            [Display(Name = "Specialization_Description", ResourceType = typeof(QualificationResources))]
            public string Description { get; set; }

            [Display(Name = "Specialization_DescriptionAr", ResourceType = typeof(QualificationResources))]
            public string DescriptionAr { get; set; }

            [Display(Name = "Specialization_EndorsedBy", ResourceType = typeof(QualificationResources))]
            public string EndorsedBy { get; set; }

            [Display(Name = "Specialization_SpecializationParentID", ResourceType = typeof(QualificationResources))]
            public Nullable<int> SpecializationParentID { get; set; }
        }
    }
}
