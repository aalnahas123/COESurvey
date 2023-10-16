using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Alert
{
    public class AlertViewModel
    {
        public int ID { get; set; }
        public System.Guid UserDisplayID { get; set; }
        public int StageID { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public int AlertTypeID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string StageName { get; set; }
        public string StageNameAr { get; set; }
        public string AlertTypeName { get; set; }
        public string AlertTypeNameAr { get; set; }
        public string AlertTypeCssClass { get; set; }
        public bool AlertTypeClickable { get; set; }
        public string AlertTypeIconClass { get; set; }

    }
}
