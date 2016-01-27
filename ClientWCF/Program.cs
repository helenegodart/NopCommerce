using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace ClientWCF
{
    class Program
    {
        //Pour tester le service
        static void Main(string[] args)
        {
            Console.WriteLine(ServiceDemandeArticle(7000243));
            Console.WriteLine(ServiceDemandeMarque(7));
            Console.ReadLine();

        }
        static string ServiceDemandeArticle(int id)
        {
            try
            {
                ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
                return client.DemandeArticle(id);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        static string ServiceDemandeMarque(int id)
        {
            try
            {
                ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
                return client.DemandeMarque(id);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}