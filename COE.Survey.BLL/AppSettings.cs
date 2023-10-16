// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="SURE International Technology">
//   Copyright © 2015 All Right Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace COE.Survey.BLL
{
    #region

    using System.Configuration;

    using Commons.Framework.Configuration;
    using Commons.Framework.Extensions;
    using System;

    #endregion

    /// <summary>
    ///     The app settings.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        ///     Get App Id
        /// </summary>
        public const string CommonApplicationId = "CommonSettings";

        /// <summary>
        ///     The eservices id.
        /// </summary>
        public const string EservicesId = "Eservices";

        /// <summary>
        /// The OnlineUsers id
        /// </summary>
        public const string OnlineUsersId = "OnlineUsers";

        /// <summary>
        /// The deferral request id
        /// </summary>
        public const string DeferralRequestId = "DeferralRequest";

        /// <summary>
        ///     The users mgmt.
        /// </summary>
        public const string UsersMgmt = "UsersMgmt";

        /// <summary>
        ///     The cache duration in minutes.
        /// </summary>
        public static readonly int CacheDurationInMinutes =
            ConfigurationManager.AppSettings["NOR:CacheDurationInMinutes"].To(10);

        /// <summary>
        /// The application url.
        /// </summary>
        public static string ApplicationUrl => SystemSettingsHelper.Get<string>("ApplicationUrl", EservicesId);

        /// <summary>
        ///     Gets the max height.
        /// </summary>
        public static int AttachmentsAllowedHeight
            => SystemSettingsHelper.Get<int>("AttachmentsAllowedHeight", CommonApplicationId);

        /// <summary>
        ///     The attachments allowed types.
        /// </summary>
        public static string AttachmentsAllowedTypes
            => SystemSettingsHelper.Get<string>("AttachmentsAllowedTypes", CommonApplicationId);

        /// <summary>
        ///     Gets the max width.
        /// </summary>
        public static int AttachmentsAllowedWidth
            => SystemSettingsHelper.Get<int>("AttachmentsAllowedWidth", CommonApplicationId);

        /// <summary>
        ///     Gets the max attachment size.
        /// </summary>
        public static int AttachmentsMaxSize => SystemSettingsHelper.Get<int>("AttachmentsMaxSize", CommonApplicationId);

        /// <summary>
        ///     Gets the attachments path.
        /// </summary>
        public static string AttachmentsPath => SystemSettingsHelper.Get<string>("AttachmentsPath", CommonApplicationId);

        /// <summary>
        /// The contact us email.
        /// </summary>
        public static string ContactUsEmail => SystemSettingsHelper.Get<string>("ContactUsEmail", CommonApplicationId);

        /// <summary>
        ///     The date format.
        /// </summary>
        public static string DateFormat => SystemSettingsHelper.Get<string>("DateFormat", CommonApplicationId);

        /// <summary>
        ///     Gets the default size of the pager page.
        /// </summary>
        public static int DefaultPagerPageSize
            => SystemSettingsHelper.Get<int>("DefaultPagerPageSize", CommonApplicationId);

        public static int DefaultPageSize
            => 40;

        /// <summary>
        /// The delay notice period.
        /// </summary>
        public static int DelayNoticePeriod => SystemSettingsHelper.Get<int>("DelayNoticePeriod", CommonApplicationId);

        /// <summary>
        ///     The disable email notifications.
        /// </summary>
        public static bool DisableEmailNotifications
            => SystemSettingsHelper.Get<bool>("DisableEmailNotifications", CommonApplicationId);

        /// <summary>
        ///     The disable sms notifications.
        /// </summary>
        public static bool DisableSMSNotifications
            => SystemSettingsHelper.Get<bool>("DisableSMSNotifications", CommonApplicationId);

        /// <summary>
        ///     The email from address.
        /// </summary>
        public static string EmailFromAddress
            => SystemSettingsHelper.Get<string>("EmailFromAddress", CommonApplicationId);

        /// <summary>
        ///     The email from name.
        /// </summary>
        public static string EmailFromName => SystemSettingsHelper.Get<string>("EmailFromName", CommonApplicationId);

        /// <summary>
        ///     The email subject.
        /// </summary>
        public static string EmailSubject => SystemSettingsHelper.Get<string>("EmailSubject", CommonApplicationId);

        /// <summary>
        ///     The is smtp authenticated.
        /// </summary>
        public static bool IsSmtpAuthenticated
            => SystemSettingsHelper.Get<bool>("IsSmtpAuthenticated", CommonApplicationId);

        /// <summary>
        ///     The login url.
        /// </summary>
        public static string LoginUrl => SystemSettingsHelper.Get<string>("LoginUrl", CommonApplicationId);

        /// <summary>
        ///     Gets the portal url.
        /// </summary>
        public static string PortalUrl => SystemSettingsHelper.Get<string>("PortalUrl", CommonApplicationId);

        /// <summary> 
        ///     Gets the Integration Handler Url.
        /// </summary>
        public static string IntegrationHandlerUrl => SystemSettingsHelper.Get<string>("IntegrationHandlerUrl", EservicesId);
        /// <summary>
        /// The reminder notice period.
        /// </summary>
        public static int ReminderNoticePeriod
            => SystemSettingsHelper.Get<int>("ReminderNoticePeriod", CommonApplicationId);

        /// <summary>
        ///     The sadad service code.
        /// </summary>
        public static string SadadServiceCode => SystemSettingsHelper.Get<string>("SadadServiceCode", EservicesId);

        /// <summary>
        ///     The sadad service password.
        /// </summary>
        public static string SadadServicePassword
            => SystemSettingsHelper.Get<string>("SadadServicePassword", EservicesId);

        /// <summary>
        ///     The sadad service user name.
        /// </summary>
        public static string SadadServiceUserName
            => SystemSettingsHelper.Get<string>("SadadServiceUserName", EservicesId);

        /// <summary>
        ///     Save Image To Database Flag
        /// </summary>
        public static bool SaveFilesToDatabase
            => SystemSettingsHelper.Get<bool>("SaveFilesToDatabase", CommonApplicationId);

        /// <summary>
        ///     The send notifications using web service.
        /// </summary>
        public static bool SendNotificationsUsingWebService
            => SystemSettingsHelper.Get<bool>("SendNotificationsUsingWebService", EservicesId);

        /// <summary>
        ///     The simulate active directory.
        /// </summary>
        public static bool SimulateActiveDirectory
            => ConfigurationManager.AppSettings["SimulateActiveDirectory"].To<bool>();

        /// <summary>
        ///     The simulate mci.
        /// </summary>
        public static bool SimulateMci => ConfigurationManager.AppSettings["SimulateMci"].To<bool>();

        /// <summary>
        ///     The simulate sadad.
        /// </summary>
        public static bool SimulateSadad => ConfigurationManager.AppSettings["SimulateSadad"].To<bool>();

        /// <summary>
        ///     The smtp enable ssl.
        /// </summary>
        public static bool SmtpEnableSSL => SystemSettingsHelper.Get<bool>("SmtpEnableSSL", CommonApplicationId);

        /// <summary>
        ///     The smtp password.
        /// </summary>
        public static string SmtpPassword => SystemSettingsHelper.Get<string>("SmtpPassword", CommonApplicationId);

        /// <summary>
        ///     The smtp port.
        /// </summary>
        public static int SmtpPort => SystemSettingsHelper.Get<int>("SmtpPort", CommonApplicationId);

        /// <summary>
        ///     The smtp server.
        /// </summary>
        public static string SmtpServer => SystemSettingsHelper.Get<string>("SmtpServer", CommonApplicationId);

        /// <summary>
        ///     The smtp user name.
        /// </summary>
        public static string SmtpUserName => SystemSettingsHelper.Get<string>("SmtpUserName", CommonApplicationId);

        /// <summary>
        ///     Gets the date format.
        /// </summary>
        public static string TimeFormat => SystemSettingsHelper.Get<string>("TimeFormat", CommonApplicationId);

        /// <summary>
        ///     The user profile default image url.
        /// </summary>
        public static string UserProfileDefaultImageUrl
            => SystemSettingsHelper.Get<string>("UserProfileDefaultImageUrl", CommonApplicationId);

        /// <summary>
        ///     The user profile image url.
        /// </summary>
        public static string UserProfileImageUrl
            => SystemSettingsHelper.Get<string>("UserProfileImageUrl", CommonApplicationId);

        /// <summary>
        ///     The verification code max attempts.
        /// </summary>
        public static int VerificationCodeMaxAttempts
            => SystemSettingsHelper.Get<int>("VerificationCodeMaxAttempts", CommonApplicationId);

        /// <summary>
        ///     Max Login Attempts Before Displaying Captcha.
        /// </summary>
        public static int VerificationCodeValidHours
            => SystemSettingsHelper.Get<int>("VerificationCodeValidHours", UsersMgmt);

        /// <summary>
        /// The verification code valid minutes.
        /// </summary>
        public static int VerificationCodeValidMinutes
            => SystemSettingsHelper.Get<int>("VerificationCodeValidMinutes", UsersMgmt);

        /// <summary>
        ///     The send notifications using web service.
        /// </summary>
        public static string SubmitEnrollmentRequestStartDate
            => SystemSettingsHelper.Get<string>("EnrollmentSubmitRequestFrom", EservicesId);

        /// <summary>
        ///     The send notifications using web service.
        /// </summary>
        public static string SubmitEnrollmentRequestEndDate
            => SystemSettingsHelper.Get<string>("EnrollmentSubmitRequestTo", EservicesId);

        /// <summary>
        ///     Submit Change Status Request StartDate.
        /// </summary>
        public static string ChangeStatusRequestSubmitStartDate
            => SystemSettingsHelper.Get<string>("ChangeStatusSubmitRequestFrom", EservicesId);

        /// <summary>
        ///     Submit Change Status Request EndDate.
        /// </summary>
        public static string ChangeStatusSubmitRequestEndDate
            => SystemSettingsHelper.Get<string>("ChangeStatusSubmitRequestTo", EservicesId);


        public static int TransferReqeustValidBeforeDaysOfTermEndDate
            => SystemSettingsHelper.Get<int>("TransferReqeustValidBeforeDaysOfTermEndDate", EservicesId);

        public static byte DefaultMinimumCollectionPercentageMinVal
            => SystemSettingsHelper.Get<byte>("DefaultMinimumCollectionPercentageMinVal", EservicesId);
        public static byte DefaultMinimumCollectionPercentageMaxVal
            => SystemSettingsHelper.Get<byte>("DefaultMinimumCollectionPercentageMaxVal", EservicesId);
        public static byte DefaultMediumCollectionPercentageMinVal
            => SystemSettingsHelper.Get<byte>("DefaultMediumCollectionPercentageMinVal", EservicesId);
        public static byte DefaultMediumCollectionPercentageMaxVal
            => SystemSettingsHelper.Get<byte>("DefaultMediumCollectionPercentageMaxVal", EservicesId);
        public static byte DefaultHighestCollectionPercentageMinVal
            => SystemSettingsHelper.Get<byte>("DefaultHighestCollectionPercentageMinVal", EservicesId);
        public static byte DefaultHighestCollectionPercentageMaxVal
            => SystemSettingsHelper.Get<byte>("DefaultHighestCollectionPercentageMaxVal", EservicesId);

        /// <summary>
        ///     The attachments allowed types.
        /// </summary>
        public static string TermsOfService
            => SystemSettingsHelper.Get<string>("TermsOfService", UsersMgmt);

        /// <summary>
        ///  The Student Counselor Escalation Days period
        /// </summary>
        public static int StudentCounselorEscalationDaysVal
            => SystemSettingsHelper.Get<int>("StudentCounselorEscalationDays", EservicesId);

        public static int NewCollegeContractSpecialistEscalationDaysVal
            => SystemSettingsHelper.Get<int>("NewCollegeContractSpecialistEscalationDays", EservicesId);

        public static int CurrentCollegeContractSpecialistEscalationDaysVal
            => SystemSettingsHelper.Get<int>("CurrentCollegeContractSpecialistEscalationDays", EservicesId);
        /// <summary>
        ///     Gets the online student user name (the AD user that acting on behalf of ASP membership student user).
        /// </summary>
        //public static string OnlineStudentUser => SystemSettingsHelper.Get<string>("OnlineStudentUser", UsersMgmt);

        /// <summary>
        ///     Gets the email body of Withdraw RequestReview task.
        /// </summary>
        public static string WithdrawRequestReviewEmailBody => SystemSettingsHelper.Get<string>("WithdrawRequestReviewEmailBody", EservicesId);

        /// <summary>
        ///     Gets the email subject of Withdraw RequestReview task.
        /// </summary>
        public static string WithdrawRequestReviewEmailSubject => SystemSettingsHelper.Get<string>("WithdrawRequestReviewEmailSubject", EservicesId);

        /// <summary>
        ///     Gets the email body of Withdraw CloseRequest task.
        /// </summary>
        public static string WithdrawCloseRequestEmailBody => SystemSettingsHelper.Get<string>("WithdrawCloseRequestEmailBody", EservicesId);

        /// <summary>
        ///     Gets the email subject of Withdraw CloseRequest task.
        /// </summary>
        public static string WithdrawCloseRequestEmailSubject => SystemSettingsHelper.Get<string>("WithdrawCloseRequestEmailSubject", EservicesId);

        /// <summary>
        ///     Gets the email body of Withdraw Notify Student With EndWithdraw task.
        /// </summary>
        public static string WithdrawNotifyStudentForEndWithdrawEmailBody => SystemSettingsHelper.Get<string>("WithdrawNotifyStudentForEndWithdrawEmailBody", EservicesId);

        /// <summary>
        ///     Gets the email subject of Withdraw Notify Student With EndWithdraw task.
        /// </summary>
        public static string WithdrawNotifyStudentForEndWithdrawEmailSubject => SystemSettingsHelper.Get<string>("WithdrawNotifyStudentForEndWithdrawEmailSubject", EservicesId);

        /// <summary>
        ///     Gets the email body of Withdraw Notify Student With EndWithdraw task.
        /// </summary>
        public static string WithdrawNotifyStudentForStartingWithdrawEmailBody => SystemSettingsHelper.Get<string>("WithdrawNotifyStudentForStartingWithdrawEmailBody", EservicesId);

        /// <summary>
        ///     Gets the email subject of Withdraw Notify Student With EndWithdraw task.
        /// </summary>
        public static string WithdrawNotifyStudentForStartingWithdrawEmailSubject => SystemSettingsHelper.Get<string>("WithdrawNotifyStudentForStartingWithdrawEmailSubject", EservicesId);



        public static string ViewFlowUrl
    => SystemSettingsHelper.Get<string>("ViewFlowUrl", EservicesId);
        public static string OnlineUserStudent
            => SystemSettingsHelper.Get<string>("Student", OnlineUsersId);

        public static string OnlineUserCollegeAdmin
            => SystemSettingsHelper.Get<string>("CollegeAdmin", OnlineUsersId);

        public static string OnlineUserCollegeStudentCounselor
            => SystemSettingsHelper.Get<string>("CollegeStudentCounselor", OnlineUsersId);

        public static string OnlineUserCollegeStudentServices
            => SystemSettingsHelper.Get<string>("CollegeStudentServices", OnlineUsersId);

        public static string OnlineUserProvider
            => SystemSettingsHelper.Get<string>("Provider", OnlineUsersId);

        /// <summary>
        /// Gets the value of deferral request PeriodInWeeks to calculate field "IsAfter3rdWee".
        /// </summary>

        public static byte PeriodInWeeksValue
            => SystemSettingsHelper.Get<byte>("PeriodInWeeks", DeferralRequestId);

        /// <summary>
        /// Gets the value of deferral request reason "Medical".
        /// </summary>

        public static byte DeferralReasonMedicalValue
            => SystemSettingsHelper.Get<byte>("DeferralReasonMedical", DeferralRequestId);

        /// <summary>
        /// Gets the value of deferral request reason "Others".
        /// </summary>
        public static byte DeferralReasonOthersValue
            => SystemSettingsHelper.Get<byte>("DeferralReasonOthers", DeferralRequestId);

        public static string DeferralRequestController
            => SystemSettingsHelper.Get<string>("DeferralRequestController", EservicesId);

        public static string GroupCollegeAdmin
            => SystemSettingsHelper.Get<string>("GroupCollegeAdmin", EservicesId);

        public static string GroupContractManager
            => SystemSettingsHelper.Get<string>("GroupContractManager", EservicesId);

        public static string GroupContractSpecialist
            => SystemSettingsHelper.Get<string>("GroupContractSpecialist", EservicesId);

        public static int DismissReuqestContractSpecialistEscalationDaysVal
    => SystemSettingsHelper.Get<int>("DismissReuqestContractSpecialistEscalationDaysVal", EservicesId);

        public static int DismissReuqestStudentEscalationDaysVal
=> SystemSettingsHelper.Get<int>("DismissReuqestStudentEscalationDaysVal", EservicesId);

        public static int EnrollmentStatisticContractSpecialistEscalationDaysVal
=> SystemSettingsHelper.Get<int>("EnrollmentStatisticContractSpecialistEscalationDaysVal", EservicesId);


        /// <summary>
        /// Gets the path of graduation certification templates word file path to export it as PDF.
        /// </summary>
        public static string ExportGraduationCertificationTemplateFilesPath
            => SystemSettingsHelper.Get<string>("ExportGraduationCertificationTemplateFilesPath", EservicesId);

        /// <summary>
        /// Gets the path of graduation certification temp file path to read its content to download it.
        /// </summary>
        public static string ExportGraduationCertificationTempFilePath
            => SystemSettingsHelper.Get<string>("ExportGraduationCertificationTempFilePath", EservicesId);


        public static string RequestNumberCurrentDate
        => SystemSettingsHelper.Get<string>("RequestNumberCurrentDate", EservicesId);

        public static string DismissRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("DismissRequestNumberPrefix", EservicesId);

        public static int DismissRequestNumberCounter
        => SystemSettingsHelper.Get<int>("DismissRequestNumberCounter", EservicesId);

        public static string DeferralRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("DeferralRequestNumberPrefix", EservicesId);

        public static int DeferralRequestNumberCounter
        => SystemSettingsHelper.Get<int>("DeferralRequestNumberCounter", EservicesId);

        public static string TransferRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("TransferRequestNumberPrefix", EservicesId);

        public static int TransferRequestNumberCounter
        => SystemSettingsHelper.Get<int>("TransferRequestNumberCounter", EservicesId);

        public static string WithdrawRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("WithdrawRequestNumberPrefix", EservicesId);

        public static int WithdrawRequestNumberCounter
        => SystemSettingsHelper.Get<int>("WithdrawRequestNumberCounter", EservicesId);

        public static string EnrollmentStatisticsRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("EnrollmentStatisticsRequestNumberPrefix", EservicesId);

        public static int EnrollmentStatisticsRequestNumberCounter
        => SystemSettingsHelper.Get<int>("EnrollmentStatisticsRequestNumberCounter", EservicesId);

        public static string StudentsDisabilityRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("StudentsDisabilityRequestNumberPrefix", EservicesId);

        public static int StudentsDisabilityRequestNumberCounter
        => SystemSettingsHelper.Get<int>("StudentsDisabilityRequestNumberCounter", EservicesId);

        public static string ReinstateRequestNumberPrefix
        => SystemSettingsHelper.Get<string>("ReinstateRequestNumberPrefix", EservicesId);

        public static int ReinstateRequestNumberCounter
        => SystemSettingsHelper.Get<int>("ReinstateRequestNumberCounter", EservicesId);

        public static bool ApplicantsStatusChangeEnabled
    => SystemSettingsHelper.Get<bool>("ApplicantsStatusChangeEnabled", EservicesId);

        public static bool ReinstateRequestEnabled
        => SystemSettingsHelper.Get<bool>("ReinstateRequestEnabled", EservicesId);

        public static bool ReinstateRequestContractSpecialistEnabled
=> SystemSettingsHelper.Get<bool>("ReinstateRequestContractSpecialistEnabled", EservicesId);

        public static bool TransferRequestContractSpecialistEnabled
        => SystemSettingsHelper.Get<bool>("TransferRequestContractSpecialistEnabled", EservicesId);

        public static int TermDaysToStartAlert
        => SystemSettingsHelper.Get<int>("TermDaysToStartAlert", EservicesId);

    }
}