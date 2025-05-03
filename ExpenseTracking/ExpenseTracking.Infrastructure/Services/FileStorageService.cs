namespace ExpenseTracking.Infrastructure;

public class FileStorageService : IFileStorageService
{
    private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

    public FileStorageService()
    {
        if (!Directory.Exists(_uploadFolder))
            Directory.CreateDirectory(_uploadFolder);
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
    {
        var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(fileName)}";
        var filePath = Path.Combine(_uploadFolder, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await fileStream.CopyToAsync(stream);

        return uniqueFileName;
    }

    public Task DeleteFileAsync(string fileName)
    {
        var filePath = Path.Combine(_uploadFolder, fileName);
        if (File.Exists(filePath))
            File.Delete(filePath);

        return Task.CompletedTask;
    }
}
