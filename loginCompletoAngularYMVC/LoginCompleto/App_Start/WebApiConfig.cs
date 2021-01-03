using System.Net.Http.Headers;
using System.Web.Http;
using LoginCompleto.Controllers;
using System.Web.Http.Cors;

namespace LoginCompleto
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.EnableCors(new EnableCorsAttribute("http://localhost:4200","*","*"));
        }
    }
}
