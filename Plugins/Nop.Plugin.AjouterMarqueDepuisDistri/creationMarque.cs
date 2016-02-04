using Nop.Core.Domain.Vendors;
using Nop.Core.Plugins;
using Nop.Services.Seo;
using Nop.Services.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Nop.Plugin.AjouterMarqueDepuisDistri
{
    public class creationMarque : BasePlugin
    {
        private readonly IVendorService _vendorService;
        private readonly IUrlRecordService _urlRecordService;

        public void creerMarque(int idMarque)
        {
            //Récupération de la marque dans Distri
            ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
            string marque = client.DemandeMarque(idMarque);
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
