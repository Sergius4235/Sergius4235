using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            string domainAddress = "http://localhost:80";

            using (WebApp.Start(url: domainAddress))
            {
                Console.WriteLine("Service Hosted " + domainAddress);
                System.Threading.Thread.Sleep(-1);
            }
            Console.ReadKey();
        }
    }
}
