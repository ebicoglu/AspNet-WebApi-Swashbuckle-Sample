using System.Linq;
using System.Web.Http;

namespace SwashbuckleSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Default output is json.
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config
                .Formatters
                .XmlFormatter
                .SupportedMediaTypes
                .FirstOrDefault(t => t.MediaType == "application/xml"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
