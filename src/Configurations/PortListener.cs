using System.Net.Sockets;

namespace web_server_csharp;

public class PortListener
{
    TcpListener _listener; 
    int _port;
    public PortListener(int port = 9090)
    {
        _port = port;
        _listener = new TcpListener(System.Net.IPAddress.Any, _port);
    }
    public void Start()
    {
        _listener.Start();
        Console.WriteLine($"Server running on port {_port}...");
    }
}