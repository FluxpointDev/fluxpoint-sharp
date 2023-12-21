using HttpCoreSharp;

namespace fluxpoint_sharp;

public class IResponse : IHttpCoreError
{
    public IResponse(int cd = 0, string msg = "")
    {
        code = cd;
        message = msg;
    }
    public IResponse()
    {

    }

    public bool success { get; set; }
    public int code { get; set; }
    public string message { get; set; }

    public override string ErrorMessage { get { return message; } }
}

public class ErrorResponse : IResponse
{
    public ErrorResponse(int cd = 0, string msg = "")
    {
        code = cd;
        message = msg;
    }
    public ErrorResponse()
    {

    }
}
