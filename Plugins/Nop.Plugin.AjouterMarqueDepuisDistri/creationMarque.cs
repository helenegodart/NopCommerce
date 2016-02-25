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
            //  ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
            ServiceReference1.IService1 client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            string marque = client.DemandeMarque(idMarque);
            // string marque = NopService.demandeMarque(idMarque);

            XmlDocument xmlArticle = new XmlDocument();
            xmlArticle.LoadXml(marque);
            XmlNode root = xmlArticle.FirstChild;

            //Création de la marque
            Vendor vendeur = new Vendor();

            vendeur.Id = int.Parse(root["griffe_ID"].InnerText);
            vendeur.Name = root["griffe_Libelle"].InnerText;

            _vendorService.InsertVendor(vendeur);
            _urlRecordService.SaveSlug(vendeur, vendeur.ValidateSeName(vendeur.Name, vendeur.Name, true), 0);
        }
    }
}
