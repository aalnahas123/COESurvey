using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.Enums
{
    public class Enum
    {

        public enum RowStaus
        {
            Deleted = 0,
            Active = 1,
            Inactive = 2,
            Success = 3,
            Warning = 4,
            Danger = 5,
            DenyDeleted = 6,
            Fail = 7,
            Duplicate = 8,
            DenyInactive = 9
        }
        public enum UserType
        {
            ActiveDirectory = 1,
            Online = 2,
        }
        public enum SaveStaus
        {
            Saved = 1,
            Updated = 2,
            Deleted = 3,
            DeleteError = 4,
            ItemActivated = 6,
            ItemDeactivated = 7,
            ItemHasRelatedData = 8,
            ItemError = 9,
            Pending = 10,
            NotExist = 11,
            AlreadyExist = 12,
            Transfered = 13,
            UserNameAlreadyRegistered = 14,
            EmailAlreadyRegistered = 15,
            PhoneNumberAlreadyRegistered = 16,
            NoSecondPeriodExist = 17,
            AddRoleNotification = 18,
            NewRequestSaved = 19,
            RequestRejected = 20,
            StudentsRejected = 21
        }
        public enum YaqeenStates
        {
            ValidatedFromYaqeen = 0,
            ValidatedFromYaqeenAndList = 1
        }

        public enum ProgrammeStates
        {
            Closed = 0,
            Open = 1,
        }

        public enum TrainingUserType
        {
            General,
            Supervisor,
            CenterAdmin,
            SystemAdmin,
            Lecturer,
            Student
        }

        public enum Waves
        {
            One = 1,
            Two = 2
        }


    }
    public enum CenterType
    {
        Male = 1,
        Female = 2,
        Both = 3
    }

    public enum RPLExamRequestStages
    {
        RequestSubmitted = 181,
        EducationSupervisorReview = 182,
        SentBackToCandidate = 183,
        Approved = 184,
        Rejected = 185,
        Cancelled = 186,
    }

    public enum RPLCertificateTypes
    {
        Practitioner = 1,
        Professional
    }

    public enum RPLExamBookingCancelationReasons
    {
        ByUser = 1,
        ByAdmin,
        SlotUnavailable
    }

    public enum OSHRPLGraduatesViewCertificateTypes
    {
        OSH,
        RPL
    }

    public enum RPLExamResultStatus
    {
        Success = 160,
        Fail = 180
    }

    public enum ExamBookingAttendanceStatus
    {
        Present = 1,
        PresentButLate,
        Absent
    }

    public enum ZATCAIntegrationLogTypes
    {
        Warning = 1,
        Error
    }

    public enum ExamCalendarRequestCommentTypes
    {
        TestCenter = 1,
        EmergencyCancellation,
        EmergencyCancellationRequest
    }
}