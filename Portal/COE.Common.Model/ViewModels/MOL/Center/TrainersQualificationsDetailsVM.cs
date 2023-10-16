using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.CenterVMs
{
    public class TrainersQualificationsDetailsVM
    {
        public int CenterID { get; set; }
        public IEnumerable<TrainersQualificationsVM> TrainersQualifications { get; set; }
    }
}
