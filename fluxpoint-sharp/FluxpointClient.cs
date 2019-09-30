using System;
using System.Net.Http;

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
            string baseUrl = "https://api.fluxpoint.dev/";
           Client.DefaultRequestHeaders.Add("User-Agent", $"fluxpoint-sharp | {botname}");
        }

        private readonly HttpClient Client = new HttpClient();
    }
}
