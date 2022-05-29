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
        public Task<HomeResponse> GetHomeAsync()
        => Client.SendRequest<HomeResponse>(HttpType.Get, ApiType.Fluxpoint, "/");
        
        public Task<IResponse> GetErrorAsync()
        => Client.SendRequest<IResponse>(HttpType.Get, ApiType.Fluxpoint, "/test/error");
        
    }
}
