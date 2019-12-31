using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class TestEndpoints
    {
        public TestEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;
        public async Task<HomeResponse> GetHome()
        {
            return await Client.SendRequest<HomeResponse>(HttpType.Get, "/");
        }
        public async Task<IResponse> GetError()
        {
            return await Client.SendRequest<IResponse>(HttpType.Get, "/http?code=400");
        }
    }
}
