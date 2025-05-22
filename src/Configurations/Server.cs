using System.Net.Sockets;
using web_server_csharp;

class Server
{
    public Server(PortListener portListener)
    {
        _portListener = portListener;
    }
    public PortListener _portListener { get; set; }
   
    public async Task HandleClientAsync(TcpClient client  )
    {
        try
        {
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            var requestLine = await reader.ReadLineAsync();
            Console.WriteLine($"Received: {requestLine}");
            
            var requestHandler = new RequestHandler();
            var responseHandler = new ResponseHandler();
            await responseHandler.HandleResponseAsync(stream);
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