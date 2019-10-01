using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class ApiMeResponse : IResponse
    {
        public string id;
        public string name;
        public string token;
        public DateTime created;
        public DateTime? expire;
        public bool donator;
        public bool owner;
        public bool disabled;
        public string galleryUser;
        public int galleryUserID;
    }
}
