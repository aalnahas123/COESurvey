using System.Collections.Generic;
using System.Web.Optimization;

namespace COE.Survey.Web
{
    #region



    #endregion

    /// <summary>
    /// The as is bundle orderer.
    /// </summary>
    internal class AsIsBundleOrderer : IBundleOrderer
    {
        /// <summary>
        /// The order files.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="files">
        /// The files.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }

    /// <summary>
    /// The bundle extensions.
    /// </summary>
    internal static class BundleExtensions
    {
        /// <summary>
        /// The force ordered.
        /// </summary>
        /// <param name="sb">
        /// The sb.
        /// </param>
        /// <returns>
        /// The <see cref="Bundle"/>.
        /// </returns>
        public static Bundle ForceOrdered(this Bundle sb)
        {
            sb.Orderer = new AsIsBundleOrderer();
            return sb;
        }
    }

    /// <summary>
    ///     The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();
            bundles.ResetAll();
            BundleTable.EnableOptimizations = false;

            bundles.Add(
                new ScriptBundle("~/bundles/scripts").Include(
                    //"~/Scripts/jquery-2.2.3.min.js",
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/jquery.slicknav.js",
                    "~/Scripts/expressive.annotations.validate.min.js",
                    "~/Scripts/bootstrap.min.js").ForceOrdered());

            bundles.Add(
                new StyleBundle("~/Content/themes/css").Include(
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/css/font-awesome.min.css").ForceOrdered());

            bundles.Add(
                new ScriptBundle("~/bundles/validateScripts").Include(
                    "~/Scripts/jquery.validate*").ForceOrdered());
            // Bundel Boxed Layout By Mohammed Mostafa

            // Styles
            #region CSS GLOBAL MANDATORY STYLES

            // theme
            bundles.Add(new StyleBundle("~/bundles/global/plugins/css").Include(
                "~/Content/theme/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/theme/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/theme/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/theme/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                 ));
            // theme_rtl
            bundles.Add(new StyleBundle("~/bundles/global/plugins/rtl/css").Include(
                "~/Content/theme_rtl/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/theme_rtl/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/theme_rtl/assets/global/plugins/bootstrap/css/bootstrap-rtl.min.css",
                "~/Content/theme_rtl/assets/global/plugins/bootstrap-switch/css/bootstrap-switch-rtl.min.css"
               ));

            #endregion

            #region CSS PAGE LEVEL PLUGINS STYLES Student Profile-2

            // theme
            bundles.Add(new StyleBundle("~/bundles/PageLevelPlugin/css").Include(
                "~/Content/theme/assets/pages/css/profile-2.min.css",
                "~/Content/theme/assets/global/plugins/morris/morris.css"
                 ));
            // theme_rtl
            bundles.Add(new StyleBundle("~/bundles/PageLevelPlugin/rtl/css").Include(
                "~/Content/theme_rtl/assets/pages/css/profile-2-rtl.min.css",
                "~/Content/theme_rtl/assets/global/plugins/morris/morris.css"
                 ));
            #endregion


            #region CSS THEME GLOBAL STYLES
            // theme
            bundles.Add(new StyleBundle("~/bundles/global/css").Include(
                "~/Content/theme/assets/global/css/components.min.css",
                "~/Content/theme/assets/global/css/plugins.min.css",
                "~/Content/theme/assets/global/plugins/select2/css/select2.min.css",
                "~/Content/theme/assets/global/plugins/select2/css/select2-bootstrap.min.css"
                 ));
            // theme_rtl
            bundles.Add(new StyleBundle("~/bundles/global/rtl/css").Include(
                "~/Content/theme_rtl/assets/global/css/components-rtl.min.css",
                "~/Content/theme_rtl/assets/global/css/plugins-rtl.min.css"
                 ));
            #endregion

            #region CSS THEME LAYOUT STYLES
            // theme
            bundles.Add(new StyleBundle("~/bundles/layout/css").Include(
                "~/Content/theme/assets/layouts/layout2/css/layout.min.css",
                "~/Content/theme/assets/layouts/layout2/css/themes/blue.min.css",
                "~/Content/theme/assets/layouts/layout2/css/custom.min.css"
                 ));
            // theme_rtl
            bundles.Add(new StyleBundle("~/bundles/layout/rtl/css").Include(
                "~/Content/theme/assets/layouts/layout2/css/layout-rtl.min.css",
                "~/Content/theme/assets/layouts/layout2/css/themes/blue-rtl.min.css",
                "~/Content/theme/assets/layouts/layout2/css/custom-rtl.min.css"
                 ));
            #endregion


            // Scripts
            #region  JQuery

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Content/theme/assets/global/plugins/jquery.min.js"));

            #endregion
            #region SCRIPT BEGIN CORE PLUGINS

            bundles.Add(new ScriptBundle("~/bundles/globalPlugins").Include(
                //"~/Content/theme/assets/global/plugins/jquery.min.js",
                "~/Content/theme/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/theme/assets/global/plugins/js.cookie.min.js",
                "~/Content/theme/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/theme/assets/global/plugins/jquery.blockui.min.js",
                "~/Content/theme/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                ));

            #endregion

            #region SCRIPT THEME GLOBAL SCRIPTS

            bundles.Add(new ScriptBundle("~/bundles/globalScripts").Include(
                "~/Content/theme/assets/global/scripts/app.min.js",
                "~/Content/theme/assets/global/plugins/select2/js/select2.full.min.js",
                "~/Content/theme/assets/pages/scripts/components-select2.min.js"
                ));

            #endregion

            #region SCRIPT THEME LAYOUT SCRIPTS

            bundles.Add(new ScriptBundle("~/bundles/layoutScripts").Include(
                "~/Content/theme/assets/layouts/layout2/scripts/layout.min.js",
                //"~/Content/theme/assets/layouts/layout2/scripts/demo.min.js",
                "~/Content/theme/assets/layouts/global/scripts/quick-sidebar.min.js",
                "~/Content/theme/assets/layouts/global/scripts/quick-nav.min.js"
                ));

            #endregion

        }
    }
}
