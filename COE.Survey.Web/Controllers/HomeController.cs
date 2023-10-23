using COE.Common.Helper;
using COE.Survey.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Mvc;

namespace COE.Survey.Web.Controllers
{
    public class HomeController : BaseController<COEUoW>
    {
        public string CurrentLang
        {
            get
            {
                try
                {
                    return HttpContext.Session["lang"].ToString();
                }
                catch (Exception ex)
                {
                    return "en";
                }

            }
        }

        public HomeController()
        {

        }

        public ActionResult Index(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;


            if (_context.SurveyItems == null)
            {
                return NotFound();
            }

            var surveys = _context.SurveyItems.OrderByDescending(a => a.UpdatedOn).ToList();

            return View(surveys);
        }

        public ActionResult Create(string lang, int id)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;

            var surveyItem = _context.SurveyItems
                .FirstOrDefault(m => m.Id == id);
            if (surveyItem == null)
            {
                return View(new SurveyItem { Id = 0 });
            }

            return View(surveyItem);
        }

        public ActionResult Clone(string lang, int id)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;

            var surveyItem = _context.SurveyItems
                .FirstOrDefault(m => m.Id == id);
            if (surveyItem == null)
            {
                return View(new SurveyItem { Id = 0 });
            }

            surveyItem.Id = 0;
            return View(surveyItem);
        }

        public ActionResult Answer(string lang, int id)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;

            var surveyItem = _context.SurveyItems
                .FirstOrDefault(m => m.Id == id);
            if (surveyItem == null)
            {
                return NotFound();
            }

            return View(surveyItem);
        }

        public ActionResult Dashboard(string lang, int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(lang))
                {
                    HttpContext.Session["lang"] = lang;
                }

                TempData["lang"] = CurrentLang;




                var surveyItem = _context.SurveyItems.FirstOrDefault(m => m.Id == id);
                if (surveyItem != null)
                {
                    var answerItems = _context.AnswerItems.Where(m => m.SurveyId == id).ToList().Select(a => JObject.Parse(a.AnswerJson));
                    if (answerItems != null)
                    {
                        var json = JsonConvert.SerializeObject(new
                        {
                            data = answerItems
                        });

                        SurveyAllAnswers allAnswers = new SurveyAllAnswers
                        {
                            Id = id,
                            AnswerItems = JsonConvert.SerializeObject(answerItems),
                            SurveyTitle = surveyItem.Title,
                            ContentJson = surveyItem.ContentJson
                        };


                        return View(allAnswers);
                    }

                    return View(new SurveyAllAnswers { Id = 0, ContentJson = surveyItem.ContentJson, SurveyTitle = surveyItem.Title });
                }

                return View(new SurveyAllAnswers { Id = 0 });
            }
            catch (Exception)
            {
                return View(new SurveyAllAnswers { Id = 0 });
            }
        }

        public ActionResult PollData(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;
            return View();
        }

        public ActionResult Gauge(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                HttpContext.Session["lang"] = lang;
            }

            TempData["lang"] = CurrentLang;
            return View();
        }

        public ActionResult Table(string lang, int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(lang))
                {
                    HttpContext.Session["lang"] = lang;
                }

                TempData["lang"] = CurrentLang;




                var surveyItem = _context.SurveyItems.FirstOrDefault(m => m.Id == id);
                if (surveyItem != null)
                {
                    var answerItems = _context.AnswerItems.Where(m => m.SurveyId == id).ToList().Select(a => JObject.Parse(a.AnswerJson));
                    if (answerItems != null)
                    {
                        var json = JsonConvert.SerializeObject(new
                        {
                            data = answerItems
                        });

                        SurveyAllAnswers allAnswers = new SurveyAllAnswers
                        {
                            Id = id,
                            AnswerItems = JsonConvert.SerializeObject(answerItems),
                            SurveyTitle = surveyItem.Title,
                            ContentJson = surveyItem.ContentJson
                        };


                        return View(allAnswers);
                    }

                    return View(new SurveyAllAnswers { Id = 0, ContentJson = surveyItem.ContentJson, SurveyTitle = surveyItem.Title });
                }

                return View(new SurveyAllAnswers { Id = 0 });
            }
            catch (Exception)
            {
                return View(new SurveyAllAnswers { Id = 0 });
            }
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetLanguage(string value)
        {
            HttpContext.Session.SetString("lang", value ?? "");
            return new EmptyResult();
        }


        [HttpPost]
        public ActionResult<int> SaveSurvey(SurveyItem surveyItem)
        {
            try
            {
                surveyItem.Title = GetAttributeFromJson("title", surveyItem.ContentJson);
                surveyItem.Logo = GetAttributeFromJson("logo", surveyItem.ContentJson);

                if (_context.SurveyItems.Any(a => a.Id == surveyItem.Id))
                {
                    surveyItem.CreatedOn = DateTime.Now;
                    surveyItem.UpdatedOn = DateTime.Now;
                    _context.Update(surveyItem);
                }
                else
                {
                    surveyItem.Id = 0;
                    surveyItem.CreatedOn = DateTime.Now;
                    surveyItem.UpdatedOn = DateTime.Now;
                    _context.Add(surveyItem);

                }

                var rows = _context.SaveChanges();
                if (rows > 0)
                {
                    return new OkObjectResult(surveyItem.Id);
                }

                return new OkObjectResult(-1);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(-1);
            }
        }

        [HttpPost]
        public ActionResult<int> SaveAnswer(AnswerItem answerItem)
        {
            try
            {
                answerItem.Id = 0;
                _context.Add(answerItem);

                var rows = _context.SaveChanges();
                if (rows > 0)
                {
                    return new OkObjectResult(answerItem.Id);
                }

                return new OkObjectResult(-1);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(-1);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private string GetAttributeFromJson(string attribute, string jsonCotent)
        {
            try
            {
                var jObj = JObject.Parse(jsonCotent);

                string locale = "";
                if (jObj["locale"] != null && jObj["locale"].ToString().ToLower() == "ar")
                {
                    locale = "ar";
                }
                else
                {
                    locale = "en";
                }


                if (jObj[attribute].HasValues)
                {
                    if (locale == "ar")
                    {
                        return jObj[attribute]["ar"].ToString();
                    }

                    return jObj[attribute]["default"].ToString();
                }
                else
                {
                    return jObj[attribute].ToString();
                }


            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }
}