using Commons.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    public partial class RPLRequest
    {
        public readonly string dateFormat = "dd / MM / yyyy";
        public string GraduationDateString
        {
            get
            {
                string umAlQuraString = "";
                if (this.GraduationDate == DateTime.MinValue)
                {
                    return umAlQuraString;
                }
                try
                {
                    umAlQuraString = DateTimeHelper.FromMiladiDateToUmAlQuraString(this.GraduationDate, dateFormat);
                }
                catch (Exception ex)
                {
                    umAlQuraString = null;
                }
                return umAlQuraString;
            }
        }

        public string StudyStartDateString
        {
            get
            {
                string umAlQuraString = "";
                if (this.StudyStartDate == DateTime.MinValue)
                {
                    return umAlQuraString;
                }
                try
                {
                    umAlQuraString = DateTimeHelper.FromMiladiDateToUmAlQuraString(this.StudyStartDate, dateFormat);
                }
                catch (Exception ex)
                {
                    umAlQuraString = null;
                }
                return umAlQuraString;
            }
        }
    }
}