using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Nop.Plugin.AjouterArticleDepuisDistri
{
    class RouteProvider
    {
        public void GetConfigurationRoute(out string actionName,
            out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "Configurer";
            controllerName = "AjouterArticleDepuisDistri";
            routeValues = new RouteValueDictionary()
            {
                { "Namespaces", "Nop.Plugin.AjouterArticleDepuisDistri" },
                { "area", null }
            };
        }
    }
}
