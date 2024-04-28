using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COE.Common.Model;
using COE.Survey.BLL;

namespace COE.Survey.Web
{
    public static class SurveyApproversHelper
    {
        public static bool UpdateUserApprovers(COEUoW unitOfWork, int surveyId, string surveyCreator)
        {
            // Get Approvers
            string surveyApprover = "xxyyzz";

            // Fake User
            AspNetUsers approver = new AspNetUsers();

            unitOfWork.SurveyApprover.Add(
                new Common.Model.SurveyApprover
                {
                    SurveyId = surveyId,
                    ApproverUsername = surveyApprover,
                    CreatedBy = surveyCreator,
                    CreatedOn = DateTime.Now
                });

            int rows = unitOfWork.Save();
            return rows > 0;
        }
    }
}