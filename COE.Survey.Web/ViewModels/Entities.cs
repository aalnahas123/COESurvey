using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COE.Survey.Web.ViewModels
{
    public enum QuestionTypeEnum
    {
        RadioGroup = 2,
        CheckBox = 4,
        Rating = 11
    }

    public enum SurveyStatusEnum
    {
        Draft = 0,
        Published = 1,
        Approved = 2,
        Rejected = 3,
        Deactivated = 4
    }
}