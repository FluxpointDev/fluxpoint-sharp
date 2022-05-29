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
                throw new Exception("Bot name cannot be null");

            if (string.IsNullOrEmpty(token))
                throw new Exception("Token cannot be null");

            if (Client == null)
            {
                Client = new HttpClient
                {
                    BaseAddress = new Uri("https://api.fluxpoint.dev/")
                };
                Client.DefaultRequestHeaders.Add("User-Agent", $"fluxpoint-sharp | {botname}");
                Client.DefaultRequestHeaders.Add("Authorization", token);
                Json = new JsonSerializer();
            }
            Test = new TestEndpoints(this);
            Sfw = new GalleryImageEndpoints(this);
            Gifs = new GalleryGifEndpoints(this);
            ImageGen = new ImageGenEndpoints(this);
            Nsfw = new GalleryNsfwEndpoints(this);
            Misc = new MiscEndpoints(this);
        }

        private static HttpClient Client;
        private static JsonSerializer Json;

        public readonly TestEndpoints Test;
        public readonly GalleryImageEndpoints Sfw;
        public readonly GalleryGifEndpoints Gifs;
        public readonly ImageGenEndpoints ImageGen;
        public readonly GalleryNsfwEndpoints Nsfw;
        public readonly MiscEndpoints Misc;
        public async Task<bool> TestAuthentication()
        {
            ApiMeResponse Res = await SendRequest<ApiMeResponse>(HttpType.Get, ApiType.Fluxpoint, "/me").ConfigureAwait(false);
            if (Res.code == 200)
                return true;
            return false;
        }

        public async Task<T> SendRequest<T>(HttpType method, ApiType type, string path) where T : IResponse
        {
            if (string.IsNullOrEmpty(path))
                return new ErrorResponse(400, "The request endpoint can't be empty.") as T;
            string Url = type == ApiType.Fluxpoint ? "" : "https://gallery.fluxpoint.dev/api";
            try
            {
                HttpMethod mt = HttpMethod.Get;
                if (method == HttpType.Post)
                    mt = HttpMethod.Post;
                HttpRequestMessage Req = new HttpRequestMessage(mt, path[0] == '/' ? Url + path : Url + '/' + path);
                HttpResponseMessage Res = await Client.SendAsync(Req).ConfigureAwait(false);
                Stream Stream = await Res.Content.ReadAsStreamAsync().ConfigureAwait(false);
                using (TextReader text = new StreamReader(Stream))
                using (JsonReader reader = new JsonTextReader(text))
                {
                    return Json.Deserialize<T>(reader);
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
