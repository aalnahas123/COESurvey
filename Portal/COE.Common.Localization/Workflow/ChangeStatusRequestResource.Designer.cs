﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COE.Common.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ChangeStatusRequestResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ChangeStatusRequestResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("COE.Common.Localization.Workflow.ChangeStatusRequestResource", typeof(ChangeStatusRequestResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Action will be reviewed by contract specialist ..
        /// </summary>
        public static string InfoMessagAction {
            get {
                return ResourceManager.GetString("InfoMessagAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Status will be reflected to selected student term enrollment..
        /// </summary>
        public static string InfoMessageNewStatus {
            get {
                return ResourceManager.GetString("InfoMessageNewStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New Status.
        /// </summary>
        public static string NewStatus {
            get {
                return ResourceManager.GetString("NewStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry , The current academic year term is not specified.
        /// </summary>
        public static string NoAcademicYearTermSpecified {
            get {
                return ResourceManager.GetString("NoAcademicYearTermSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, The request cannot be registered due to the expiration of change status students period.
        /// </summary>
        public static string RegistrationPeriodExpired {
            get {
                return ResourceManager.GetString("RegistrationPeriodExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request students .
        /// </summary>
        public static string RequestStudents {
            get {
                return ResourceManager.GetString("RequestStudents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, you can not submit the request because of the period of change student status  on these colleges {0} is finished..
        /// </summary>
        public static string SubmitPeriodIsFinished {
            get {
                return ResourceManager.GetString("SubmitPeriodIsFinished", resourceCulture);
            }
        }
    }
}