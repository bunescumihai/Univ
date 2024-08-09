using AppCore.Services.Requests;

namespace AppCore.Services;

public class ResponseBuilder
{
    private Dictionary<string, object?> responses;

    public ResponseBuilder()
    {
        responses = new Dictionary<string, object?>();
    }

    public void Add(string key, object obj)
    {
        responses.Add(key, obj);
    }
    
    
    public async Task AddAsync(string key, IDbRequest request)
    {
        responses.Add(key, await request.GetResponse());
    }

    public object Get(string key)
    {
        if (responses.ContainsKey(key))
            return responses[key];

        throw new KeyNotFoundException();
    }

    public void Remove(string key)
    {
        if (responses.ContainsKey(key))
            responses.Remove(key);
    }

    public Dictionary<string, object> GetResponse()
    {
        return responses;
    }
    
}