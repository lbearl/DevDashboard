using System.Web.Http;

namespace StatusBoard.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //remove support for XML, so all results returned by WebAPI actions
            //will only come out in JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //ensure that all WebAPI calls are authorized
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
