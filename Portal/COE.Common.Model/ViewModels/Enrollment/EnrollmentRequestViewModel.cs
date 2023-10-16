using COE.Common.Localization;
using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class EnrollmentRequestViewModel : BaseViewModel
    {
        public EnrollmentRequestViewModel()
        {
            EnrollmentRequestDetails = new List<EnrollmentRequestDetailViewModel>();
            Announcements = new List<AnnouncementViewModel>();
        }

        public Guid UserID { get; set; }
        public int CollegeSpecializationID { get; set; }
        public int? StageID { get; set; }
        public string RequestNumber { get; set; }

        public string EnrollmentCollegeName { get; set; }

        public string EnrollmentSpecializationName { get; set; }

        // Custom properties
        public string StageName { get; set; }
        public List<EnrollmentRequestDetailViewModel> EnrollmentRequestDetails { get; set; }
        public StudentProfileViewModel StudentProfile { get; set; }

        //public EnrollmentViewModel Enrollment { get; set; }
        //public int? EnrollmentId { get; set; }



        [Display(Name = "FirstCollege", ResourceType = typeof(AppResources))]
        public int? FirstCollegeId { get; set; }
        public int? FirstSpecializationId { get; set; }
        [Display(Name = "FirstSpecialization", ResourceType = typeof(AppResources))]
        public int? FirstCollegeSpecializationId { get; set; }

        public int? SecondCollegeId { get; set; }
        public int? SecondSpecializationId { get; set; }
        [Display(Name = "SecondSpecialization", ResourceType = typeof(AppResources))]
        public int? SecondCollegeSpecializationId { get; set; }

        public int? ThirdCollegeId { get; set; }
        public int? ThirdSpecializationId { get; set; }
        [Display(Name = "SecondSpecialization", ResourceType = typeof(AppResources))]
        public int? ThirdCollegeSpecializationId { get; set; }

        // Check Duplicate College Specialization
        public bool FirstCollegeSpecialization
        {
            get
            {
                bool isRequired = ((FirstCollegeSpecializationId != -1) &&
                    (FirstCollegeSpecializationId == SecondCollegeSpecializationId ||
                    FirstCollegeSpecializationId == ThirdCollegeSpecializationId));

                return isRequired;
            }
        }
        public bool SecondCollegeSpecialization
        {
            get
            {
                bool isRequired = ((SecondCollegeSpecializationId != -2) &&
                        (SecondCollegeSpecializationId == FirstCollegeSpecializationId ||
                        SecondCollegeSpecializationId == ThirdCollegeSpecializationId));
                return isRequired;
            }
        }
        public bool ThirdCollegeSpecialization
        {
            get
            {
                bool isRequired = ((ThirdCollegeSpecializationId != -3) &&
                   (ThirdCollegeSpecializationId == FirstCollegeSpecializationId ||
                   ThirdCollegeSpecializationId == SecondCollegeSpecializationId));
                return isRequired;
            }
        }

        // Check Is College Specialization Required
        public bool IsFirstCollegeRequired
        {
            get
            {
                return (FirstCollegeId == -1);
            }
        }
        public bool IsFirstSpecializationRequired
        {
            get
            {
                return (FirstCollegeSpecializationId == -1);
            }
        }
        public bool IsSecondSpecializationRequired
        {
            get
            {
                bool isRequired = (SecondCollegeId.HasValue && SecondCollegeId != -1 && SecondCollegeSpecializationId.Value == -2);
                return isRequired;
            }
        }
        public bool IsThirdSpecializationRequired
        {
            get
            {
                bool isRequired = (ThirdCollegeId.HasValue && ThirdCollegeId != -1 && ThirdCollegeSpecializationId.Value == -3);
                return isRequired;
            }
        }

        // Announcements and Bulletins
        public List<AnnouncementViewModel> Announcements { get; set; }
        public int StatusID { get; set; }
    }
}
