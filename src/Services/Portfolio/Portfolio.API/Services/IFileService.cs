namespace Portfolio.API.Services;

public interface IFileService
{
    Task SaveFileAsync(string path, Stream stream);
}