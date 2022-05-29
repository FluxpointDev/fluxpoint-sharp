using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class ImageGenEndpoints
    {
        public ImageGenEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<ImageResponse> GetTestImageAsync()
        => Client.SendImageRequest(null, "/test/image");
        

        public Task<ImageResponse> GetWelcomeImageAsync(WelcomeTemplates temp)
        => Client.SendImageRequest(temp, "/gen/welcome");
        

        public Task<ListResponse> GetIconsListAsync()
        => Client.SendRequest<ListResponse>(HttpType.Get, ApiType.Fluxpoint, "/list/icons");
        

        public Task<ListResponse> GetBannersListAsync()
        =>  Client.SendRequest<ListResponse>(HttpType.Get, ApiType.Fluxpoint, "/list/banners");

        public Task<ImageResponse> SendCustomImageAsync(CustomImage temp)
        => Client.SendImageRequest(temp, "/gen/custom");

    }
}
