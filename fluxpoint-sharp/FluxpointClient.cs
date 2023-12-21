using HttpCoreSharp;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp;

/// <summary>
/// Main client for the Fluxpoint API | https://fluxpoint.dev
/// </summary>
public class FluxpointClient
{
    /// <summary>
    /// Create the client with your API token
    /// </summary>
    /// <param name="token">This is your token</param>
    public FluxpointClient(string botname, string token)
    {
        if (string.IsNullOrEmpty(botname))
            throw new FluxpointClientException("Fluxpoint client bot name is missing");

        if (string.IsNullOrEmpty(token))
            throw new FluxpointClientException("Fluxpoint client token is missing");

        if (Client == null)
        {
            Client = new HttpCoreJsonClient<object, ErrorResponse>("https://api.fluxpoint.dev/", new HttpCoreJsonOptions
            {
                CheckErrorResponse = true,
                ThrowGetRequest = true
            });


            Client.AddHeader("User-Agent", $"fluxpoint-sharp ({botname})");
            Client.AddHeader("Authorization", token);
        }
        Animal = new AnimalEndpoints(this);
        Color = new ColorEndpoints(this);
        Convert = new ConvertEndpoints(this);
        Gifs = new GalleryGifEndpoints(this);
        Sfw = new GalleryImageEndpoints(this);
        Nsfw = new GalleryNsfwEndpoints(this);
        ImageGen = new ImageGenEndpoints(this);
        List = new ListEndpoints(this);
        Meme = new MemeEndpoints(this);
        Minecraft = new MinecraftEndpoints(this);
        Misc = new MiscEndpoints(this);
        Test = new TestEndpoints(this);
    }

    private static HttpCoreJsonClient<object, ErrorResponse> Client;
    //private static JsonSerializer Json;

    public readonly AnimalEndpoints Animal;
    public readonly ColorEndpoints Color;
    public readonly ConvertEndpoints Convert;
    public readonly GalleryGifEndpoints Gifs;
    public readonly GalleryImageEndpoints Sfw;
    public readonly GalleryNsfwEndpoints Nsfw;
    public readonly ImageGenEndpoints ImageGen;
    public readonly ListEndpoints List;
    public readonly MemeEndpoints Meme;
    public readonly MinecraftEndpoints Minecraft;
    public readonly MiscEndpoints Misc;
    public readonly TestEndpoints Test;


    public async Task<bool> TestAuthentication()
    {
        ApiMeResponse Res = await SendRequest<ApiMeResponse>(HttpType.Get, "/me").ConfigureAwait(false);
        if (Res.code == 200)
            return true;
        return false;
    }

    public async Task<T> SendRequest<T>(HttpType method, string path, object? content = null) where T : IResponse
    {
        if (string.IsNullOrEmpty(path))
            return new ErrorResponse(400, "The request endpoint can't be empty.") as T;

        string Url = "https://api.fluxpoint.dev";
        try
        {
            HttpMethod Method = method == HttpType.Post ? HttpMethod.Post : HttpMethod.Get;
            string Path = path[0] == '/' ? Url + path : Url + '/' + path;


            return await Client.SendAsync<T>(method == HttpType.Get ? HttpCoreSharp.HttpType.Get : HttpCoreSharp.HttpType.Post, Url + path, content, true);
        }
        catch (Exception ex)
        {
            return new ErrorResponse(400, ex.Message) as T;
        }
    }

    public async Task<ImageResponse> SendImageRequest(ITemplate template, string path)
    {
        if (string.IsNullOrEmpty(path))
            return new ImageResponse { code = 400, message = "The request endpoint can't be empty." };

        try
        {
            HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, path[0] == '/' ? path : '/' + path);
            if (template != null)
                Req.Content = new StringContent(JsonConvert.SerializeObject(template), Encoding.UTF8);

            HttpResponseMessage Res = await Client.Http.SendAsync(Req);
            if (Req.Content == null)
                throw new Exception("API returned no response");

            if (Req.Content.Headers.ContentType.MediaType == "application/json")
                return await Req.Content.ReadFromJsonAsync<ImageResponse>(Client.Options.JsonOptions);
            else
            {
                byte[] Bytes = await Res.Content.ReadAsByteArrayAsync();
                return new ImageResponse { bytes = Bytes, code = 200, success = true };
            }
        }
        catch
        {
            return new ImageResponse { code = 400, message = "Client failed to connect to the api" };
        }
    }

    public async Task<IResponse> SendCustomBytesRequest(HttpMethod method, string path, byte[] file)
    {
        if (string.IsNullOrEmpty(path))
            return new ErrorResponse(400, "The request endpoint can't be empty.");
        string Url = "https://api.fluxpoint.dev";
        try
        {
            HttpRequestMessage Req = new HttpRequestMessage(method, path[0] == '/' ? Url + path : Url + '/' + path); 
            Req.Content = new ByteArrayContent(file);
            HttpResponseMessage Res = await Client.Http.SendAsync(Req).ConfigureAwait(false);
            Res.EnsureSuccessStatusCode();

            return await Req.Content.ReadFromJsonAsync<IResponse>(Client.Options.JsonOptions);
        }
        catch (Exception ex)
        {
            return new IResponse(400, ex.Message);
        }
    }

    public async Task<System.Text.Json.JsonDocument> SendCustomRequest(HttpType method, string path)
    {
        if (string.IsNullOrEmpty(path))
            return System.Text.Json.JsonSerializer.SerializeToDocument(new IResponse(400, "The request endpoint can't be empty."));
        
        string Url = "https://api.fluxpoint.dev";
        try
        {
            HttpRequestMessage Req = new HttpRequestMessage(method == HttpType.Get ? HttpMethod.Get : HttpMethod.Post, path[0] == '/' ? Url + path : Url + '/' + path);
            HttpResponseMessage Res = await Client.Http.SendAsync(Req).ConfigureAwait(false);
            Res.EnsureSuccessStatusCode();

            return await Req.Content.ReadFromJsonAsync<System.Text.Json.JsonDocument>(Client.Options.JsonOptions);

        }
        catch (Exception ex)
        {
            return System.Text.Json.JsonSerializer.SerializeToDocument(new IResponse(400, ex.Message), Client.Options.JsonOptions);
        }
    }
}

public enum HttpType
{
    Get, Post
}
