using System.Web.Optimization;

namespace StatusBoard.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/bower_components/jquery.validation/dist/jquery.validate.js").Include(
                        "~/Content/bower_components/Microsoft.jQuery.Unobtrusive.Validation/jquery.validate.unobtrusive.js")
                );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
            // ^^ Getting rid of modernizr for now, MS made a bone headed decision to package it like this

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Content/bower_components/respondJs/dest/respond.src.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap-theme.css",
                      "~/Content/site.css"));
        }
    }
}
