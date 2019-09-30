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
        }

        private readonly HttpClient Client = new HttpClient();
        public readonly string Url = "https://api.fluxpoint.dev/";

        public readonly TestEndpoints Test;

        public async Task<IResponse> SendRequest(HttpMethod method, string url)
        {
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(method, url);
                HttpResponseMessage Res = await Client.SendAsync(Req);
                string Message = await Res.Content.ReadAsStringAsync();
                IResponse response = (IResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(Message);
                if (response == null)
                    return new ErrorResponse(500, "Could not parse json response");
                return response;
            }
            catch (Exception ex)
            {
                return new ErrorResponse(400, ex.Message);
            }
        }

        public async Task<byte[]> SendImageRequest(HttpMethod method, string url)
        {
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(method, url);
                HttpResponseMessage Res = await Client.SendAsync(Req);
               byte[] Bytes = await Res.Content.ReadAsByteArrayAsync();
                return Bytes;
            }
            catch
            {
                return new byte[0];
            }
        }

        public async Task<JObject> SendCustomRequest(HttpMethod method, string url)
        {
            try
            {
                HttpRequestMessage Req = new HttpRequestMessage(method, url);
                HttpResponseMessage Res = await Client.SendAsync(Req);
                string Message = await Res.Content.ReadAsStringAsync();
                JObject response = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(Message);
                if (response == null)
                    return (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResponse(500, "Could not parse json response")));
                return response;
            }
            catch (Exception ex)
            {
                return (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResponse(400, ex.Message)));
            }
        }
    }
}
