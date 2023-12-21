namespace fluxpoint_sharp.Responses;

public class MinecraftServerResponse : IResponse
{
    public bool online { get; set; }
    public string icon { get; set; }
    public string motd { get; set; }
    public int playersOnline { get; set; }
    public int playersMax { get; set; }
    public string version { get; set; }
    public bool fullQuery { get; set; }
    public string[] players { get; set; }
}
