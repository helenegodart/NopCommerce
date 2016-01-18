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

        static void Main(string[] args)
        {
            //  ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();

            //Console.WriteLine(client.DemandeArticle(7000243));
            Console.WriteLine(ServiceDemandeArticle(7000243));
            Console.ReadLine();

        }
        static string ServiceDemandeArticle(int id)
        {
            ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
            return client.DemandeArticle(id);
        }
    }
}