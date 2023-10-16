namespace COE.Common.Model.ViewModels.Enrollment
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            StudentIdentity = new StudentIdentityViewModel();
            StudentInfo = new StudentInformationViewModel();
            StudentSchoolInfo = new StudentSchoolInformationViewModel();
            StudentChoices = new StudentChoicesViewModel();
        }
        // 1 :- Yakeen Input (NationalID , BirthYear) + (Student MobileNumber , Student Email in case the registration by college admin)
        public StudentIdentityViewModel StudentIdentity { get; set; }
        // 2 :- Personal Information (Integration wiht Yakeen) === > (SQL Student Profile Table)
        public StudentInformationViewModel StudentInfo { get; set; }
        // 3 :- HighSchool Information (Integration wiht NOOR & Qiyas) === > (SQL Student Profile Table)
        public StudentSchoolInformationViewModel StudentSchoolInfo { get; set; }
        // 4 :- Student Desiers Information === > (SQL Enrollment Request Detail Table)
        public StudentChoicesViewModel StudentChoices { get; set; }
    }
}
