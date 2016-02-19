using Nop.Core.Domain.Vendors;
using Nop.Core.Plugins;
using Nop.Plugin.Misc.WebServices;
using Nop.Services.Seo;
using Nop.Services.Vendors;
using System.Xml;

namespace Nop.Plugin.AjouterMarqueDepuisDistri
{
    public class creationMarque : BasePlugin
    {
        private static readonly IVendorService _vendorService;
        private static readonly IUrlRecordService _urlRecordService;

        public static void creerMarque(int idMarque)
        {
            //Récupération de la marque dans Distri
            string marque = NopService.demandeMarque(idMarque);
            XmlDocument xmlArticle = new XmlDocument();
            xmlArticle.LoadXml(marque);

            //Création de la marque
            Vendor vendeur = new Vendor();
            vendeur.Id = int.Parse(xmlArticle.SelectSingleNode("//griffe_ID/text()").ToString());
            vendeur.Name = xmlArticle.SelectSingleNode("//griffe_Libelle/text()").ToString();

            _vendorService.InsertVendor(vendeur);
            _urlRecordService.SaveSlug(vendeur, vendeur.ValidateSeName(vendeur.Name, vendeur.Name, true), 0);
        }
    }
}
