using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Data.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExpenseManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCrossSiteRequests(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "ApiFilters",
               routeTemplate: "api/{controller}/filter/{filter}/{value}",
               defaults: new { filter = RouteParameter.Optional, id = RouteParameter.Optional }
           );

            config.MapHttpAttributeRoutes();
            config.EnableSystemDiagnosticsTracing();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

//            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

//            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("json"));
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }

        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
//            var cors = new EnableCorsAttribute(
//                origins: "*",
//                headers: "*",
//                methods: "*");
//            config.EnableCors(cors);
        }
    }
}
