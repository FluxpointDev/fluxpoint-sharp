namespace fluxpoint_sharp
{
    public class IResponse
    {
        public IResponse(int cd = 0, string msg = "")
        {
            if (cd != 0)
            {
                status = "error";
                code = cd;
                message = msg;
            }
        }
        public string status;
        public int code;
        public string message;

        public bool isError()
        {
            if (code == 200)
                return false;
            return true;
        }
    }
}
