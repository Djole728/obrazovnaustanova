using System.Web;
using System.Web.Optimization;

namespace ObrazovneUstanove.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/bower_components/gentelella/build/js/custom.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jTable").Include(
                     "~/Scripts/jquery-ui-1.11.3.js",
                     "~/Scripts/jtable/jquery.jtable.js",
                     "~/Scripts/jtable/localization/jquery.jtable.sr.js",
                     "~/Scripts/jtable/extensions/jquery.jtable.multiple-key-fields.js",
                    "~/Scripts/jtable/extensions/jtable-extension.js",
                    "~/Scripts/jtable/extensions/jquery.jtable.spinner.js",
                    "~/Scripts/jtable/extensions/jquery.jtable.footer.js",
                    "~/Scripts/jtable/extensions/jquery.jtable.buttonleft.js",
                    "~/Scripts/jtable/extensions/jquery.jtable.decimal.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui.min.css",
                      "~/bower_components/gentelella/vendors/font-awesome/css/font-awesome.css",
                      "~/bower_components/gentelella/build/css/custom.css",
                      "~/Scripts/jtable/themes/metro/blue/jtable.css",
                      "~/Content/jtable/jtable-custom.css",
                      "~/Content/site.css"));
        }
    }
}
