using System.Net;
using System.Net.Sockets;
using web_server_csharp;

class SimpleServer
{
    public ResponseHandler _responseHandler { get; set; }
    public RequestHandler _requestHandler { get; set; }
    public PortListener _portListener { get; set; }
    
    static async Task Main()
    {
        var listener = new TcpListener(IPAddress.Any, 9090);
        listener.Start();
        Console.WriteLine("Server running on port 9090...");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            // Handle each client in a separate task
            _ = Task.Run(() => HandleClientAsync(client));
        }
    }

    static async Task HandleClientAsync(TcpClient client  )
    {
        try
        {
            using var stream = client.GetStream();
            using var reader = new StreamReader(stream);
            using var writer = new StreamWriter(stream) { AutoFlush = true };

            var requestLine = await reader.ReadLineAsync();
            Console.WriteLine($"Received: {requestLine}");

            var response1 = new Response(StatusCode.OK, requestLine);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }
}
