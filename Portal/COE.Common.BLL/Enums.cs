namespace COE.Common.BLL
{
    public enum Status
    {
        Active = 1,
        InActive = 2,
        Draft = 3,
        Published = 4,
        Calculated = 5
    }
    public enum CollegeType
    {
        InternationalTechnicalColleges = 1,
        StrategicPartnership = 2,
        Center = 7

    }
    public enum Providers
    {
        Centers = 16
    }
    public enum CollegeTermType
    {
        Semester = 1,
        Trimester = 2,
        Quarter = 3,
        Full = 4,
        Batch = 5
    }
    public enum ProgramsType
    {
        ITC = 1,
        SP = 2,
        ShortCourse = 3,
        OSH = 7,

    }
    public enum BatchServicePeriods
    {
        Registration = 1,
        Admission = 2,
        Study = 3
    }
    public enum CollegeLevel
    {
        Foundation = 1,
        Academic = 2,
        Diploma = 3,
        AssociateDiploma = 4,
        ShortCourse = 5
    }
    public enum UserSource
    {
        ActiveDirectory = 1,
        Online = 2,
    }
    public enum RowStaus
    {
        active = 1,
        success = 2,
        warning = 3,
        danger = 4
    }
    public enum EnrollmentRequestStages
    {
        ApplicationHasBeenReceived = 1,
        ConditionalAcceptance = 2,
        WaitingList = 3,
        AcceptedEnrolled = 4,
        Rejected = 5,
        Cancel = 6,
        Admitted = 52,
        ExpiredOffer = 53,
        ApplicationCancelledDueToRegistrationPeriod = 65
    }
    public enum EnrollmentRequestDetailStages
    {
        ApplicationHasBeenReceived = 7,
        ConditionalAcceptance = 8,
        WaitingList = 9,
        AcceptedEnrolled = 10,
        Rejected = 11,
        Cancel = 12,
        Admitted = 54,
        ExpiredOffer = 55,
        ApplicationCancelledDueToRegistrationPeriod = 66
    }
    public enum EnrollmentStages
    {
        AcceptedEnrolled = 13,
        NoShow = 14,
        Deferral = 15,
        Dismissed = 16,
        DropoutWithdrawal = 17,
        Graduated = 18,
        Transfer = 59,
        GraduatedFoundation = 56,
        GraduatedAssociateDiploma = 57,
        GraduatedDiploma = 58,
        AcademicProbation = 159,
        GraduatedShortCourses = 160,
        Continues = 161,
        //GraduatedAssociateDiploma = 162,
        TransferVistor = 165,
        Incomplete = 180
    }

    public enum EnrollmentStatus
    {
        Active = 1,
        InActive = 2,
    }
    public enum LabelStyle
    {
        Default = 1,
        Primary = 2,
        Info = 3,
        Success = 4,
        Danger = 5,
        Warning = 6
    }

    public enum AttachmentType
    {
        WithdrawReasonAttached = 2,
        DeferralReasonAttached = 3,
        DismissReasonAttached = 10,
        TransferReasonAttached = 11,
        StudentsDisabilityRequestAttached = 12,
        ProviderLogo = 13,
        SponserLogo = 14,
        CollegeLogo = 24,
        BondAttachment = 25,
        ContractAttachment = 18,
        InvoiceRequestAttachment = 26,
        StudentIdentityAttachment = 27,
        StudentHighSchoolCertificateAttachment = 28,
        StudentEnglishCertificateAttachment = 29,
        RPLApprovalRequestAttachment = 30,
        AcademicRecordAttachment = 31,
        CertificateEquivalenceLetterAttachment = 32,
        EmployerLetterAttachment = 33,
        ProgramDescAttachment = 34,
        ExperienceCertificateAttachment = 35,
        CVAttachment = 36,
        QualificationApprovalRequestAttachment = 37,
        CenterApprovalRequestAttachment = 44,
        PassportAttachment = 45,
        CenterGeneralLicense = 48,
        CenterPrivateLicense = 49,
        CenterTrainerCV = 50,
        AcademicDegreeCertificateAttachment = 51,
        ComplaintRequestAttached = 52,

        RPLExamRequestGraduationCertificateAttachment = 53,
        RPLExamRequestAcademicRecordAttachment = 54,
        RPLExamRequestEducationalEquationAttachment = 55,
        RPLExamRequestETrainingAttendanceAttachment = 56,
        RPLExamRequestLetterOrexperienceCertificateAttachment = 57,
        RPLExamRequestSaudiCouncilEngineersAttachment = 58,
        RPLExamRequestSaudiCommissionHealthSpecialtiesAttachment = 59,
        RPLExamRequestStudentNationalIDAttachment = 60,

        RPLExamBookingInvoice = 61,
        RPLExamBookingCreditNote = 62,
        RPLExamBookingInvoiceSignedXML = 64
    }

    public enum WorkflowProcessNames
    {
        WithdrawRequest = 1,
        DismissedRequest = 2,
        TransferRequest = 3,
        DeferralRequest = 4,
        ChangeStatusRequest = 5,
        EnrollmentStatisticsRequest = 6,
        ChangeEnrollmentCurrentStatus = 7,
        ReinstateRequest = 8,
        StudentDisabilityRequest = 9,
        InvoiceRequest = 10,
        RPLApprovalRequest = 11,
        QualificationApprovalRequest = 12,

        CenterRequest = 16,
        ComplaintsRequest = 19,
    }

    public enum WorkflowDecision
    {
        Submit = 1,
        Approve = 2,
        Reject = 3,
        Resubmit = 4,
        Cancel = 5,
        Update = 6,
        Objection = 7,
        Resubmit2 = 8,
        AutomaticallyEscalated = 9
    }
    public enum WithdrawRequestStages
    {
        WithdrawRequestIsSubmitted = 19,
        StudentCounselorReview = 20,
        StudentServicesReview = 21,
        CloseWithdrawRequest = 22,
        CancelWithdrawRequest = 23
    }

    public enum WithdrawRequestNextStep
    {
        StudentCounselorReviewRequest,
        StudentServiceCloseRequest,
        EndProcess
    }

    public enum TransferRequestNextStep
    {
        CurrentCollegeContractSpecialistReview,
        CurrentCollegeContractManagerReview,
        NewCollegeContractSpecialistReview,
        NewCollegeContractManagerReview,
        NewCollegeAdminReview,
        ApproveTransferRequest,
        RejectTransferRequest,
        CancelTransferRequest,
        EndProcess
    }

    public enum TransferRequestStages
    {
        TransferRequestIsSubmitted = 37,
        CurrentCollegeContractSpecialistReview = 38,
        CurrentCollegeContractManagerReview = 39,
        NewCollegeContractSpecialistReview = 40,
        NewCollegeContractManagerReview = 41,
        NewCollegeAdminReview = 42,
        ApproveTransferRequest = 43,
        RejectTransferRequest = 44,
        CancelTransferRequest = 45
    }

    public enum DeferralRequestStages
    {
        StudentSubmiteRequest = 24,
        StudentUpdateRequest = 25,
        CollegeAdminReviewRequest = 26,
        ContractSpecialistReviewRequest = 27,
        CloseDeferralRequest = 29
    }

    public enum DismissRequestStages
    {
        CollegeAdminSubmitRequest = 28,
        StudentReview = 30,
        ContractSpecialistReview = 31,
        ContractManagerReview = 32
    }

    public enum EnrollmentStatisticRequestStages
    {
        Draft = 46,
        CollegeAdminSubmitRequest = 47,
        ContractSpecialistReview = 48,
        SentBackToCollegeAdmin = 49,
        Approved = 50,
        Cancelled = 51
    }

    public enum ChangeStatusRequestStages
    {
        CollegeAdminSubmitRequest = 60,
        CollegeAdminUpdateRequest = 61,
        ContractSpecialistReview = 62,
        EndProccess = 63
    }
    public enum ReinstateRequestStages
    {
        RequestIsSubmitted = 68,
        ContractSpecialistReview = 69,
        Approved = 70,
        Rejected = 71,
        Cancelled = 72,
        SentBack = 73
    }

    public enum StudentsDisabilityRequestStages
    {
        RequestIsSubmitted = 78,
        StudentAffairsReview = 79,
        Cancelled = 80,
        EndProcess = 81,
        StudentAffairsManagerReview = 82
    }

    public enum DeferralRequestNextStep
    {
        StudentSubmitRequest,
        CollegeAdminReviewRequest,
        ContractSpecialistReviewRequestAndDocuments,
        EndProcess
    }
    public enum DismissRequestNextStep
    {
        CollegeAdminSubmitRequest,
        ContractSpecialistReviewRequest,
        EndProcess
    }
    public enum EnrollmentStatisticRequestNextStep
    {
        CollegeAdminSubmitRequest,
        ContractSpecialistReviewRequest,
        EndProcess
    }

    public enum ChangeStatusRequestNextStep
    {
        CollegeAdminUpdateRequest,
        ContractSpecialistReview,
        EndProccess
    }

    public enum StudentsDisabilityRequestNextStep
    {
        SubmitRequest,
        StudentAffairsReviewRequest,
        EndProcess
    }

    public enum ComplaintCommonRequestStages
    {
        SubmitComplaint = 170,
        TraineeServicesSupervisorReview = 171,
        TraineeServicesManagerReview = 172,
        TraineeUpdate = 173,
        TraineeObjection = 174,
        ProgramSupervisorReview = 175,
        ProgramManagerReview = 176,
        AcceptedComplaint = 177,
        RejectedComplaint = 178,
        CanceledComplaint = 179
    }

    /// <summary>
    /// The asp net role name enumeration
    /// </summary>
    public enum AspNetRolesNames
    {
        SystemAdmin = 1,
        CollegeAdmin = 2,
        StudentAffair = 3,
        ContractSpecialist = 4,
        Provider = 5,
        Education = 6,
        ContractManager = 7,
        TopManagement = 8,
        StudentCounselor = 9,
        StudentServices = 10,
        StudentAffairManager = 12,
        //InvoiceCreator = 18,
        InvoiceReviewer = 20,
        EducationSupervisor = 15,
        EducationManager = 16,
        InvoiceApprover = 21,
        StudentReportView = 22,
        AwardingBody = 23,
        SOCStudentAffairs = 25,
        SOCRegistrar = 26,
        Lecture = 55,
        Registerer = 56,
        CoeRegisterer = 26,

        TraineeServiceSupervisor = 1003,
        TraineeServiceManager = 1004,
        GradingSupervisor = 1005,
        GradingManager = 1006,

        FinanceAdmins = 13,
        TestCenters = 14,
    }
    public enum CardUserType
    {
        AllStudents = 1,
        HasCards = 2,
        HasNoCards = 3,
        Rejected = 4,
        Transferred = 5
    }
    public enum InvoiceRequestStages
    {
        RequestIsSubmitted = 91,
        WaitingInvoiceReview = 92,
        WaitingInvoiceApproval = 93,
        Approved = 94,
        Rejected = 95,
        Cancelled = 96
    }
    public enum RPLApprovalRequestStages
    {
        Draft = 97,
        RequestIsSubmitted = 98,
        EducationSupervisorReview = 99,
        EducationManagerReview = 100,
        SentBackToCandidate = 101,
        Approved = 102,
        Rejected = 103,
        Cancelled = 104,
        WaitingForPayment = 112,
    }
    public enum QualificationApprovalRequestStages
    {
        Draft = 105,
        RequestIsSubmitted = 106,
        CollegeAdminReview = 107,
        AwardingBodyReview = 108,
        Approved = 109,
        Rejected = 110,
        Cancelled = 111
    }

    public enum SarasRole
    {
        Student = 1,
        Guest = 2,
        Evaluator = 3,
        Teacher = 4
    }
    public enum SarasGenderType
    {
        Female = 0,
        Male = 1
    }

    public enum SarasServicesType
    {
        CreateUserAccount = 1,
        CreateCohorts = 2,
        GetResults = 3,
        CreateUserSchedule = 4
    }
    public enum CenterRequestStages
    {
        Draft = 145,
        RequestIsSubmitted = 146,
        EducationUserReview = 147,
        Approved = 148,
        Rejected = 149,
        Cancelled = 150
    }
    public enum GradingScheme
    {
        OutOf_Five = 1, // Out of five
        OutOf_Four = 2, // Out of four
        OutOf_Hundred = 3, // Out of 100
    }

    public enum AssessmentComponent
    {
        EPortfolio = 1,
        Capstone = 2,
        CBT = 3
    }

    public enum TransferVistorStages
    {
        Submitted = 163,
        Approved = 146
    }

    public enum QualificationLevel
    {
        PhD = 1,
        Master = 2,
        Bachelor = 3,
        Diploma = 4,
        HigherProfessionalEducation = 5,
        HighSchool = 6
    }
    public enum AttendenceStatuses
    {
        Present = 1,
        Absent,
        ExecuseAbsent
    }

    public enum ComplaintType
    {
        ITC_AcademicExclusionGrades = 7,
        OSH_AcademicExclusionGrades = 14
    }

    public enum SchoolTypes
    {
        NA = 6
    }

    public enum Qualifications
    {
        HighSchool = 4
    }

    public enum RPLExamBookingNotificationTypes
    {
        Confirmation = 1,
        Cancellation,
        Reminder,
        PaymentConfirmation,
        ExamResult,
        AutoRefund,
        RescheduleExam,
        ReTakeConfirmation
    }

    public enum ExamCalendarRequestCancelationStages
    {
        RequestIsSubmitted = 190,
        Approved,
        Rejected
    }
}