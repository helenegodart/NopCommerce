using Nop.Web.Framework.Controllers;
using System.Web.Mvc;
using Nop.Plugin.AjouterArticleDepuisDistri;

namespace Nop.Plugin.AjouterArticleDepuisDistri.Controllers
{
    public class creationArticleController : BaseController
    {
        public ActionResult Create(int id)
        {
            if (creationArticle.creerArticle(id)) return View("~/Plugins/AjouterArticleDepuisDistri/Views/AjouterArticleDepuisDistri/Success.cshtml");
            else return View("~/Plugins/AjouterArticleDepuisDistri/Views/AjouterArticleDepuisDistri/Fail.cshtml");
        }
        
    }
}
