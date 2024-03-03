using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public static class BundelConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Bundle-ul CSS
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Templaid/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            // CSS-ul aplicației
            bundles.Add(new StyleBundle("~/bundles/app/css").Include("~/Templaid/css/icons.min.css", "~/Templaid/css/app.min.css")
                 .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            //Vndor js
            bundles.Add(new ScriptBundle("~/vendor/js").Include(
                "~/Templaid/js/vendor.min.js"
                ));

            // App js
            bundles.Add(new ScriptBundle("~/app/js").Include(
               "~/Templaid/js/app.min.js"
               ));

            //Index js

            bundles.Add(new ScriptBundle("~/index/js").Include(
                 "~/Templaid/libs/jquery-knob/jquery.knob.min.js",
                 "~/Templaid/libs/peity/jquery.peity.min.js",
                 "~/ Templaid/libs/jquery-sparkline/jquery.sparkline.min.js",
                 "~/Templaid/js/pages/dashboard-1.init.js"
                 ));
        }
    }
}



