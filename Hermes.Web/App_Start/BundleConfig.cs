using System.Web;
using System.Web.Optimization;

namespace Hermes.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-validate.js",
                        "~/Scripts/jquery.validate-unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",

                      "~/Content/base/themes.jqueryiu.datepicker.css",
                      "~/Content/bootstrap-responsive.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/jquery.timepicker.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/MyScripts").Include(
                "~/MyScripts/Hermes_DatePicker.js",
                "~/MyScripts/Hermes_TimePicker.js"
                ));
        }
    }
}
