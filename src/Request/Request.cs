namespace web_server_csharp; 

public class Request
{
    public Request(MethodType method, string path, IEnumerable<object> parameters)
    {
        _method = method;
        _path = path;
        _parameters = parameters;
    }
    MethodType _method;
    string _path; 
    IEnumerable<object> _parameters;
}