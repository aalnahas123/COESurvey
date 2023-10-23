using Newtonsoft.Json.Linq;
using System;


namespace COE.Survey.Web.Helpers
{
    public static class JsonHelper
    {
        private const string DefaultLocale = "en";
        private const string ArabicLocale = "ar";

        public static string GetAttributeFromJson(string attribute, JObject jObj)
        {
            try
            {
                string locale = GetLocale(jObj);

                JToken attributeValue = jObj[attribute];

                if (attributeValue?.HasValues == true)
                {
                    return locale == ArabicLocale
                        ? attributeValue[ArabicLocale]?.ToString()
                        : attributeValue["default"]?.ToString();
                }

                return attributeValue?.ToString() ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static JObject SetAttributeFromJson(string attribute, string attValue, JObject jObj)
        {
            try
            {
                string locale = GetLocale(jObj);

                if (jObj[attribute]?.HasValues == true)
                {
                    if (locale == ArabicLocale)
                    {
                        jObj[attribute][ArabicLocale] = attValue;
                    }

                    jObj[attribute]["default"] = attValue;
                }
                else
                {
                    jObj[attribute] = attValue;
                }

                return jObj;
            }
            catch (Exception)
            {
                return jObj;
            }
        }

        private static string GetLocale(JObject jObj)
        {
            return jObj["locale"]?.ToString().ToLower() == ArabicLocale
                ? ArabicLocale
                : DefaultLocale;
        }
    }

}