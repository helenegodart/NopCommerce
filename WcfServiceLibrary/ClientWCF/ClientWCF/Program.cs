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
            ClientWCF.ServiceReference.Service1Client client = new ClientWCF.ServiceReference.Service1Client();
            
            Console.WriteLine(client.DemandeArticle(241));
            Console.ReadLine();

        }
    }
}