﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace WebProxyService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ProxyCacheService)))
            {
                host.Open();
                Console.WriteLine("**************** ProxyCacheService ****************");
                Console.WriteLine("Sart time : " + DateTime.Now.ToString());
                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);
                Console.WriteLine("Press <Enter> key to stop ...");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
