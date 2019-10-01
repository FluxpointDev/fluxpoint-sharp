using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class ListResponse : IResponse
    {
        public List<string> list = new List<string>();
    }
}
