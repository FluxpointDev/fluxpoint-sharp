using System.Collections.Generic;

namespace fluxpoint_sharp;

public class ListResponse : IResponse
{
    public List<string> list { get; set; } = new List<string>();
}
