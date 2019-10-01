using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<byte[]> GetTestImage()
        {
            return await Client.SendImageRequest(null, "/gen/test");
        }

        public async Task<byte[]> GetWelcomeImage(WelcomeTemplates temp)
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
