using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class FluxpointClientException : Exception
    {
        public FluxpointClientException(string message) : base(message)
        {
            
        }
    }
}
