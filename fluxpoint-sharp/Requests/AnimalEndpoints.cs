using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class AnimalEndpoints
    {
        public AnimalEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<FileResponse> GetCatAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/cat");

        public Task<FileResponse> GetDogAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/dog");

        public Task<FileResponse> GetDuckAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/duck");

        public Task<FileResponse> GetLizardAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/lizard");

    }
}
