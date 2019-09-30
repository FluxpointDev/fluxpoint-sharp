using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class IResponse
    {
        public string status;
        public int code;
        public string message;

        public bool IsError()
        {
            if (status == "ok")
                return false;
            return true;
        }
    }
}
