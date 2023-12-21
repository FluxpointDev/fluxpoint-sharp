using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class GalleryGifEndpoints
{
    public GalleryGifEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;

    public Task<FileResponse> GetBakaAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/baka");

    public Task<FileResponse> GetBiteAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/bite");

    public Task<FileResponse> GetBlushAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/blush");

    public Task<FileResponse> GetCryAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/cry");

    public Task<FileResponse> GetDanceAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/dance");

    public Task<FileResponse> GetFeedAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/feed");

    public Task<FileResponse> GetFluffAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/fluff");

    public Task<FileResponse> GetGrabAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/grab");

    public Task<FileResponse> GetHandHoldingAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/handhold");

    public Task<FileResponse> GetHighfiveAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/highfive");

    public Task<FileResponse> GetHugAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/hug");

    public Task<FileResponse> GetKissAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/kiss");

    public Task<FileResponse> GetLickAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/lick");

    public Task<FileResponse> GetNekoAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/neko");

    public Task<FileResponse> GetPatAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/pat");

    public Task<FileResponse> GetPokeAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/poke");

    public Task<FileResponse> GetPunchAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/punch");

    public Task<FileResponse> GetShrugAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/shrug");

    public Task<FileResponse> GetSlapAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/slap");

    public Task<FileResponse> GetSmugAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/smug");

    public Task<FileResponse> GetStareAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/stare");

    public Task<FileResponse> GetTickleAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/tickle");

    public Task<FileResponse> GetWagAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/wag");

    public Task<FileResponse> GetWastedAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/wasted");

    public Task<FileResponse> GetWaveAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/wave");

    public Task<FileResponse> GetWinkAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/wink");

    public Task<FileResponse> GetLaughAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/gif/laugh");
}
