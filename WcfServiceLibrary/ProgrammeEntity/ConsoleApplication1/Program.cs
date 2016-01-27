using System;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace ProgrammeEntity
{

    public class Commandes
    {
        public static void ConnectionSql()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = " Data Source = NERIL-PC; Initial Catalog = DISTRI_DEV; Integrated Security = True";
            try
            {
                conn.Open();
                // Insert code to process data.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur Connection : "+ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static string demandeArticle(int codeArticle)
        {
            DISTRI_DEVEntities db = new DISTRI_DEVEntities();


            var empQuery = from article in db.ART_Article
                           from tarif in db.TRF_Tarif
                           from rayon in db.ART_Rayon
                           from famille in db.ART_Famille
                           from couleur in db.ART_Couleur
                           from couleurType in db.ART_CouleurType
                           from grille in db.ART_Grille
                           from photo in db.PAR_Photo
                           from griffe in db.ART_Griffe

                           where article.CodeArticle == codeArticle.ToString()
                           where tarif.ID_Article == article.ID
                           where rayon.ID == article.ID_Rayon
                           where famille.ID == article.ID_Famille
                           where couleur.ID == article.ID_Couleur
                           where couleurType.ID == couleur.ID
                           where article.ID_GrilleAchat == grille.ID
                           where photo.ID_Objet == article.ID
                           orderby tarif.DateCreation descending

                           select new{article,tarif,rayon,famille,couleur,couleurType,grille,photo};
                                



            Console.WriteLine("Il y a "+empQuery.Count()+" ligne");

            try
            {
                var num = empQuery.First();

                String resultat = string.Format("{0} : {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10} \n",
                        num.article.ID,
                        num.article.CodeArticle,
                        num.article.Libelle,
                        num.article.Description,
                        num.article.ID_Fournisseur,
                        num.article.QteUniteStock,
                        num.article.PoidsArticle,

                        num.tarif.PrixTTC,
                        num.tarif.DateCreation,
                        num.grille.Libelle,
                        num.couleurType.Libelle
                        );

                XElement element = new XElement("requete",
                            new XElement("ID", num.article.ID),
                            new XElement("CodeArticle", num.article.CodeArticle),
                            new XElement("Libelle", num.article.Libelle),
                            new XElement("Description", num.article.Description),
                            new XElement("ID_Fournisseur", num.article.ID_Fournisseur),
                            new XElement("QteUniteStock", num.article.QteUniteStock),
                            new XElement("PoidsArticle", num.article.PoidsArticle),


                            new XElement("PrixTTC", num.tarif.PrixTTC),
                            new XElement("DateCreation", num.tarif.DateCreation),
                            new XElement("grille_Libelle", num.grille.Libelle),
                            new XElement("famille_Libelle", num.famille.Libelle),
                            new XElement("couleurType_Libelle", num.couleurType.Libelle),
                            new XElement("Filemane", num.photo.Filename)
                            );



                return element.ToString();
            }
            catch(Exception e)
            {
                return e.ToString() + "Pas d'article pour ce numéro";
            }
        }

        public static string demandeMarque(int codeMarque)
        {
            DISTRI_DEVEntities db = new DISTRI_DEVEntities();


            var empQuery = from griffe in db.ART_Griffe

                           where griffe.ID == codeMarque
                           select new { griffe };




            Console.WriteLine("Il y a " + empQuery.Count() + " ligne");

            try
            {
                var num = empQuery.First();


                XElement element = new XElement("requete",

                            new XElement("griffe_ID", num.griffe.ID),
                            new XElement("griffe_Libelle", num.griffe.Libelle)
                            );



                return element.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


    }
    class MainClass
    {
        static void Main(string[] args)
        {

           // Console.WriteLine(Commandes.demandeArticle(7005025));
            Console.WriteLine(Commandes.demandeMarque(12));

            Console.ReadLine();

        }
    }
}
