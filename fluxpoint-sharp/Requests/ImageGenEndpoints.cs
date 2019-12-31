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

        public async Task<ImageResponse> GetTestImage()
        {
            return await Client.SendImageRequest(null, "/gen/test");
        }

        public async Task<ImageResponse> GetWelcomeImage(WelcomeTemplates temp)
        {
            return await Client.SendImageRequest(temp, "/gen/welcome");
        }

        public async Task<ListResponse> GetIconsList()
        {
            return await Client.SendRequest<ListResponse>(HttpType.Get, "/list/icons");
        }

        public async Task<ListResponse> GetBannersList()
        {
            return await Client.SendRequest<ListResponse>(HttpType.Get, "/list/banners");
        }
    }
}
