using COE.Common.Localization;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model
{
    [MetadataType(typeof(AspNetUsersMetaData))]
    public partial class AspNetUsers : CommonMetaData
    {
        public bool IsSelected { get; set; }
        public int EnrollmentId { get; set; }
        internal class AspNetUsersMetaData
        {
            [Display(Name = "AspNetUsers_FullName", ResourceType = typeof(MetaData))]
            public string FullName { get; set; }

            [Display(Name = "AspNetUsers_NationalId", ResourceType = typeof(MetaData))]
            public string NationalId { get; set; }
        }
    }
}