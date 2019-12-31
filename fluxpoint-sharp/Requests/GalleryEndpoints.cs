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

        //private async Task<GalleryMeResponse> GetMe()
        //{
        //    return await Client.SendRequest<GalleryMeResponse>(HttpType.Get, "/gallery/me");
        //}
    }
}
