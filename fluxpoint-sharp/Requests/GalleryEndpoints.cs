using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class GalleryEndpoints
    {
        public GalleryEndpoints(FluxpointClient client)
        {
            Client = client;
            Sfw = new GallerySfwEndpoints(client);
            Nsfw = new GalleryNsfwEndpoints(client);
        }

        private readonly FluxpointClient Client;
        public GallerySfwEndpoints Sfw;
        public GalleryNsfwEndpoints Nsfw;

        public async Task<GalleryMeResponse> GetMe()
        {
            return await Client.SendRequest<GalleryMeResponse>(HttpType.Get, "/gallery/me");
        }
    }
}
