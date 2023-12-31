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
namespace COE.Common.BLL
{
    using COE.Common.DAL;
    using Commons.Framework.Data;
    using Commons.Framework.Logging;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;

    public sealed partial class Unit : IUnitOfWork
    {
        public Unit()       
        {
    		this.context = new COEEntities();
        }
    
    	private readonly  DbContext context;
    
    	/// <summary>
        /// The Logger
        /// </summary>
        private static readonly Logger Logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);
        
      
    
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
    
    	~Unit()
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
