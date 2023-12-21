using System.Threading.Tasks;

namespace fluxpoint_sharp;

public class ConvertEndpoints
{
    public ConvertEndpoints(FluxpointClient client)
    {
        Client = client;
    }

    private readonly FluxpointClient Client;


    public Task<ContentResponse> ConvertHtmlToMarkdownAsync(string html)
    {
        if (string.IsNullOrEmpty(html))
            throw new FluxpointClientException("Convert html argument is missing.");

        return Client.SendRequest<ContentResponse>(HttpType.Get, "/convert/html-markdown", html);
    }

    public Task<ContentResponse> ConvertMarkdownToHtmlAsync(string markdown)
    {
        if (string.IsNullOrEmpty(markdown))
            throw new FluxpointClientException("Markdown convert argument is missing.");

        return Client.SendRequest<ContentResponse>(HttpType.Get, "/convert/markdown-html", markdown);
    }
}
