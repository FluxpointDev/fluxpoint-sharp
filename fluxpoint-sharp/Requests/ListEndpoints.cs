using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class ListEndpoints
    {
        public ListEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<ListResponse> GetIconsAsync()
            => Client.SendRequest<ListResponse>(HttpType.Get, ApiType.Fluxpoint, "/list/icons");
        

        public Task<ListResponse> GetBannersAsync()
            => Client.SendRequest<ListResponse>(HttpType.Get, ApiType.Fluxpoint, "/list/banners");

        public Task<ListResponse> GetTemplatesAsync()
            => Client.SendRequest<ListResponse>(HttpType.Get, ApiType.Fluxpoint, "/list/templates");
    }
}
