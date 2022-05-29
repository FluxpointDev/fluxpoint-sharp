using System;

namespace fluxpoint_sharp
{
    public class ApiMeResponse : IResponse
    {
        public string id;
        public string name;
        public string token;
        public DateTime created;
        public bool disabled;
    }
}
