using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class ColorEndpoints
{
    public ColorEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;

    public Task<ColorResponse> GetRandomColorAsync()
        => Client.SendRequest<ColorResponse>(HttpType.Get, "/color/random");

    public Task<ColorResponse> GetNameColorAsync(string colorName)
    {
        if (string.IsNullOrEmpty(colorName))
            throw new FluxpointClientException("Name color argument is missing.");

        return Client.SendRequest<ColorResponse>(HttpType.Get, "/color/info?name=" + colorName);
    }

    public Task<ColorResponse> GetHexColorAsync(string hexColor)
    {
        if (string.IsNullOrEmpty(hexColor))
            throw new FluxpointClientException("Hex color argument is missing.");

        return Client.SendRequest<ColorResponse>(HttpType.Get, "/color/info?hex=" + hexColor);
    }

    public Task<ColorResponse> GetRGBColorAsync(int r, int g, int b)
    {
        if (r < 0 || g < 0 || b < 0)
            throw new FluxpointClientException("RGB color argument can't be less than 0.");

        if (r > 255 || g > 255 || b > 255)
            throw new FluxpointClientException("RGB color argument can't be more than 255.");

        return Client.SendRequest<ColorResponse>(HttpType.Get, $"/color/info?rgb={r},{g},{b}");
    }
}
