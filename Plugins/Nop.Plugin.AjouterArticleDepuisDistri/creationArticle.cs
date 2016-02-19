using Nop.Core.Plugins;
using System.Xml;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Seo;
using Nop.Plugin.Misc.WebServices;

namespace Nop.Plugin.AjouterArticleDepuisDistri
{
    public class creationArticle : BasePlugin
    {
        private static readonly IProductService _productService;
        private static readonly IUrlRecordService _urlRecordService;
        private static readonly ICategoryService _categoryService;
        private static readonly IManufacturerService _manufacturerService;

        public static bool creerArticle(int idArticle)
        {
            //Récupération du produit dans la base
            string article = NopService.demandeArticle(idArticle);
            XmlDocument xmlArticle = new XmlDocument();
            xmlArticle.LoadXml(article);

            //Création du produit
            Product produit = new Product();
            produit.Id= int.Parse(xmlArticle.SelectSingleNode("//ID/text()").ToString());
            produit.Name = xmlArticle.SelectSingleNode("//Libelle/text()").ToString();
            produit.FullDescription = xmlArticle.SelectSingleNode("//Description/text()").ToString();
            produit.VendorId = int.Parse(xmlArticle.SelectSingleNode("//ID_Griffe/text()").ToString());
            produit.Sku = xmlArticle.SelectSingleNode("//CodeArticle/text()").ToString();
            produit.StockQuantity = int.Parse(xmlArticle.SelectSingleNode("//QteUniteStock/text()").ToString());
            produit.Price = decimal.Parse(xmlArticle.SelectSingleNode("//PrixTTC/text()").ToString());
            produit.Weight = decimal.Parse(xmlArticle.SelectSingleNode("//PoidsArticle/text()").ToString());
            produit.IsDownload = false;
            produit.IsRecurring = false;
            produit.IsRental = false;
            produit.DisableWishlistButton = true;
            //produit.ShortDescription
            //produit.FullDescription
            //produit.VisibleIndividually ?
            //produit.Gtin ?

            //Mise à jour du fabricant + vérification si marque existe ou pas
            var manufacturer = _manufacturerService.GetManufacturerById(produit.VendorId);
            if (manufacturer != null)
            {
                //Mises à jour dans le système de NopCommerce
                _productService.InsertProduct(produit);
                _urlRecordService.SaveSlug(produit, produit.ValidateSeName(produit.Name, produit.Name, true), 0);
                var productManufacturer = new ProductManufacturer
                {
                    ProductId = produit.Id,
                    ManufacturerId = manufacturer.Id,
                    IsFeaturedProduct = false,
                    DisplayOrder = 1
                };
                _manufacturerService.InsertProductManufacturer(productManufacturer);

                //Mise à jour des catégories, à revoir
                /*if (produit.ProductCategories == null)
                {
                    //ensure that category exists
                    var category = _categoryService.GetCategoryById(produit.VendorId);
                    if (category != null)
                    {
                        var productCategory = new ProductCategory
                        {
                            ProductId = produit.Id,
                            CategoryId = category.Id,
                            IsFeaturedProduct = false,
                            DisplayOrder = 1
                        };
                        _categoryService.InsertProductCategory(productCategory);
                    }
                }*/

                //Mise à jour du systère de réductions
                _productService.UpdateHasTierPricesProperty(produit);
                _productService.UpdateHasDiscountsApplied(produit);
                return true;
            }
            return false;
        }
    }
}
