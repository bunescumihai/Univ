using Microsoft.AspNetCore.Http;

namespace AppServices.FileSaverService;

public interface IFileSaver
{
    public Task<string?> SaveAsync(string path, IFormFile file);
}