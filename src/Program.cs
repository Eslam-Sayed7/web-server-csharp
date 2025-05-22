using System.Net;
using System.Net.Sockets;
using web_server_csharp;

public class Program
{
    static async Task Main()
    {
        // Initialize the server components
        var portListener = new PortListener();
        var server = new Server(portListener);
        
        // Start the server
        var listener = new TcpListener(IPAddress.Any, 9090);
        listener.Start();

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            // Handle each client in a separate thread from the threadPool
            Task task = Task.Run( async () =>  await server.HandleClientAsync(client)); 
        }
    }
}