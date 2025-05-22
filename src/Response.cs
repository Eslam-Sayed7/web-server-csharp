namespace web_server_csharp;

public class Response
{
    public Response(StatusCode stat, string msg)
    {
        Status = stat;
        Message = msg;
    }
    public string Message { get; set; }
    public StatusCode Status { get; set; }
    
}

