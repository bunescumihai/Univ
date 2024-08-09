using Microsoft.AspNetCore.Http;

namespace AppServices.FileSaverService;

public class FileSaver : IFileSaver
{

    public async Task<string?> SaveAsync(string path, IFormFile file)
    {
        string fileName = $"{Guid.NewGuid()}_{file.FileName}_{Path.GetExtension(file.FileName)}";

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fileRoute = Path.Combine(path, fileName);
        
        using (FileStream fs = File.Create(fileRoute))
        {
            try
            {
                await file.OpenReadStream().CopyToAsync(fs);
            }
            catch
            {
                return null;
            }
        }

        return Path.Combine(path, fileName);
    }
}