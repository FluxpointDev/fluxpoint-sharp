using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class GalleryNsfwEndpoints
    {
        public GalleryNsfwEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public async Task<FileResponse> GetLewd()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/nsfw/lewd");
        }

        public async Task<FileResponse> GetNekopara()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/nsfw/nekopara");
        }

        public async Task<FileResponse> GetAzurlane()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/nsfw/azurlane");
        }
    }
}
