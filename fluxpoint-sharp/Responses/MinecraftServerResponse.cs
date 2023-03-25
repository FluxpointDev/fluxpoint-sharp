namespace fluxpoint_sharp.Responses
{
    public class MinecraftServerResponse : IResponse
    {
        public bool online;
        public string icon;
        public string motd;
        public int playersOnline;
        public int playersMax;
        public string version;
        public bool fullQuery;
        public string[] players;
    }
}
