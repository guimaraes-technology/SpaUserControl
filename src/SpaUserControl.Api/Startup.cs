using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Owin;
using SpaUserControl.Api.Helpers;
using SpaUserControl.Startup;
using System.Web.Http;

namespace SpaUserControl.Api
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigureDependencyResolver(config);

            ConfigureWebApi(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private static void ConfigureDependencyResolver(HttpConfiguration config)
        {
            var container = new UnityContainer();

            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}