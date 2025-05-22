namespace web_server_csharp;

public class ResponseHandler
{
    public ResponseHandler( )
    {
    } 
    public async Task HandleResponseAsync( Stream _stream)
    {

        var _response = new Response
        {
            Status = StatusCode.OK,
            Message = "Hello Server Client" 
        };
        try
        {
            var writer = new StreamWriter(_stream) { AutoFlush = true };
            string response = $"HTTP/1.1 {(int)_response.Status} {_response.Status}\r\n" +
                              "Content-Type: text/plain\r\n\r\n" +
                              $"{_response.Message}";
            await writer.WriteAsync(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            _stream.Close();
        }
    }
    
}