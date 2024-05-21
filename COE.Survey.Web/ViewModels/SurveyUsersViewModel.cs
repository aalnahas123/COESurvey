using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COE.Common.Model;
using COE.Common.Model.ViewModels;

namespace COE.Survey.Web.ViewModels
{
    public class SurveyUsersViewModel
    {
        public int? Id { get; set; }
        public Common.Model.Survey currentSurvey { get; set; } = new Common.Model.Survey();
        public List<SurveyViewer> currentSurvetyUsers { get; set; } = new List<SurveyViewer>();
        public AspNetUsersSearchModel users { get; set; } = new AspNetUsersSearchModel();

    }
}