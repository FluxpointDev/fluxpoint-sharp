using fluxpoint_sharp.Responses;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class MinecraftEndpoints
    {
        public MinecraftEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<MinecraftServerResponse> GetMinecraftServerAsync(string host, int port = 25565)
        {
            if (string.IsNullOrEmpty(host))
                throw new FluxpointClientException("Host argument is missing");

            if (port < 0)
                throw new FluxpointClientException("Port argument can't be less than 0");

            return Client.SendRequest<MinecraftServerResponse>(HttpType.Get, ApiType.Fluxpoint, "/mc/ping?host=" + host + "&port=" + port);
        }

    }
}
