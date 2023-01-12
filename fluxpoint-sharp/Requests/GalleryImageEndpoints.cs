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

        public Task<FileResponse> GetAnimeImageAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/anime");

        public Task<FileResponse> GetAzurlaneAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/azurlane");

        public Task<FileResponse> GetAnimeChibiAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/chibi");

        public Task<FileResponse> GetChristmasAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/christmas");

        public Task<FileResponse> GetDokiDokiLiteratureClubAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/ddlc");

        public Task<FileResponse> GetHalloweenAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/halloween");

        public Task<FileResponse> GetHoloAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/holo");

        public Task<FileResponse> GetKitsuneAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/kitsune");

        public Task<FileResponse> GetMaidAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/maid");

        public Task<FileResponse> GetNekoAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/neko");

        public Task<FileResponse> GetNekoBoyAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/nekoboy");

        public Task<FileResponse> GetNekoparaAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/nekopara");

        
        public Task<FileResponse> GetSenkoAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/senko");

        
        public Task<FileResponse> GetAnimeWallpaperAsync()
            => Client.SendRequest<FileResponse>(HttpType.Get, ApiType.Gallery, "/sfw/img/wallpaper");

        



    }
}
