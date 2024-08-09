namespace AppCore.Services;

public class AuthProxyAssemblyRequests : IAssemblyRequests
{
    private string _token;
    private IAssemblyRequests _assemblyRequests;
    
    public AuthProxyAssemblyRequests(string token, IAssemblyRequests assemblyRequests)
    {
        _token = token;
        _assemblyRequests = assemblyRequests;
    }
    
    public Task<Dictionary<string, object>> GetToCreateStudent()
    {
        if (_token.Equals("Teacher"))
            return _assemblyRequests.GetToCreateStudent();

        throw new UnauthorizedAccessException();
    }
}