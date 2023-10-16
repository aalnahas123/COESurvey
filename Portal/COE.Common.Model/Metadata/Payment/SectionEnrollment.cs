using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model
{
    [MetadataType(typeof(SectionEnrollmentMetaData))]
    public partial class SectionEnrollment
    {
        public string ExceedRepeatLimit
        {
            get
            {
                return CalculatedRepeation == "NotPaid" ? "Yes" : "No";
            }
        }

        [Display(Name = "AttendenceStatus", ResourceType = typeof(DCSResources))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResources))]
        public int AttendenceStatusId { get; set; }

        public bool IsSelected { get; set; }


        [Display(Name = "TraineeName", ResourceType = typeof(DCSResources))]
        public string ViewTraineeName { get; set; }

        [Display(Name = "TraineeStatus", ResourceType = typeof(DCSResources))]
        public string ViewTraineeStatus { get; set; }

        [Display(Name = "NationalId", ResourceType = typeof(DCSResources))]
        public string ViewNationalId { get; set; }

        public string AttendenceStatusValue { get; set; }

        public Guid TraineeId { get; set; }
        public int ToSectionID { get; set; }
        public int EnrolmentId { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public int CollegeId { get; set; }
        public string SectionCode { get; set; }
        public string ToSectionCode { get; set; }

        public bool AllowEdit { get; set; } = true;

        public int SessionID { get; set; }
    }

    public class SectionEnrollmentMetaData
    {
        [Display(Name = "MD_Section", ResourceType = typeof(PaymentResource))]
        public int SectionID { get; set; }
        [Display(Name = "MD_ExceedRepeatLimit", ResourceType = typeof(PaymentResource))]
        public string ExceedRepeatLimit { get; }

    }
}