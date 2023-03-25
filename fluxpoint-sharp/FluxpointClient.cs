using Microsoft.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fluxpoint_sharp
{
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
                Client = new HttpClient
                {
                    BaseAddress = new Uri("https://api.fluxpoint.dev/")
                };
                Client.DefaultRequestHeaders.Add("User-Agent", $"fluxpoint-sharp ({botname})");
                Client.DefaultRequestHeaders.Add("Authorization", token);
                Json = new JsonSerializer();
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

        private static HttpClient Client;
        private static JsonSerializer Json;

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

        private static readonly RecyclableMemoryStreamManager  recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();

        public async Task<bool> TestAuthentication()
        {
            ApiMeResponse Res = await SendRequest<ApiMeResponse>(HttpType.Get, ApiType.Fluxpoint, "/me").ConfigureAwait(false);
            if (Res.code == 200)
                return true;
            return false;
        }

        public async Task<T> SendRequest<T>(HttpType method, ApiType type, string path, object content = null) where T : IResponse
        {
            if (string.IsNullOrEmpty(path))
                return new ErrorResponse(400, "The request endpoint can't be empty.") as T;
            string Url = type == ApiType.Fluxpoint ? "" : "https://gallery.fluxpoint.dev/api";
            try
            {
                HttpMethod Method = method == HttpType.Post ? HttpMethod.Post : HttpMethod.Get;
                string Path = path[0] == '/' ? Url + path : Url + '/' + path;

                HttpRequestMessage Req = new HttpRequestMessage(Method, Path);
                if (content != null)
                {
                    if (content is string stc)
                        Req.Content = new StringContent(stc);
                    else
                        Req.Content = new StringContent(JsonConvert.SerializeObject(content));
                }

                HttpResponseMessage Res = await Client.SendAsync(Req).ConfigureAwait(false);
                int BufferSize = (int)Res.Content.Headers.ContentLength.Value;
                using (MemoryStream Stream = recyclableMemoryStreamManager.GetStream("FPSharp-SendRequest", BufferSize))
                {
                    await Res.Content.CopyToAsync(Stream);
                    Stream.Position = 0;
                    using (TextReader text = new StreamReader(Stream))
                    using (JsonReader reader = new JsonTextReader(text))
                    {
                        return Json.Deserialize<T>(reader);
                    }
                }
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
                HttpResponseMessage Res = await Client.SendAsync(Req).ConfigureAwait(false);
                byte[] Bytes = await Res.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                if (Bytes[0] == '{')
                {
                    string Json = Encoding.UTF8.GetString(Bytes);
                    return JsonConvert.DeserializeObject<ImageResponse>(Json);
                }
                else
                {
                    return new ImageResponse { bytes = Bytes, code = 200, success = true };
                }
            }
            catch
            {
                return new ImageResponse { code = 400, message = "Client failed to connect to the api" };
            }
        }

        public async Task<IResponse> SendCustomBytesRequest(HttpMethod method, ApiType type, string path, byte[] file)
        {
            if (string.IsNullOrEmpty(path))
                return new ErrorResponse(400, "The request endpoint can't be empty.");
            string Url = type == ApiType.Fluxpoint ? "" : "https://gallery.fluxpoint.dev/api";
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(method, path[0] == '/' ? Url + path : Url + '/' + path); 
                Req.Content = new ByteArrayContent(file);
                 HttpResponseMessage Res = await Client.SendAsync(Req).ConfigureAwait(false);
                Res.EnsureSuccessStatusCode();

                string Message = await Res.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<IResponse>(Message);
            }
            catch (Exception ex)
            {
                return new IResponse(400, ex.Message);
            }
        }

        public async Task<JObject> SendCustomRequest(HttpMethod method, ApiType type, string path)
        {
            if (string.IsNullOrEmpty(path))
                return JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(new IResponse(400, "The request endpoint can't be empty.")));
            string Url = type == ApiType.Fluxpoint ? "" : "https://gallery.fluxpoint.dev/api";
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(method, path[0] == '/' ? Url + path : Url + '/' + path);
                HttpResponseMessage Res = await Client.SendAsync(Req).ConfigureAwait(false);
                string Message = await Res.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject response = (JObject)JsonConvert.DeserializeObject(Message);
                if (response == null)
                    return JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(new IResponse(500, "Could not parse json response")));
                return response;
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(new IResponse(400, ex.Message)));
            }
        }
    }

    public enum HttpType
    {
        Get, Post
    }
    public enum ApiType
    {
        Fluxpoint, Gallery
    }
}
