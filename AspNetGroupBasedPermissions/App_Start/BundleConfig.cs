using System.Web.Optimization;

namespace HospitalWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Template/js").Include(
                "~/lib/jquery/dist/jquery.min.js",
                "~/Scripts/template/tether/tether.min.js",
                "~/lib/bootstrap/dist/js/bootstrap.js",
                "~/lib/datatables-1.10.12/media/js/jquery.datatables.min.js",
                "~/lib/jquery-validation/dist/jquery.validate.min.js",
                "~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js",
                "~/Scripts/template/plugins.js",
                "~/Scripts/template/app.js"
                ));

            bundles.Add(new StyleBundle("~/Template/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Template/font-awesome/font-awesome.min.css",
                "~/Content/Template/main.css"
               ));

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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
