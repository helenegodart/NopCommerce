using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace Client
{
    class Program
    {
        //Pour tester le service
        static void Main(string[] args)
        {        
            Console.WriteLine(ServiceDemandeArticle(7000243));
            Console.ReadLine();

        }
        static string ServiceDemandeArticle(int id)
        {
            try
            { 
                ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
                return client.DemandeArticle(id);
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
    }
}