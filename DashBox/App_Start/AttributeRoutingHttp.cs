using System.Web.Routing;
using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DashBox.App_Start.AttributeRoutingHttp), "Start")]

namespace DashBox.App_Start {
    public static class AttributeRoutingHttp {
		public static void RegisterRoutes(RouteCollection routes) {
            
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

			// ASP.NET Web API
            //routes.MapHttpAttributeRoutes();
            //routes.MapPageRoute(
            //RouteTable.Routes.MapHttpRoute("MyApi", "api/{controller}");
            //RouteTable.Routes.MapHttpRoute("MyApi", "api/{controller}/{id}");

            //routes.MapHttpRoute(
            //    name: "API Default",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            routes.MapHttpRoute(
                name: "API Default action",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
		}

        public static void Start() {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
