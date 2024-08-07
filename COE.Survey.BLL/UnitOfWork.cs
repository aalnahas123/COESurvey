﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// ReSharper disable once CheckNamespace
namespace COE.Survey.BLL
{
    using System;
    using System.Linq;	
    using System.Web;
    using System.Reflection;
    using System.Collections.Generic;
    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    
    using Commons.Framework.Data;
    using Commons.Framework.Logging;
    
    using COE.Survey.BLL.Repositories;
    using COE.Common.Model;
    using COE.Common.DAL;
    
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public sealed partial class COEUoW : IUnitOfWork
    {
        public COEUoW()       
        {
    		this.context = new COEEntities();
            this.ActivationCode = new ActivationCodesRepository(this.context);
            this.Alert = new AlertsRepository(this.context);
            this.AlertType = new AlertTypesRepository(this.context);
            this.AttachmentContents = new AttachmentContentsRepository(this.context);
            this.Attachments = new AttachmentsRepository(this.context);
            this.AttachmentTypes = new AttachmentTypesRepository(this.context);
            this.HomePageCategory = new HomePageCategoriesRepository(this.context);
            this.HomePageModule = new HomePageModulesRepository(this.context);
            this.SystemSettings = new SystemSettingsRepository(this.context);
            this.UserActivity = new UserActivitiesRepository(this.context);
            this.UserActivityType = new UserActivityTypesRepository(this.context);
            this.AspNetRoles = new AspNetRolesRepository(this.context);
            this.AspNetRolesParent = new AspNetRolesParentsRepository(this.context);
            this.AspNetUserClaims = new AspNetUserClaimsRepository(this.context);
            this.AspNetUserLogins = new AspNetUserLoginsRepository(this.context);
            this.AspNetUsers = new AspNetUsersRepository(this.context);
            this.Stage = new StagesRepository(this.context);
            this.StageDecision = new StageDecisionsRepository(this.context);
            this.Status = new StatusRepository(this.context);
            this.Action = new ActionsRepository(this.context);
            this.CollegeStaff = new CollegeStaffsRepository(this.context);
            this.FieldVisibilty = new FieldVisibiltiesRepository(this.context);
            this.JobType = new JobTypesRepository(this.context);
            this.LeaveReason = new LeaveReasonsRepository(this.context);
            this.Module = new ModulesRepository(this.context);
            this.ModuleAction = new ModuleActionsRepository(this.context);
            this.ModuleCategory = new ModuleCategoriesRepository(this.context);
            this.ModuleField = new ModuleFieldsRepository(this.context);
            this.ModuleRole = new ModuleRolesRepository(this.context);
            this.RolePermission = new RolePermissionsRepository(this.context);
            this.StaffLevel = new StaffLevelsRepository(this.context);
            this.StaffQualification = new StaffQualificationsRepository(this.context);
            this.StaffSpecialization = new StaffSpecializationsRepository(this.context);
            this.StaffType = new StaffTypesRepository(this.context);
            this.UserCollege = new UserCollegesRepository(this.context);
            this.UserDisplay = new UserDisplaysRepository(this.context);
            this.UserEmployer = new UserEmployersRepository(this.context);
            this.UserPermission = new UserPermissionsRepository(this.context);
            this.UserSpecialization = new UserSpecializationsRepository(this.context);
            this.VisaType = new VisaTypesRepository(this.context);
            this.VisibiltyRuleField = new VisibiltyRuleFieldsRepository(this.context);
            this.VisibitlyRule = new VisibitlyRulesRepository(this.context);
            this.QuestionAnswer = new QuestionAnswersRepository(this.context);
            this.QuestionOption = new QuestionOptionsRepository(this.context);
            this.QuestionType = new QuestionTypesRepository(this.context);
            this.Survey = new SurveysRepository(this.context);
            this.SurveyAnswer = new SurveyAnswersRepository(this.context);
            this.SurveyModules = new SurveyModulesRepository(this.context);
            this.SurveyQuestion = new SurveyQuestionsRepository(this.context);
            this.TempNotificationQueue = new TempNotificationQueuesRepository(this.context);
            this.SurveyImage = new SurveyImagesRepository(this.context);
            this.SurveyApprover = new SurveyApproversRepository(this.context);
            this.SurveyViewer = new SurveyViewersRepository(this.context);
            this.SurveyAttachement = new SurveyAttachementsRepository(this.context);
        }
    
    	private readonly  DbContext context;
    
    	/// <summary>
        /// The Logger
        /// </summary>
        private static readonly Logger Logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public ActivationCodesRepository ActivationCode { get; set; }
        public AlertsRepository Alert { get; set; }
        public AlertTypesRepository AlertType { get; set; }
        public AttachmentContentsRepository AttachmentContents { get; set; }
        public AttachmentsRepository Attachments { get; set; }
        public AttachmentTypesRepository AttachmentTypes { get; set; }
        public HomePageCategoriesRepository HomePageCategory { get; set; }
        public HomePageModulesRepository HomePageModule { get; set; }
        public SystemSettingsRepository SystemSettings { get; set; }
        public UserActivitiesRepository UserActivity { get; set; }
        public UserActivityTypesRepository UserActivityType { get; set; }
        public AspNetRolesRepository AspNetRoles { get; set; }
        public AspNetRolesParentsRepository AspNetRolesParent { get; set; }
        public AspNetUserClaimsRepository AspNetUserClaims { get; set; }
        public AspNetUserLoginsRepository AspNetUserLogins { get; set; }
        public AspNetUsersRepository AspNetUsers { get; set; }
        public StagesRepository Stage { get; set; }
        public StageDecisionsRepository StageDecision { get; set; }
        public StatusRepository Status { get; set; }
        public ActionsRepository Action { get; set; }
        public CollegeStaffsRepository CollegeStaff { get; set; }
        public FieldVisibiltiesRepository FieldVisibilty { get; set; }
        public JobTypesRepository JobType { get; set; }
        public LeaveReasonsRepository LeaveReason { get; set; }
        public ModulesRepository Module { get; set; }
        public ModuleActionsRepository ModuleAction { get; set; }
        public ModuleCategoriesRepository ModuleCategory { get; set; }
        public ModuleFieldsRepository ModuleField { get; set; }
        public ModuleRolesRepository ModuleRole { get; set; }
        public RolePermissionsRepository RolePermission { get; set; }
        public StaffLevelsRepository StaffLevel { get; set; }
        public StaffQualificationsRepository StaffQualification { get; set; }
        public StaffSpecializationsRepository StaffSpecialization { get; set; }
        public StaffTypesRepository StaffType { get; set; }
        public UserCollegesRepository UserCollege { get; set; }
        public UserDisplaysRepository UserDisplay { get; set; }
        public UserEmployersRepository UserEmployer { get; set; }
        public UserPermissionsRepository UserPermission { get; set; }
        public UserSpecializationsRepository UserSpecialization { get; set; }
        public VisaTypesRepository VisaType { get; set; }
        public VisibiltyRuleFieldsRepository VisibiltyRuleField { get; set; }
        public VisibitlyRulesRepository VisibitlyRule { get; set; }
        public QuestionAnswersRepository QuestionAnswer { get; set; }
        public QuestionOptionsRepository QuestionOption { get; set; }
        public QuestionTypesRepository QuestionType { get; set; }
        public SurveysRepository Survey { get; set; }
        public SurveyAnswersRepository SurveyAnswer { get; set; }
        public SurveyModulesRepository SurveyModules { get; set; }
        public SurveyQuestionsRepository SurveyQuestion { get; set; }
        public TempNotificationQueuesRepository TempNotificationQueue { get; set; }
        public SurveyImagesRepository SurveyImage { get; set; }
        public SurveyApproversRepository SurveyApprover { get; set; }
        public SurveyViewersRepository SurveyViewer { get; set; }
        public SurveyAttachementsRepository SurveyAttachement { get; set; }
    
    	/// <summary>
        /// Calling SaveChanges does create a DB transaction so
        /// every query executed against the DB will be rollbacked is something goes wrong.
        /// </summary>
        /// <returns></returns>
        public int Save(string userId = null,bool validateOnSaveEnabled = true)
        {
            //In all versions of Entity Framework, whenever you execute SaveChanges() to insert, update or delete on the 
            //database the framework will wrap that operation in a transaction. This transaction lasts only long enough to             
            //execute the operation and then completes. When you execute another such operation a new transaction is started.
              
    		try
                {
    				this.context.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
                    this.UpdatePropertiesBeforeSave(userId);
                    var result= this.context.SaveChanges();
                   // transaction.Commit();
                    return result;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException entityValidationException)
                {
                    foreach (var entityValidationError in entityValidationException.EntityValidationErrors)
                        {    
                            var message = string.Empty;
                            foreach (var validationError in entityValidationError.ValidationErrors)
                            {
                                message += $" \n Entity: {entityValidationError.Entry.Entity} \n Property: {validationError.PropertyName} \n Error: {validationError.ErrorMessage} \n ";
                            }
                            if (entityValidationError.ValidationErrors.Count > 0)
                            {
                                Exception exception = new Exception(message);
                                Logger.Error(exception);
                                throw exception;
                            }
                        }
                }
    
                return 0;            
        }
    
    	/// <summary>
        /// Updates the properties before save.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        private void UpdatePropertiesBeforeSave(string userId = null)
        {
    		 if (string.IsNullOrEmpty(userId) 
                    && HttpContext.Current != null 
                    && HttpContext.Current.User != null
        	        && HttpContext.Current.User.Identity.IsAuthenticated)
        	    {
        	        userId = HttpContext.Current.User.Identity.Name;
        	    }
    
            const string CreatedOnProperty = "CreatedOn";
            const string ModifiedOnPropery = "UpdatedOn";
            //const string IsActiveProperty = "IsActive";
            const string IdProperty = "Id";
    
            IEnumerable<DbEntityEntry> entitiesWithCreatedOn =
                this.context.ChangeTracker.Entries()
                    .Where(
                        e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedOnProperty) != null);
            foreach (DbEntityEntry entry in entitiesWithCreatedOn)
            {
                entry.Property(CreatedOnProperty).CurrentValue = DateTime.Now;
            }
    
            //IEnumerable<DbEntityEntry> entitiesWithStateCode =
            //    this.context.ChangeTracker.Entries()
            //        .Where(
            //            e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(IsActiveProperty) != null);
            //foreach (DbEntityEntry entry in entitiesWithStateCode)
            //{
                //entry.Property(IsActiveProperty).CurrentValue = true;
            //}
    
            IEnumerable<DbEntityEntry> entitiesWithId =
                this.context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(IdProperty) != null);
            foreach (DbEntityEntry entry in entitiesWithId)
            {
               Guid id = Guid.Empty;
                    if (Guid.TryParse(entry.Property(IdProperty).CurrentValue.ToString(), out id) && id == Guid.Empty)
                    {
                            entry.Property(IdProperty).CurrentValue = Guid.NewGuid();
                    }
            }
    
