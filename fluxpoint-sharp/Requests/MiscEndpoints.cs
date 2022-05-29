using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class MiscEndpoints
    {
        public MiscEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<ApiMeResponse> GetMeAsync()
        => Client.SendRequest<ApiMeResponse>(HttpType.Get, ApiType.Fluxpoint, "/me");

    }
}
