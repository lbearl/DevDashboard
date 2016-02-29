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

            //bundle for angular + sbadmin2 + everything else necessary for the SPA dashboard
            bundles.Add(new ScriptBundle("~/bundles/singlepagedashboard").Include(
                "~/Content/bower_components/angular/angular.js").Include(
                "~/Content/bower_components/startbootstrap-sb-admin-2/dist/js/sb-admin-2.js").Include(
                "~/Content/bower_components/metisMenu/dist/metisMenu.js").Include(
                "~/Content/bower_components/angular-route/angular-route.js").Include(
                "~/Content/bower_components/angular-resource/angular-resource.js").Include(
                "~/Content/bower_components/d3/d3.js").Include(
                "~/Content/bower_components/nvd3/build/nv.d3.js").Include(
                "~/Content/bower_components/angular-nvd3/dist/angular-nvd3.js").Include(
                "~/Scripts/dashboard-app/dashboard.module.js").IncludeDirectory(
                "~/Scripts/dashboard-app/models", "*.js").IncludeDirectory(
                "~/Scripts/dashboard-app/controllers", "*.js").IncludeDirectory(
                "~/Scripts/dashboard-app/factories", "*.js").IncludeDirectory(
                "~/Scripts/dashboard-app/interfaces", "*.js").IncludeDirectory(
                "~/Scripts/dashboard-app/resources", "*.js").IncludeDirectory(
                "~/Scripts/dashboard-app/services", "*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
            // ^^ Getting rid of modernizr for now, MS made a bone headed decision to package it like this

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Content/bower_components/respondJs/dest/respond.src.js"));

            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.css").Include(
                      //"~/Content/bootswatch-cosmo.css").Include(
                      //need the next line (and an explicity font awesome dependency) to get around some MVC pipeline issues
                      "~/Content/bower_components/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()
                   ));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include(
                "~/Content/bower_components/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css",
                "~/Content/bower_components/startbootstrap-sb-admin-2/dist/css/timeline.css",
                "~/Content/bower_components/metisMenu/dist/metisMenu.css",
                "~/Content/bower_components/nvd3/build/nv.d3.css"));
        }
    }
}
