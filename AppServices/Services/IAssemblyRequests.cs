namespace AppCore.Services;

public interface IAssemblyRequests
{
    Task<Dictionary<string, object>> GetToCreateStudent();
}