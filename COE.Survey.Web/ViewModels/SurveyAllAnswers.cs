
namespace COE.Survey.Web.ViewModels
{
    public class SurveyAllAnswers
    {

        public string SurveyTitle { get; set; } = null;


        public string ContentJson { get; set; } = null;

        public string AnswerItems { get; set; } = "";
        public int Id { get; internal set; }
    }
}