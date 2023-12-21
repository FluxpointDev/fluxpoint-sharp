using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class MemeEndpoints
{
    public MemeEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;

    public Task<FileResponse> GetMemeImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/img/meme");

    public Task<FileResponse> GetNoUImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/img/nou");

    public Task<FileResponse> GetPogImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/sfw/img/pog");
}
