using System;

namespace fluxpoint_sharp;

public class ApiMeResponse : IResponse
{
    public string id { get; set; }
    public DateTime created { get; set; }
    public bool britishAchievement { get; set; }
}
