using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProgrammeEntity
{

    public class Commandes
    {
        public static void ConnectionSql()
        {
            SqlConnection conn = new SqlConnection();
            //    conn.ConnectionString = "integrated security=SSPI;server=Neril-PC;" + "persist security info=False;initial catalog=";
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

            /*     var empQuery = from table in db.ART_Article
                                where table.ID == codeArticle
                                select table;*/

            var empQuery = from article in db.ART_Article
                           from tarif in db.TRF_Tarif
                           from rayon in db.ART_Rayon
                           from famille in db.ART_Famille
                           from couleur in db.ART_Couleur
                           from couleurType in db.ART_CouleurType
                           from grille in db.ART_Grille

                           where article.ID == codeArticle
                           where tarif.ID_Article == article.ID
                           where rayon.ID == article.ID_Rayon
                           where famille.ID == article.ID_Famille
                           where couleur.ID == article.ID_Couleur
                           where couleurType.ID == couleur.ID
                           where grille.ID == article.ID_GrilleAchat
                           orderby tarif.DateCreation descending

                           select new{article,tarif,rayon,famille,couleur,couleurType,grille};
                                



            Console.WriteLine("Il y a "+empQuery.Count()+" ligne");

            var num = empQuery.First();
            //       foreach (var num in empQuery)
            //       {
            String resultat =  string.Format("{0} : {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9} \n",
                    num.article.ID,
                    num.article.CodeArticle,
                    num.article.Libelle,
                    num.article.Description,
                    num.article.ID_Fournisseur,
                    num.article.QteUniteStock,

                    num.tarif.PrixTTC,
                    num.tarif.DateCreation,
                    num.grille.Libelle,
                    num.couleurType.Libelle
                    );

                /*
                Console.WriteLine(num.article.ID);
                Console.WriteLine(num.article.CodeArticle);
                Console.WriteLine(num.article.Libelle);
                Console.WriteLine(num.article.Description);
                Console.WriteLine(num.article.ID_Fournisseur);
                Console.WriteLine(num.article.QteUniteStock);

                Console.WriteLine(num.tarif.PrixTTC);
                Console.WriteLine(num.tarif.DateCreation);

                Console.WriteLine(num.grille.Libelle);

                Console.WriteLine(num.couleurType.Libelle);
                */

       //         Console.WriteLine(resultat);
        //        Console.ReadLine();
                
       //     }
            return resultat;
        }


    }
    class MainClass
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Commandes.demandeArticle(241));
            Console.ReadLine();

        }
    }
}
