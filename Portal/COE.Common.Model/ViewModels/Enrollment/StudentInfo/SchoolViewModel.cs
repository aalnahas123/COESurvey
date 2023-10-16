using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class SchoolViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public int QualificationID { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Specialization", ResourceType = typeof(ApplicantResources))]        
        public string Specialization { get; set; }
        public bool IsHighSchool { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolName", ResourceType = typeof(AppResources))]
        public string Name { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolType", ResourceType = typeof(AppResources))]
        public string SchoolType { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolCity", ResourceType = typeof(AppResources))]
        public string CityName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GraduationYear", ResourceType = typeof(AppResources))]
        public int GraduationYear { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Range(0, 100, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RangeValidator")]
        [Display(Name = "GPA", ResourceType = typeof(AppResources))]
        public decimal GPA { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Range(0, 100, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RangeValidator")]
        [Display(Name = "Qiyas", ResourceType = typeof(AppResources))]
        public int StudentMeasure { get; set; }

        [Display(Name = "GraduationYear", ResourceType = typeof(AppResources))]
        public string GraduationYearName { get; set; }


        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolCity", ResourceType = typeof(AppResources))]
        public int CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolRegion", ResourceType = typeof(AppResources))]
        public int AreaId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "GraduationYear", ResourceType = typeof(AppResources))]
        public int GraduationYearId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "SchoolType", ResourceType = typeof(AppResources))]
        public int SchoolTypeId { get; set; }

        public int StudentProfileId { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "StudentIdentityAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase StudentSchoolAttachedFile { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? StudentSchoolAttachmentId { get; set; }


        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(SharedResources), Name = "AttachedFile")]
        public Guid? AcademicDegreeAttachmentId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "AcademicDegreeAttachment", ResourceType = typeof(ApplicantResources))]
        [ValidateFileUpload]
        //[RequiredIf("AttachmentId == null", ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public HttpPostedFileBase AcademicDegreeAttachedFile { get; set; }

    }
}
