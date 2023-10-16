using COE.Common.Localization;
using Commons.Framework.Web.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.MOL.ExamRequest
{
    public class TermsOfServices
    {
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "IsHealthSpecialist", ResourceType = typeof(ExamRequestResources))]
        //public bool IsHealthSpecialist { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "QualificationFrom", ResourceType = typeof(ExamRequestResources))]
        //public bool IsSaudiEducationalQualification { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "IseTrainingCompleted", ResourceType = typeof(ExamRequestResources))]
        public bool IseTrainingCompleted { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "AcceptTermOfService", ResourceType = typeof(ExamRequestResources))]
        public bool IsAcceptTermOfService { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "TrainingTrack", ResourceType = typeof(ExamRequestResources))]
        //public byte TrainingTrack  { get; set; }

        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //[Display(Name = "RecaptchaVerification", ResourceType = typeof(ApplicantResources))]
        //[GoogleRecaptcha(ErrorMessageResourceName = "RecaptchaVerification", ErrorMessageResourceType = typeof(ApplicantResources))]
        //public string RecaptchaResponse { get; set; }

    }
}