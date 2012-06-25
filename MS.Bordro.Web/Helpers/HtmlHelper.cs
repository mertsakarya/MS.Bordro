using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Enumerations;
using MS.Bordro.Interfaces.Services;


namespace MS.Bordro.Web.Helpers
{
    public static class HtmlHelper
    {
        private static readonly IResourceService ResourceService =  DependencyResolver.Current.GetService<IResourceService>();

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;
            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
                realModelType = underlyingType;
            return realModelType;
        }

        public static string GetUrlFriendlyDateTime<TModel>(this HtmlHelper<TModel> htmlHelper, DateTime dateTime) {
            return ResourceService.UrlFriendlyDateTime(dateTime);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, bool optional = false) { return EnumDropDownListFor(htmlHelper, expression, optional, null); }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, bool optional, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var type = GetNonNullableModelType(metadata);
            var dict = ResourceService.GetLookup(type.Name);
            var list = new List<SelectListItem>();
            if (optional || metadata.IsNullableValueType)
                list.Add(new SelectListItem { Text = htmlHelper.ResourceValue("EmptyText"), Value = "0" });
            foreach (var item in dict) {
                var sli = new SelectListItem { Text = item.Value, Value = item.Key };
                try {
                    if (metadata.Model != null && item.Key == metadata.Model.ToString())
                        sli.Selected = true;
                } catch { }
                list.Add(sli);
            }
            return htmlHelper.DropDownListFor(expression, list, htmlAttributes);
        }

        public static string KeyFor<TModel>(this HtmlHelper<TModel> htmlHelper, BaseGuidModel model) { return model.Guid.ToString(); }

        private static string ResourceValue<TModel>(this HtmlHelper<TModel> htmlHelper, string resourceName, string language = "")
        {
            return ResourceService.ResourceValue(resourceName, language);
        }

        private static string LookupText<TModel>(this HtmlHelper<TModel> htmlHelper, string lookupName, string name, string language = "")
        {
            return ResourceService.GetLookupText(lookupName, name,  language);
        }

        private static string LookupText<TModel>(this HtmlHelper<TModel> htmlHelper, string lookupName, byte value, string language = "")
        {
            var key = ResourceService.GetLookupEnumKey(lookupName, value, language);
            return key;
        }

        public static string LocationText<TModel>(this HtmlHelper<TModel> htmlHelper, string lookupName, string key, string countryCode = "")
        {
            return ResourceService.GetLookupText(lookupName, key, countryCode);
        }

        public static IHtmlString Photo<TModel>(this HtmlHelper<TModel> htmlHelper, Guid photoGuid, PhotoType photoType = PhotoType.Original, string description = "", bool setId = false, bool encode = false)
        {
            var tb = new TagBuilder("img");
            if(setId) {
                tb.Attributes.Add("id", String.Format("ProfilePhoto"));
            }
            string str = GetPhotoPath(photoGuid, photoType);
            if (encode) {
                try {
                    var fileName = htmlHelper.ViewContext.HttpContext.Server.MapPath(str);
                    var bytes = ToBytes(fileName);
                    var encodedBytes = EncodeBytes(bytes);
                    str = @"data:image/jpg;base64," + encodedBytes;
                } catch {}
            }
            tb.Attributes.Add("src", str);
            if (!String.IsNullOrWhiteSpace(description))
                tb.Attributes.Add("title", description);
            return htmlHelper.Raw(tb.ToString());
        }

        public static string PhotoLink<TModel>(this HtmlHelper<TModel> htmlHelper, Guid photoGuid, PhotoType photoType = PhotoType.Large) { return GetPhotoPath(photoGuid, photoType); }

        private static string GetPhotoPath(Guid photoGuid, PhotoType photoType)
        {
            return String.Format("/{0}/{1}-{2}.jpg", ((photoGuid == Guid.Empty) ? "Images": "Photos"), (byte)photoType, photoGuid);
        }

        public static IHtmlString DisplayDetailFor<TModel, TProp>(this HtmlHelper<TModel> htmlHelper, bool condition, Expression<Func<TModel, TProp>> expression, string countryCode = "")
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            if (condition) {
                var label = new TagBuilder("div");
                label.AddCssClass("display-label");
                label.InnerHtml = String.Format("<b>{0}</b>", htmlHelper.DisplayNameFor(expression).ToHtmlString());
                var text = new TagBuilder("div");
                text.AddCssClass("display-field");
                if(String.IsNullOrWhiteSpace(countryCode))
                    text.InnerHtml = htmlHelper.DisplayTextFor(expression).ToHtmlString();
                else
                    text.SetInnerText(htmlHelper.LocationText("Country", countryCode));
                var container = new TagBuilder("div");
                container.Attributes.Add("title", metadata.Description);
                container.InnerHtml = label + text.ToString();
                var result = htmlHelper.Raw(container.ToString());
                return result;
            }
            return htmlHelper.Raw("");
        }

        public static IHtmlString AutoCompleteFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, string name, string lookupName, string searchingFor, string urlToCall, string serverCountryCode = "", string clientCountryCode = "", string onselect = "")
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var id = name.Replace('[', '_').Replace(']', '_');
            var key = "";
            try {
                key = (metadata.Model != null) ? metadata.Model.ToString() : "";
            } catch {
                if (name.IndexOf('[') < 0) throw;
            }
            var value = ResourceService.GetLookupText(lookupName, key, serverCountryCode);
            var hiddenTag = new TagBuilder("input");
            hiddenTag.Attributes.Add("id", id);
            hiddenTag.Attributes.Add("name", name);
            hiddenTag.Attributes.Add("type", "hidden");
            hiddenTag.Attributes.Add("value", key);


            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("text-box single-line");
            inputTag.Attributes.Add("id", id+"Lookup");
            inputTag.Attributes.Add("name", name + "Lookup");
            inputTag.Attributes.Add("type", "text");
            inputTag.Attributes.Add("value", value);
            var scriptTag = new TagBuilder("script") { InnerHtml = String.Format(@"
$(function() {{
    $('input#{0}Lookup').autocomplete({{
        select: function(event, ui) {{
            $('input#{0}')[0].value = ui.item.key;  
            $('input#{0}Lookup')[0].value = ui.item.value;  
{3}
        }},
        source: function (request, response) {{
            $.ajax({{
                url: '{1}',
                type: 'POST',
                dataType: 'json',
                data: {{ searching:'{4}',query: request.term{2} }},
                success: function (data) {{
                    response($.map(data, function(item) {{
                        return {{ label: item.Value, value: item.Value, key: item.Key }};
                    }}));
                }}
            }});
        }},
        minLength: 2 // require at least one character from the user
    }});
}});
setInterval(function() {{
    var fl=document.getElementById('{0}Lookup'); 
    if(fl != null && fl.value.length==0) document.getElementById('{0}').value = ''; 
}}, 7);
", id, urlToCall, (!String.IsNullOrWhiteSpace(clientCountryCode) ? ", countryCode:" + clientCountryCode : ""), onselect, searchingFor)
            };
            scriptTag.Attributes.Add("type", "text/javascript");
            return htmlHelper.Raw(String.Format("{0}{1}{2}", inputTag, hiddenTag, scriptTag));
        }

        public static IHtmlString DisplayDetailForEnum<TModel, TColl, TProp>(this HtmlHelper<TModel> htmlHelper, TModel model, Expression<Func<TModel, IList<TColl>>> expression,
                                                                             string lookupName, Expression<Func<TColl, TProp>> collectionPropertyExpression)
        {
            var compiledExpression = expression.Compile();
            var list = compiledExpression.Invoke(model);
            if (list.Count > 0) {
                var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
                var compiledPropertyExpression = collectionPropertyExpression.Compile();
                var sb = new StringBuilder();
                var first = true;
                var lookup = ResourceService.GetLookup(lookupName);
                foreach (var item in list) {
                    if (!first) sb.Append(", "); else first = false;
                    var key = Convert.ToString(compiledPropertyExpression.Invoke(item));
                    if(lookup.ContainsKey(key))
                        sb.Append(lookup[key]);
                }

                var label = new TagBuilder("div");
                label.AddCssClass("display-label");
                label.InnerHtml = String.Format("<b>{0}</b>", htmlHelper.DisplayNameFor(expression).ToHtmlString());
                var text = new TagBuilder("div");
                text.AddCssClass("display-field");
                text.InnerHtml = sb.ToString();
                var container = new TagBuilder("div");
                container.Attributes.Add("title", metadata.Description);
                container.InnerHtml = label + text.ToString();
                return htmlHelper.Raw(container.ToString());
            }

            return htmlHelper.Raw("");
        }

        private static byte[] ToBytes(string fileName)
        {
            return System.IO.File.ReadAllBytes(fileName);
        }

        private static string EncodeBytes(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
