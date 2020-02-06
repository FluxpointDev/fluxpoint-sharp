namespace fluxpoint_sharp
{
    public class IResponse
    {
        public IResponse(int cd = 0, string msg = "")
        {
            code = cd;
            message = msg;
        }
        public bool success;
        public int code;
        public string message;
    }

    public class ErrorResponse : IResponse
    {
        public ErrorResponse(int cd = 0, string msg = "")
        {
            code = cd;
            message = msg;
        }
    }

}
