using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class TestEndpoints
{
    public TestEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;
    public Task<HomeResponse> GetHomeAsync()
        => Client.SendRequest<HomeResponse>(HttpType.Get, "/");

    public Task<ImageResponse> GetTestImageGenAsync()
       => Client.SendImageRequest(null, "/test/image");

    public Task<FileResponse> GetTestGalleryImageAsync()
        => Client.SendRequest<FileResponse>(HttpType.Get, "/test/gallery");

    public Task<IResponse> GetErrorAsync()
        => Client.SendRequest<IResponse>(HttpType.Get, "/test/error");

}
