using COE.Common.Model;
using COE.Survey.Web.Helpers;
using COE.Survey.Web.Helpers.LookupValues;
using COE.Survey.Web.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace COE.Survey.Web
{
    public partial class SurveysController
    {
        public static bool IsSurveyImagePathFormat(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string pattern = @"^/Surveys/Image/[^/]+$";
            return Regex.IsMatch(input, pattern);
        }

        private bool IsUserSurveyCreator()
        {
            var ADuser = UnitOfWork.UserDisplay.GetByQuery(ex => ex.LoginName == UserName).ToList();
            if (ADuser == null)
            {
                return UserManager.IsCurrentUserInRole(RolesNames.SurveyCreator)
                 && !UserManager.IsCurrentUserInRole(RolesNames.SurveyApprover)
                 && !UserManager.IsCurrentUserInRole(RolesNames.SurveyPublisher);
            }
            else
            {
                return ADuser[0].AspNetRoles.Where(ex => ex.Name == RolesNames.SurveyCreator).Count() > 0;
            }

        }

        private bool IsUserSurveyApproval()
        {
            var ADuser = UnitOfWork.UserDisplay.GetByQuery(ex => ex.LoginName == UserName).ToList();
            if (ADuser == null)
            {
                return UserManager.IsCurrentUserInRole(RolesNames.SurveyApprover);
            }
            else
            {
                return ADuser[0].AspNetRoles.Where(ex => ex.Name == RolesNames.SurveyApprover).Count() > 0;
            }

        }

        private bool IsUserSurveyPublisher()
        {
            var ADuser = UnitOfWork.UserDisplay.GetByQuery(ex => ex.LoginName == UserName).ToList();
            if (ADuser == null)
            {
                return UserManager.IsCurrentUserInRole(RolesNames.SurveyPublisher);
            }
            else
            {
                return ADuser[0].AspNetRoles.Where(ex => ex.Name == RolesNames.SurveyPublisher).Count() > 0;
            }

        }

        private bool IsUserSurveyAdmin()
        {
            var ADuser = UnitOfWork.UserDisplay.GetByQuery(ex => ex.LoginName == UserName).ToList();
            if (ADuser == null)
            {
                return UserManager.IsCurrentUserInRole(RolesNames.SurveyAdmin);
            }
            else
            {
                return ADuser[0].AspNetRoles.Where(ex => ex.Name == RolesNames.SurveyAdmin).Count() > 0;
            }

        }


        private bool IsEditable(COE.Common.Model.Survey survey)
        {
            return survey.StatusId.HasValue && (SurveyStatusEnum)survey.StatusId == SurveyStatusEnum.Draft;
        }

        private void HandleSurveyAnswers(COE.Common.Model.Survey survey, int surveyId)
        {
            if (survey.SurveyAnswer.Any())
            {
                var questionAnswers = UnitOfWork.QuestionAnswer.GetByQuery(a => a.SurveyAnswer.SurveyId == surveyId).ToList();
                UnitOfWork.QuestionAnswer.Delete(questionAnswers);

                var surveyAnswers = survey.SurveyAnswer.ToList();
                UnitOfWork.SurveyAnswer.Delete(surveyAnswers);

                UnitOfWork.Save();
            }
        }

        private string HandleLogo(JObject jObj)
        {
            try
            {
                var logoBase64Str = JsonHelper.GetAttributeFromJson("logo", jObj);

                if (IsSurveyImagePathFormat(logoBase64Str))
                {
                    return logoBase64Str;
                }

                Guid newImgId = Guid.NewGuid();
                UnitOfWork.SurveyImage.Add(new SurveyImage { ID = newImgId, ImgContent = logoBase64Str, Created = DateTime.Now });
                UnitOfWork.Save();
                return Url.Action("Image", "Surveys", new { id = newImgId });
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private Dictionary<string, string> GetChoices(string JsonContent, QuestionTypeEnum questionType)
        {
            Dictionary<string, string> choices = new Dictionary<string, string>();

            JObject jobject = JObject.Parse(JsonContent);

            if (questionType != QuestionTypeEnum.Rating)
            {
                List<JToken> options = jobject["choices"].ToList();
                var props = jobject.Properties().ToList();



                foreach (JToken option in options)
                {
                    if (option.HasValues)
                    {
                        //if (option["value"].ToString() == "other")
                        //{
                        //    option["value"] = "أخرى";
                        //}

                        choices.Add(option["value"].ToString(), option["text"].ToString());
                    }
                    else
                    {
                        choices.Add(option.ToString(), option.ToString());
                    }
                }

                if (props.Any(a => a.Name.ToString() == "hasOther"))
                {
                    if (jobject["hasOther"].ToString() == "True")
                    {
                        choices.Add("other", jobject["otherText"].ToString());
                    }
                }

            }
            else if (questionType == QuestionTypeEnum.Rating)
            {
                if (jobject["rateValues"] != null)
                {
                    List<JToken> options = jobject["rateValues"].ToList();
                    foreach (JToken option in options)
                    {
                        if (option.HasValues)
                        {
                            choices.Add(option["value"].ToString(), option["text"].ToString());
                        }
                        else
                        {
                            choices.Add(option.ToString(), option.ToString());
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        choices.Add(i.ToString(), i.ToString());
                    }
                }

            }

            return choices;
        }

        private Dictionary<string, string> GetChoices(SurveyQuestion question, out string choicesJson)
        {
            QuestionTypeEnum questionType = (QuestionTypeEnum)question.TypeId;
            choicesJson = string.Empty;

            Dictionary<string, string> separatedAnswers = new Dictionary<string, string>();
            if (questionType == QuestionTypeEnum.CheckBox || questionType == QuestionTypeEnum.RadioGroup)
            {
                choicesJson = "[";


                List<JToken> options = JObject.Parse(question.JsonContent)["choices"].ToList();
                foreach (JToken option in options)
                {
                    if (option["value"] != null)
                    {
                        choicesJson += "\"" + option["value"] + "\"" + ",";
                        separatedAnswers.Add(option["value"].ToString(), option["text"].ToString());
                    }
                    else
                    {
                        choicesJson += "\"" + option + "\"" + ",";
                        separatedAnswers.Add(option.ToString(), option.ToString());
                    }
                }

                choicesJson += "]";
                choicesJson = choicesJson.Replace(",]", "]");
            }
            else if ((QuestionTypeEnum)question.TypeId == QuestionTypeEnum.Rating)
            {
                choicesJson = "[\"1\", \"2\", \"3\", \"4\", \"5\"]";
                for (int i = 1; i <= 5; i++)
                {
                    separatedAnswers.Add(i.ToString(), i.ToString());
                }
            }


            return separatedAnswers;
        }

        private List<string> GetQuestionFinalAnswers(SurveyQuestion question)
        {
            QuestionTypeEnum questionType = (QuestionTypeEnum)question.TypeId;

            List<string> separatedAnswers = new List<string>();
            if (questionType == QuestionTypeEnum.CheckBox || questionType == QuestionTypeEnum.RadioGroup)
            {
                foreach (var answer in question.QuestionAnswer)
                {
                    var splittedAnswer = answer.AnswerText.Split(',');
                    foreach (var splt in splittedAnswer)
                    {
                        separatedAnswers.Add(splt);
                    }
                }
            }
            else
            {
                separatedAnswers.AddRange(question.QuestionAnswer.Select(a => a.AnswerText).ToList());
            }

            return separatedAnswers;
        }

        private bool IsPrivateIpAddress(string ipAddress)
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }

    }
}