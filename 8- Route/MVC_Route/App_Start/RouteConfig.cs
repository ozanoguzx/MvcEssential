using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Route
{
    public class RouteConfig
    {

        /*
         Route Definition                             	Example of matching URL

          1 {controller}/{action}/{id}                    /Urunler/Detail/1
          2 {table}/Details                               /Products/Details
          3 Employee/{action}/{entry}                     /Employee/Edit/21
          4 {reporttype}/{year}/{month}/{day}             /Sales/2015/1/8
          5 {locale}/{action}                             /US/Detail
          6 {language}-{country}/{action}                 /en-US/Show
            
              
         */
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Action üzerinde Route Attribute'ünü kullanıma açabilirsiniz. 
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //name: "Product",
            //url: "Product/Details/{CategoryName}/{CategoryId}/{ProductName}/{ProductId}",
            //defaults: new
            //{
            //    controller = "Product",
            //    action = "Details",
            //    CategoryName = UrlParameter.Optional,
            //    CategoryId = UrlParameter.Optional,
            //    ProductName = UrlParameter.Optional,
            //    ProductId = UrlParameter.Optional
            //});


             
            // http://www.hepsiburada.com/apple-ipad-air-2-32gb-9-7-wifi-gumus-retina-ekranli-tablet-mnv62tu-a-p-HBV000001HB5H
            // http://localhost:1775/Northwoods-Cranberry-Sauce-p-8
            routes.MapRoute(
            name: "Product",
            url: "{ProductName}-p-{ProductId}",
            defaults: new
            {
                controller = "Product",
                action = "Details",
                ProductName = UrlParameter.Optional,
                ProductId = UrlParameter.Optional
            });


            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });


            /*

            //buradaki route, namespace alanında tanımlanan Controller için çalışacaktır.
            routes.MapRoute(
                 name: "Area",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "MVC_Route.Areas.Category.Controllers" } // Area kullanırken sadece o area için çalışmasını istediğiniz route'lar hazırlayabbilirsiniz. Farklı bir url geldiğinde çalışmayacaktır. Url Security oluşturabilirsiniz.

             ).DataTokens["UseNamespaceFallback"] = false;

             */


        }

    }
}
