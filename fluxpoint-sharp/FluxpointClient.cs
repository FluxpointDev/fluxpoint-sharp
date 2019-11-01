using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
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

            Client.DefaultRequestHeaders.Add("User-Agent", $"fluxpoint-sharp | {botname}");
            Client.DefaultRequestHeaders.Add("Authorization", token);
            Client.BaseAddress = new Uri(Url);
            Test = new TestEndpoints(this);
            Gallery = new GalleryEndpoints(this);
            ImageGen = new ImageGenEndpoints(this);
            CustomImageGen = new CustomImageGenEndpoints(this);
        }

        private readonly HttpClient Client = new HttpClient();
        public readonly string Url = "https://api.fluxpoint.dev/";

        public readonly TestEndpoints Test;
        public readonly GalleryEndpoints Gallery;
        public readonly ImageGenEndpoints ImageGen;
        public readonly CustomImageGenEndpoints CustomImageGen;

        public async Task<bool> TestAuthentication()
        {
            ApiMeResponse Res = await SendRequest<ApiMeResponse>(HttpType.Get, "/me");
            if (Res.code == 200)
                return true;
            return false;
        }

        public async Task<ApiMeResponse> GetMe()
        {
            return await SendRequest<ApiMeResponse>(HttpType.Get, "/me");
        }

        public async Task<T> SendRequest<T>(HttpType method, string url) where T : IResponse
        {
            try
            {
                HttpMethod mt = HttpMethod.Get;
                if (method == HttpType.Post)
                    mt = HttpMethod.Post;
                HttpRequestMessage Req = new HttpRequestMessage(mt, url);
                HttpResponseMessage Res = await Client.SendAsync(Req);
                string Message = await Res.Content.ReadAsStringAsync();
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };
                T response = JsonConvert.DeserializeObject<T>(Message, jsonSerializerSettings);
                if (response == null)
                    return new IResponse(500, "Could not parse json") as T;
                return response;
            }
            catch (Exception ex)
            {
                return new IResponse(400, ex.Message) as T;
            }
        }

        public async Task<byte[]> SendImageRequest(ITemplate template, string url)
        {
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, url);
                if (template != null)
                    Req.Content = new StringContent(JsonConvert.SerializeObject(template), System.Text.Encoding.UTF8);
                HttpResponseMessage Res = await Client.SendAsync(Req);
                byte[] Bytes = await Res.Content.ReadAsByteArrayAsync();
                return Bytes;
            }
            catch
            {
                return new byte[0];
            }
        }

        //public async Task<JObject> SendCustomRequest(HttpMethod method, string url)
        //{
        //    try
        //    {
        //        HttpRequestMessage Req = new HttpRequestMessage(method, url);
        //        HttpResponseMessage Res = await Client.SendAsync(Req);
        //        string Message = await Res.Content.ReadAsStringAsync();
        //        JObject response = (JObject)JsonConvert.DeserializeObject(Message);
        //        if (response == null)
        //            return (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(new IResponse(500, "Could not parse json response")));
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(new IResponse(400, ex.Message)));
        //    }
        //}
    }
    public enum HttpType
    {
        Get, Post
    }
}
