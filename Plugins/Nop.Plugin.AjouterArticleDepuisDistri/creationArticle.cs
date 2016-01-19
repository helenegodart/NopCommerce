using Nop.Core.Plugins;
using System.Xml;
using Nop.Admin.Models.Catalog;

namespace Nop.Plugin.AjouterArticleDepuisDistri
{
    public class creationArticle : BasePlugin
    {        
        public ProductModel creerArticle(int idArticle)
        {
            ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
            string article = client.DemandeArticle(idArticle); ;
            XmlDocument xmlArticle = new XmlDocument();
            xmlArticle.LoadXml(article);
            //ProductController contient Create qui nécessite un ProductModel
            ProductModel produit = new ProductModel();
            //Partie incomplète, à compléter après quelques essais
            produit.Id= int.Parse(xmlArticle.SelectSingleNode("//ID/text()").ToString());
            produit.Name = xmlArticle.SelectSingleNode("//Libelle/text()").ToString();
            produit.FullDescription = xmlArticle.SelectSingleNode("//Description/text()").ToString();
            produit.VendorId = int.Parse(xmlArticle.SelectSingleNode("//ID_Fournisseur/text()").ToString());
            produit.Sku = xmlArticle.SelectSingleNode("//CodeArticle/text()").ToString();
            produit.StockQuantity = int.Parse(xmlArticle.SelectSingleNode("//QteUniteStock/text()").ToString());
            produit.Price = decimal.Parse(xmlArticle.SelectSingleNode("//PrixTTC/text()").ToString());
            produit.Weight = decimal.Parse(xmlArticle.SelectSingleNode("//PoidsArticle/text()").ToString());
            return produit;
        }
    }
}
