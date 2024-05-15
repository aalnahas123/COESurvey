﻿using System;
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
    public static class SurveyApproversHelper
    {
        private static readonly string ActiveDirectoryFullPath = AppSettings.ActiveDirectoryFullPath;

        private static readonly string AdAdminUser = AppSettings.ActiveDirectoryUser;

        private static readonly string AdAdminPassword = AppSettings.ActiveDirectoryPassword;

        public static string GetManagerUser(string sUserName)
        {
            try
            {
                DirectoryEntry root = new DirectoryEntry(ActiveDirectoryFullPath, AdAdminUser, AdAdminPassword);
                DirectorySearcher searcher = new DirectorySearcher(root);
                var user = sUserName.Replace("coe\\", "");
                searcher.Filter = "(&(objectClass=User)(mailNickname=" + user + "))";

                string approvaluser = string.Empty;

                foreach (SearchResult sResultSet in searcher.FindAll())
                {
                    
                    //fortest = GetProperty(sResultSet, "mobile");
                    approvaluser = GetProperty(sResultSet, "manager");
                    approvaluser = approvaluser.Replace("CN=", "COE\\");
                    approvaluser = string.Concat(approvaluser.TakeWhile((c) => c != ','));
                    if(string.IsNullOrEmpty(approvaluser))
                    {
                        approvaluser = "coe\\coeuser1";
                    }
                }
                return approvaluser;
            }
            catch
            {
                return string.Empty;
            }
        }


        public static string GetProperty(SearchResult searchResult,string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool UpdateUserApprovers(COEUoW unitOfWork, int surveyId, string surveyCreator)
        {
            string managerApproval = GetManagerUser(surveyCreator);

            unitOfWork.SurveyApprover.Add(
                new Common.Model.SurveyApprover
                {
                    SurveyId = surveyId,
                    ApproverUsername = managerApproval,
                    CreatedBy = surveyCreator,
                    CreatedOn = DateTime.Now
                });

            int rows = unitOfWork.Save();
            return rows > 0;
        }
    }
}