            IEnumerable<DbEntityEntry> entitiesWithModifiedOn =
                this.context.ChangeTracker.Entries()
                    .Where(
                        e => (e.State == EntityState.Modified || e.State == EntityState.Added) && e.Entity.GetType().GetProperty(ModifiedOnPropery) != null);
            foreach (DbEntityEntry entry in entitiesWithModifiedOn)
            {
                entry.Property(ModifiedOnPropery).CurrentValue = DateTime.Now;
            }
    
            if (!string.IsNullOrEmpty(userId))
            {
                const string CreatedByPropery = "CreatedBy";
                const string ModifiedByPropery = "UpdatedBy";
                IEnumerable<DbEntityEntry> entitiesWithCreatedBy =
                     this.context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedByPropery) != null);
                foreach (DbEntityEntry entry in entitiesWithCreatedBy)
                {
                    entry.Property(CreatedByPropery).CurrentValue = userId;
                }
    
                IEnumerable<DbEntityEntry> entitiesWithModifiedBy =
                    this.context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            (e.State == EntityState.Modified || e.State == EntityState.Added) && e.Entity.GetType().GetProperty(ModifiedByPropery) != null);
                foreach (DbEntityEntry entry in entitiesWithModifiedBy)
                {
                    entry.Property(ModifiedByPropery).CurrentValue = userId;
                }
            }
        }
    
    	~COEUoW()
        {
            this.Dispose(false);
        }
    
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
                var dbContext = this.context;
                dbContext?.Dispose();
            }
        }
    
    
    }
}
