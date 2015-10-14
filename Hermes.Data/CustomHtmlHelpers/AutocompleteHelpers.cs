/********************************************************************************
         * CLASS NAME:
         * PROGRAMMER:
         * DESCRIPTION:
         * VERSION:
         * CREATED DATE:
         * MODIFIED DATE:
        ********************************************************************************/
               
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Hermes.Data.CustomHtmlHelpers
{
    public static class AutocompleteHelpers
    {
        public static MvcHtmlString AutocompleteFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            string actionName, string controllerName)
        {
            string autocompleteUrl = UrlHelper.GenerateUrl(null, actionName,
                controllerName, null, html.RouteCollection,
                html.ViewContext.RequestContext,
                includeImplicitMvcValues: true);

            return html.TextBoxFor(expression, new { data_autocomplete_url = autocompleteUrl });
        }
    }
}
