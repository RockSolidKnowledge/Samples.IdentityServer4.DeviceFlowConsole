using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Rsk.Samples.IdentityServer4.DeviceFlowConsole
{
    public class Program
    {
        // use single instance
        private static IDiscoveryCache discoCache = new DiscoveryCache("http://localhost:5000");

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static async Task DeviceAuthorizationRequest()
        {
            var discoDoc = await discoCache.GetAsync();
            if (discoDoc.IsError) throw new Exception("Unable to load discovery document");

            var httpClient = new HttpClient();
            var response = await httpClient.RequestDeviceAuthorizationAsync(new DeviceAuthorizationRequest
            {
                Address = discoDoc.DeviceAuthorizationEndpoint,
                ClientId = "device_console"
            });


        }
    }
}
