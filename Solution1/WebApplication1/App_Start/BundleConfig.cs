using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Vendors/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/elegant/css").Include("~/Vendors/elegant-icons.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include("~/Content/magnific-popup.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/nice-select/css").Include("~/Vendors/nice-select.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/owl.carousel/css").Include("~/Vendors/owl.carousel.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include("~/Content/slicknav.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/style/css").Include("~/Vendors/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new Bundle("~/bundles/jquery/js").Include("~/Vendors/jquery-3.3.1.min.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new Bundle("~/bundles/nice-select/js").Include("~/Vendors/jquery.nice-select.min.js"));
            bundles.Add(new Bundle("~/bundles/nicescroll/js").Include("~/Vendors/jquery.nicescroll.min.js"));
            bundles.Add(new Bundle("~/bundles/magnific-popup/js").Include("~/Scripts/jquery.magnific-popup.min.js"));
            bundles.Add(new Bundle("~/bundles/countdown/js").Include("~/Vendors/jquery.countdown.min.js"));
            bundles.Add(new Bundle("~/bundles/slicknav/js").Include("~/Scripts/jquery.slicknav.js"));
            bundles.Add(new Bundle("~/bundles/mixitup/js").Include("~/Vendors/mixitup.min.js"));
            bundles.Add(new Bundle("~/bundles/owl.carousel/js").Include("~/Vendors/owl.carousel.min.js"));
            bundles.Add(new Bundle("~/bundles/main/js").Include("~/Vendors/main.js"));
            bundles.Add(new Bundle("~/bundles/login/js").Include("~/Vendors/login.js"));
        }
    }
}