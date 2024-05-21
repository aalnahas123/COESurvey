using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using COE.Common.Model;
using COE.Survey.BLL;
using Commons.Framework.Extensions;
using System.DirectoryServices;

namespace COE.Survey.Web
{
    public static class SurveyViewersHelper
    {
        public static bool AddUserViewer(COEUoW unitOfWork, int surveyId, string surveyCreator, string newSurveyViewer, bool canEdit)
        {
            unitOfWork.SurveyViewer.Add(
                new Common.Model.SurveyViewer
                {
                    SurveyId = surveyId,
                    CanEdit = canEdit,
                    ViewerUsername = newSurveyViewer,
                    CreatedBy = surveyCreator,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = surveyCreator,
                    ModifiedBy = DateTime.Now
                });

            int rows = unitOfWork.Save();
            return rows > 0;
        }

        public static bool UpdateUserViewer(COEUoW unitOfWork, int surveyId, string surveyCreator, string newSurveyViewer, bool canEdit)
        {
            var surveyViewer = unitOfWork.SurveyViewer.GetByQuery(s => s.SurveyId == surveyId && s.ViewerUsername == newSurveyViewer).FirstOrDefault();

            if (surveyViewer != null)
            {
                surveyViewer.CanEdit = canEdit;
                surveyViewer.ModifiedBy = DateTime.Now;
                surveyViewer.ModifiedOn = surveyCreator;

                int rows = unitOfWork.Save();

                return rows > 0;
            }

            return false;
        }


        public static bool DeleteUserViewer(COEUoW unitOfWork, int surveyId, string surveyCreator, string newSurveyViewer, bool canEdit)
        {
            var surveyViewer = unitOfWork.SurveyViewer.GetByQuery(s => s.SurveyId == surveyId && s.ViewerUsername == newSurveyViewer).FirstOrDefault();
            if (surveyViewer != null)
            {
                unitOfWork.SurveyViewer.Delete(surveyViewer);

                int rows = unitOfWork.Save();
                return rows > 0;
            }
            return false;
        }

    }
}