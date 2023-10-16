using COE.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.ViewModels.Enrollment
{
    public class StudentProfileViewModel : BaseViewModel
    {
        public Guid UserId { get; set; }
        public string NationalId { get; set; }
        public string YearOfBirth { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string FirstNameAr { get; set; }
        public string SecondNameAr { get; set; }
        public string ThirdNameAr { get; set; }
        public string FourthNameAr { get; set; }
        public string BirthDate { get; set; }
        public bool IsMale { get; set; }
        public int SchoolGraduationYearId { get; set; }
        public int SchoolAreaId { get; set; }
        public int SchoolCityId { get; set; }
        public int SchoolTypeId { get; set; }
        public string SchoolName { get; set; }
        public decimal StudentGPA { get; set; }
        public int StudentMeasure { get; set; }
        public int StudentAchievement { get; set; }
        public int WorkStatusId { get; set; }
        public bool IsJoinedBefore { get; set; }
        public bool IsUniversityGraduated { get; set; }
        public DateTime JoinDate { get; set; }
        public string Motivation { get; set; }
        public int TVTCStudentNo { get; set; }
        public int? TVTCStatusID { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(EnrollmentResources))]
        public string FullNameAr { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(EnrollmentResources))]
        public string FullNameEn { get; set; }
        public string FullName { get; set; }
        public string GenderName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public string SchoolTypeName { get; set; }
        public int? StudentsDisabilityLevelId { get; set; }
        public string StudentsDisabilityLevelName { get; set; }
        public string ActivationCode { get; set; }

        public string CollegeName { get; set; }

        public string SpecializationName { get; set; }

        // Yakeen Flags
        public bool? FirstNameIsFromYakeen { get; set; }
        public bool? SecondNameIsFromYakeen { get; set; }
        public bool? ThirdNameIsFromYakeen { get; set; }
        public bool? FourthNameIsFromYakeen { get; set; }
        public bool? FirstNameArIsFromYakeen { get; set; }
        public bool? SecondNameArIsFromYakeen { get; set; }
        public bool? ThirdNameArIsFromYakeen { get; set; }
        public bool? FourthNameArIsFromYakeen { get; set; }
        public bool? BirthDateIsFromYakeen { get; set; }
        public bool? IsMaleIsFromYakeen { get; set; }
        public DateTime? LastUpdatedFromYakeen { get; set; }
    }

}
