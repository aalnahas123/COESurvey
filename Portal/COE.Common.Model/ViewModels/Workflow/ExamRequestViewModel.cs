using System;
using System.Web;
using COE.Common.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RM.Workflow;
using Commons.Framework.Globalization;
using COE.Common.Model.Enums;

namespace COE.Common.Model.ViewModels.Workflow
{
    public class ExamRequestVM : CommonMetaData
    {
        public int ID { get; set; }
        public RPLExamRequest ExamRequestModel { get; set; }

        public ExamRequestVM()
        {
            ExamRequestModel = new RPLExamRequest();
        }

        [Display(Name = "TrainingTrack", ResourceType = typeof(ExamRequestResources))]
        public string LevelName { get; set; }


        private string _StageName;
        [Display(Name = "StageName", ResourceType = typeof(InboxResources))]
        public string StageName
        {
            get
            {
                if (string.IsNullOrEmpty(_StageName))
                    return ((CultureHelper.IsArabic) ? ExamRequestModel.Stage.NameAr : ExamRequestModel.Stage.Name);

                return _StageName;
            }
            set { _StageName = value; }
        }

        [Display(Name = "UserFullName", ResourceType = typeof(InboxResources))]
        public string UserFullName { get; set; }
        public string NationalID { get; set; }
        public bool IsExamSupervisor { get; set; }

        public int StatusID { get; set; }

        public System.DateTime RequestDate { get; set; }

        public StudentProfile StudentProfile => this.ExamRequestModel.AspNetUser.StudentProfile.FirstOrDefault();

        public string StudentBirthdate => string.Format("{0:dd / MM / yyyy}", Convert.ToDateTime(StudentProfile.BirthDate));

        public bool? IsSaudi_CEngineer_CHealth => ExamRequestModel.IsSaudi_CEngineer_CHealth;

        public bool? IsSaudiGraduate => ExamRequestModel.IsSaudiGraduate;

        public string CreatedBy => ExamRequestModel.CreatedBy;

        public DateTime CreatedOn => ExamRequestModel.CreatedOn;

        [Display(Name = "Comment", ResourceType = typeof(SharedResources))]
        public string Comment { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "RequestAction", ResourceType = typeof(AppResources))]
        public string SelectedAction { get; set; }

        public bool IsEducationSupervisor { get; set; }

        public bool IsStudent { get; set; } = false;

        public bool IsDecisionAvailable =>
            (IsEducationSupervisor 
                && ExamRequestModel.StageId == (int)RPLExamRequestStages.EducationSupervisorReview)
            || (IsStudent 
                && ExamRequestModel.StageId == (int)RPLExamRequestStages.SentBackToCandidate 
                && ExamRequestModel.RPLExamRequestActions.OrderByDescending(r => r.CreatedOn).Take(1).Any(r => r.DecisionID == 4));
        public bool HasUserDisplay { get; set; }

        public int[] RequestActionsForTainees = { 181, 183, 184, 185 };

        public List<RPLExamRequestAction> RequestActions
        {
            get
            {
                return ExamRequestModel.RPLExamRequestActions
                    .Where(x => HasUserDisplay
                    || ((RequestActionsForTainees.Contains(x.RPLExamRequest.StageId.Value))
                    || (x.StageId == 182 && !new List<int?> { 2, 4 }.Contains(x.DecisionID)))).ToList();
            }
        }

        public int StageID { get; set; }

        [Display(Name = "EducationLevel", ResourceType = typeof(AppResources))]
        public string EducationLevelName { get; set; }
    }
}
