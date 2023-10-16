using COE.Common.Model.ViewModels.Security;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(ExcludedStudentMetaData))]
    public partial class ExcludedStudent : PagedResultBase
    {
 
        public string SearchIds { get; set; }
        public int[] SelectedUserIds { get; set; }
        public bool SelectAll { get; set; }
        public bool Selected { get; set; }
        public string College { get; set; }
        public List<ExcludedStudent> Items { get; set; }
     }
    class ExcludedStudentMetaData
    {
    }
}
