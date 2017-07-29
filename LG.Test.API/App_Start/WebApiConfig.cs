using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace LG.Test.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatter = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatter.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            formatter.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;            
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //CORS            
            config.EnableCors();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            var constraints = new { httpMethod = new HttpMethodConstraint(HttpMethod.Options) };
            config.Routes.IgnoreRoute("OPTIONS", "*pathInfo", constraints);
        }
    }
}
