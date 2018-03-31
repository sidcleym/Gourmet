using System.Web.Http;
using System.Web.Http.Cors;

namespace Gourmet.UI
{

    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            System.Web.OData.Extensions.HttpConfigurationExtensions.AddODataQueryFilter(config);

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

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
