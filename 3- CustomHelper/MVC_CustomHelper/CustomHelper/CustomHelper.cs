using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Text;
namespace MVC_CustomHelper
{
    public static class CustomHelper
    {
        /* 
         
            MvcHtmlString : Yeni bir helper oluşturmak ya da var olanın değiştirilmiş halini kullanabilmeniz için kullanılan sınıfdır.

             Allatki SayfayaGit metodunu strin olarak geriye döndürdüğünüzda kullanabilmeniz için 

            @Html.Raw(CustomHelper.SayfayaGit("Index"))
             
            şeklinde kullanmanız gerekmektedir. Diğer türlü kullanıcı View üzerinde Buton yerine " <a href='Index' >Index</a> " html kodlarını görecektir.

            Bu sorunu aşabilmek için MvcHtmlString sınıfı bize yazdığımız string helper'ları Html codu olarak bize teslim eder.


            NOT :  MvcHtmlString olarak yazdığınız Custom Helper'ları @Html. başlığı altında görmek istiyorsanız. namespace uzantısını siliniz.

            namespace MVC_CustomHelper.CustomHelper yerine namespace MVC_CustomHelper olarak değiştirin.


            Not : SayfayaGit metodunun  geriye dönüş tipi string olduğundan using'lere namespace'i eklemeniz gerekmektedir.
        */

        public static string SayfayaGit(string name)
        {
            return "<a href='" + name + "' >" + name + "</a>";
        }


        /*
            TagBuilder sınıfı StringBuilder sınıfı gibi string birleştirmek için kullanılır. Ek özellik olarak Html kodlamaya özgü olarak Tag işlemleriniz yapabilmektedir. TagBuilder nesnesi diğer özellikleri ile Html kod oluşturmak için kullanılan nesnedir.

         */


        public static MvcHtmlString Resim(this HtmlHelper helper, string src, string alt, string width, string heigth)
        {
            var builder = new TagBuilder("img");
            builder.Attributes.Add("src", src);
            builder.Attributes.Add("width", width);
            builder.Attributes.Add("height", heigth);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));

        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString DeleteActionlink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
        {
            var routeValuesDict = new RouteValueDictionary(routeValues);

            var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!customAttributes.ContainsKey("rel"))
                customAttributes.Add("rel", "nofollow");

            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValuesDict, customAttributes);
        }


        public static MvcHtmlString UpdateButton(this HtmlHelper htmlHelper, string controller, string action, object routeValues = null, object htmlAttributes = null, object iconAttributes = null)
        {
            var routeValuesDict = new RouteValueDictionary(routeValues);
            var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var spanCustomAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes);

            var builder = new TagBuilder("a");
            // builder.MergeAttribute("href", string.Format("/{0}/{1}/{2}", controller, action, string.Join("/", routeValuesDict.Values)));
            builder.MergeAttribute("href", $"/{controller}/{action}/{string.Join("/", routeValuesDict.Values)}");
            builder.MergeAttributes(customAttributes);

            var span = new TagBuilder("span");
            span.MergeAttributes(spanCustomAttributes);
            span.ToString(TagRenderMode.SelfClosing);

            builder.InnerHtml += span.ToString();

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}
