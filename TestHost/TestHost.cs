using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace TestHost
{
    class TestHost
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            try
            {
                serviceHost = new ServiceHost(typeof(TestService.TestService));
                serviceHost.Open();
                Console.WriteLine("Service started at: {0}", serviceHost.BaseAddresses[0]);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                serviceHost = null;
                Console.WriteLine("There is an issue with TestService: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
