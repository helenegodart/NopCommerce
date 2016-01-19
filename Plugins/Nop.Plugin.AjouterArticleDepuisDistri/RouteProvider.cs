using Nop.Web.Framework.Mvc.Routes;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Plugin.AjouterArticleDepuisDistri
{
    class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.AjouterArticleDepuisDistri.Connect","Plugin/AjouterArticleDepuisDistri",
                new { controller = "creationArticleController", action = "Connect" },new[] {"AjouterArticleDepuisDistri.Controller"
                });
        }
    }
}
