using System.Threading.Tasks;

namespace fluxpoint_sharp
{
    public class CustomImageGenEndpoints
    {
        public CustomImageGenEndpoints(FluxpointClient client)
        {
            Client = client;
        }

        private readonly FluxpointClient Client;

        public async Task<ImageResponse> GetCustomImage(CustomImage temp)
        {
            return await Client.SendImageRequest(temp, "/gen/custom");
        }
    }
}
