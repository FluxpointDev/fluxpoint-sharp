using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class TestEndpoints
    {
        public TestEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private FluxpointClient Client;
        public async Task<HomeResponse> GetHome()
        {
            return (HomeResponse)await Client.SendRequest(HttpMethod.Get, "");
        }

        public async Task<byte[]> GetImage()
        {
            return await Client.SendImageRequest(HttpMethod.Get, "/gen/test");
        }
    }
}
