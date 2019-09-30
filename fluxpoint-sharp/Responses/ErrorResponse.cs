using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class ErrorResponse : IResponse
    {
        public ErrorResponse(int code, string msg)
        {
            this.code = code;
            status = "error";
            message = msg;
        }
    }
}
