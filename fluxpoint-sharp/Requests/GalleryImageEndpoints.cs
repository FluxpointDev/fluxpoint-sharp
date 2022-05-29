using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class GalleryImageEndpoints
    {
        public GalleryImageEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public Task<FileResponse> GetNekoAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/neko");

        public Task<FileResponse> GetKitsuneAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/kitsune");

        public Task<FileResponse> GetHoloAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/holo");

        public Task<FileResponse> GetChristmasAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/christmas");

        public Task<FileResponse> GetMaidAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/maid");

        public Task<FileResponse> GetNekoparaAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/nekopara");

        public Task<FileResponse> GetAzurlaneAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/azurlane");

        public Task<FileResponse> GetSenkoAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/senko");

        public Task<FileResponse> GetDokiDokiLiteratureClubAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/ddlc");

        public Task<FileResponse> GetAnimeWallpaperAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/wallpaper");

        public Task<FileResponse> GetAnimeImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/anime");

        public Task<FileResponse> GetMemeImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/meme");

        public Task<FileResponse> GetNoUImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/nou");

        public Task<FileResponse> GetPogImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/pog");

        public Task<FileResponse> GetCatAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/cat");

        public Task<FileResponse> GetDogAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/dog");

        public Task<FileResponse> GetLizardAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/lizard");
    }
}
