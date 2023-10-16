using COE.Common.Localization;
using COE.Common.Model.ViewModels.DCS;
//using COE.Cources.Localization;
//using COE.Cources.Localization.Training;
using Commons.Framework.Web.Mvc.DataAnnotations;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace COE.Model.ViewModels
{
    public class ContractProviderStaffAttendanceUploadViewModel : UploadViewModel
    {
        [Required]
        public int? ContractID { get; set; }


        //public int? AcademicYearID { get; set; }
        [Required]
        public int? ContractAcademicYearID { get; set; }

        //[Required]
        //public int? AcademicYearTermID { get; set; }

        [Required]
        public int? MonthID { get; set; }

        public int? SubProgramId { get; set; }
        public int? CourseId { get; set; }

        public int SessionId { get; set; }
        [Display(Name = "Section", ResourceType = typeof(DCSResources))]
        public int? SectionId { get; set; }
        [Display(Name = "DateTo", ResourceType = typeof(DCSResources))]
        public DateTime? DateTo { get; set; }
        [Display(Name = "DateFrom", ResourceType = typeof(DCSResources))]
        public DateTime? DateFrom { get; set; }

        public int ScheduleId { get; set; }

        public int MainProgramId { get; set; }

        public string CourseNameValue { get; set; }

        public string CourseStartDateStr { get; set; }

        public string CourseEndDateStr { get; set; }
        //attachments

        #region Attachments

        [DataType(DataType.Upload)]
        [Display(Name = "AttendanceAttachment", ResourceType = typeof(AppResources))]
        [ValidateFileUpload(AllowedExtensions = "csv")]
        [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase AttendanceAttachment { get; set; }

        //[DataType(DataType.Upload)]
        //[Display(Name = "AttendanceAttachmentSigned", ResourceType = typeof(AppResources))]
        //[ValidateFileUpload(AllowedExtensions = "pdf,png")]
        //[Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredField")]
        //public HttpPostedFileBase AttendanceAttachmentSigned { get; set; }

        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        public Guid? AttendanceAttachmentId { get; set; }

        //[DataType(DataType.Upload)]
        //[Display(ResourceType = typeof(AppResources), Name = "AttachedFile")]
        //public Guid? AttendanceAttachmentSignedId { get; set; }

        //[FileExtensions(Extensions = "csv", ErrorMessageResourceName = "FileUploadValidExtensions", ErrorMessageResourceType = typeof(DCSResources))]
        //public string AttachmentFileName
        //{
        //    get
        //    {
        //        if (AttendanceAttachment != null)
        //            return AttendanceAttachment.FileName;
        //        else
        //            return "";
        //    }
        //}

        //[FileExtensions(Extensions = "csv", ErrorMessageResourceName = "FileUploadValidExtensions", ErrorMessageResourceType = typeof(DCSResources))]
        //public string AttachmentSignedFileName
        //{
        //    get
        //    {
        //        if (AttendanceAttachmentSigned != null)
        //            return AttendanceAttachmentSigned.FileName;
        //        else
        //            return "";
        //    }
        //}

        #endregion
        public List<System.Web.Mvc.SelectListItem> AcademicYearsList { get; set; }
        public List<System.Web.Mvc.SelectListItem> MonthsList { get; set; }
        //public List<System.Web.Mvc.SelectListItem> AcademicYearTermsList { get; set; }
        //public List<System.Web.Mvc.SelectListItem> MonthsList { get; set; }
    }
}