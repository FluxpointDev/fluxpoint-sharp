using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class ImageGenEndpoints
{
    public ImageGenEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;

    public Task<ImageResponse> GetWelcomeImageAsync(WelcomeTemplates temp)
    {
        if (temp == null)
            throw new FluxpointClientException("Welcome image template argument is missing.");

        return Client.SendImageRequest(temp, "/gen/welcome");
    }

    public Task<ImageResponse> SendCustomImageAsync(CustomImage temp)
        => Client.SendImageRequest(temp, "/gen/custom");

}
