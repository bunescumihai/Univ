namespace AppCore.Services.Requests;

public interface IDbRequest
{
    Task<object> GetResponse();
}