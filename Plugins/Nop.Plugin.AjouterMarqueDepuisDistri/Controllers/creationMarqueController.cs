using Nop.Admin.Models.Catalog;
using Nop.Web.Framework.Controllers;
using System.Web.Mvc;

namespace Nop.Plugin.AjouterMarqueDepuisDistri.Controllers
{
    public class creationArticleController : BaseController
    {
        public ActionResult Create(int id)
        {
            creationMarque.creerMarque(id);
            return View("~/Plugins/AjouterMarqueDepuisDistri/Views/AjouterMarqueDepuisDistri/Success.cshtml");
        }
    }
}
