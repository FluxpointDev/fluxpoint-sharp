using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class GalleryNsfwEndpoints
{
    public GalleryNsfwEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;

    public Task<FileResponse> GetAnalAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/anal");

    public Task<FileResponse> GetAnalGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/anal");

    public Task<FileResponse> GetAnusAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/anus");

    public Task<FileResponse> GetAssAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/ass");

    public Task<FileResponse> GetAssGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/ass");

    public Task<FileResponse> GetAzurlaneAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/azurlane");

    public Task<FileResponse> GetBdsmAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/bdsm");

    public Task<FileResponse> GetBdsmGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/bdsm");

    public Task<FileResponse> GetBlowjobAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/blowjob");

    public Task<FileResponse> GetBlowjobGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/blowjob");

    public Task<FileResponse> GetBoobjobGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/boobjob");


    public Task<FileResponse> GetBoobsAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/boobs");

    public Task<FileResponse> GetBoobsGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/boobs");



    public Task<FileResponse> GetCosplayAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/cosplay");

    public Task<FileResponse> GetCumAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/cum");

    public Task<FileResponse> GetCumGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/cum");

    public Task<FileResponse> GetFeetAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/feet");

    public Task<FileResponse> GetFeetGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/feet");

    public Task<FileResponse> GetFemdomAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/femdom");

    public Task<FileResponse> GetFemdomGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/femdom");

    public Task<FileResponse> GetFutaAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/futa");

    public Task<FileResponse> GetFutaGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/futa");

    public Task<FileResponse> GetGasmAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/gasm");

    public Task<FileResponse> GetHoloAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/holo");

    public Task<FileResponse> GetHandjobGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/handjob");

    public Task<FileResponse> GetHentaiGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/hentai");

    public Task<FileResponse> GetKuniGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/kuni");


    public Task<FileResponse> GetKitsuneAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/kitsune");

    public Task<FileResponse> GetKitsuneGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/kitsune");

    public Task<FileResponse> GetLewdAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/lewd");

    public Task<FileResponse> GetNekoAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/neko");

    public Task<FileResponse> GetNekoGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/neko");

    public Task<FileResponse> GetNekoparaAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/nekopara");

    public Task<FileResponse> GetPantsuAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/pantsu");

    public Task<FileResponse> GetPantyhoseAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/pantyhose");

    public Task<FileResponse> GetPeeingAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/peeing");

    public Task<FileResponse> GetPetplayAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/petplay");

    public Task<FileResponse> GetPussyAsync()
       => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/pussy");

    public Task<FileResponse> GetPussyGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/pussy");

    public Task<FileResponse> GetPussyWankGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/wank");


    public Task<FileResponse> GetSlimeAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/slime");

    public Task<FileResponse> GetSoloGirlAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/solo");

    public Task<FileResponse> GetSoloGirlGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/solo");

    public Task<FileResponse> GetSwimsuitAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/swimsuit");

    public Task<FileResponse> GetSpankGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/spank");

    public Task<FileResponse> GetTentacleAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/tentacle");

    public Task<FileResponse> GetTentacleGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/tentacle");

    public Task<FileResponse> GetToysGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/toys");


    public Task<FileResponse> GetThighsAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/thighs");

    public Task<FileResponse> GetTrapAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/trap");

    public Task<FileResponse> GetYaoiAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/yaoi");

    public Task<FileResponse> GetYuriAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/img/yuri");

    public Task<FileResponse> GetYuriGifAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/nsfw/gif/yuri");
}
