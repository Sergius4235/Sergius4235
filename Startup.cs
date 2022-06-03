using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Owin;

namespace BLL
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration CONFIG = new HttpConfiguration();
            CONFIG.EnableCors();
            CONFIG.Routes.MapHttpRoute(
                name: "createUserApi",
                routeTemplate: "api/{controller}",
                defaults: new { action = RouteParameter.Optional }
                );
            appBuilder.UseWebApi(CONFIG);
        }
    }
}
