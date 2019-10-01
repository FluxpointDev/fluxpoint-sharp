using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class GallerySfwEndpoints
    {
        public GallerySfwEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public async Task<FileResponse> GetAnime()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/sfw/anime");
        }

        public async Task<FileResponse> GetNekopara()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/sfw/nekopara");
        }

        public async Task<FileResponse> GetAzurlane()
        {
            return await Client.SendRequest<FileResponse>(HttpType.Get, "/gallery/sfw/azurlane");
        }

    }
}
