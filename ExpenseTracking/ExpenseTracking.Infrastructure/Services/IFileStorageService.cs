namespace ExpenseTracking.Infrastructure;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName);
    Task DeleteFileAsync(string filePath);
}
