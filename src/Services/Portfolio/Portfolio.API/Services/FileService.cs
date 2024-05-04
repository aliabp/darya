namespace Portfolio.API.Services;

public class FileService : IFileService
{
    public async Task SaveFileAsync(string path, Stream stream)
    {
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream);
        }
    }
}