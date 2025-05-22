namespace web_server_csharp;

public class ResponseHandler
{
    public ResponseHandler(Response response)
    {
        _response = response;
    }
    
    public async Task HandleResponseAsync(Stream stream)
    {
        try
        {
            using var writer = new StreamWriter(stream) { AutoFlush = true };
            string response = $"HTTP/1.1 {(int)_response.Status} {_response.Status}\r\n" +
                              "Content-Type: text/plain\r\n\r\n" +
                              $"{_response.Message}";
            await writer.WriteAsync(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    Response _response;
    
}