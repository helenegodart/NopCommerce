using System;
using Nop.Core.Plugins;
using System.Xml;
using Nop.Admin.Models.Catalog;
using Nop.Admin.Extensions;
using Nop.Services.Catalog;
using Nop.Services.Seo;

namespace Nop.Plugin.AjouterArticleDepuisDistri
{
    public class creationArticle : BasePlugin
    {
        string IDarticle; //Changer quand je saurai ce que je vais recevoir de Yann et d'où.
        private IProductService _productService;
        private IUrlRecordService _urlRecordService;

        public void creerArticle(string id)
        {
            IDarticle = id;
            string article = ""; //ClientWCF.ServiceDemandeArticle(IDarticle);
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
            //Trouver comment l'ajouter à Nop (évidemment qu'on peut pas utiliser un controller comme ça)
            //product
            var product = produit.ToEntity();
            product.CreatedOnUtc = DateTime.UtcNow;
            product.UpdatedOnUtc = DateTime.UtcNow;
            _productService.InsertProduct(product);
            //search engine name
            produit.SeName = product.ValidateSeName(produit.SeName, product.Name, true);
            _urlRecordService.SaveSlug(product, produit.SeName, 0);

        }
    }
}
