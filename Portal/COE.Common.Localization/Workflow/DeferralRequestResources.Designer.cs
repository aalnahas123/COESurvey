﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RM.Workflow {
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
    public class DeferralRequestResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DeferralRequestResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("COE.Common.Localization.Workflow.DeferralRequestResources", typeof(DeferralRequestResources).Assembly);
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
        ///   Looks up a localized string similar to Sorry, you cannot submit the deferral request due to the expiry of the submission period of deferral requests.
        /// </summary>
        public static string ApplicationPeriodEnded {
            get {
                return ResourceManager.GetString("ApplicationPeriodEnded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to I acknowledge that I have read the above terms and agree to them in full.
        /// </summary>
        public static string Approval {
            get {
                return ResourceManager.GetString("Approval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, there are no available semesters for deferral for this year till now . you may have exhausted your the limit of deferral semesters for current academic year.
        /// </summary>
        public static string AvailableDeferredSemesters {
            get {
                return ResourceManager.GetString("AvailableDeferredSemesters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, Can&apos;t submit deferral requests for intake students.
        /// </summary>
        public static string Intake_CanotDeferred {
            get {
                return ResourceManager.GetString("Intake_CanotDeferred", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must accept Terms &amp; Conditions.
        /// </summary>
        public static string TermsAndConditions {
            get {
                return ResourceManager.GetString("TermsAndConditions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, you can not exceed the limit of deferral semesters . Two semesters is the maximum limit for student to defer while studying at COE colleges.
        /// </summary>
        public static string TwoSemestersMaximumLimit {
            get {
                return ResourceManager.GetString("TwoSemestersMaximumLimit", resourceCulture);
            }
        }
    }
}