using CustomerProfileService.Application.Interfaces;
using CustomerProfileService.Application.Services;
using Microsoft.AspNetCore.Http;

namespace CustomerProfileService.Infrastructure.Storage;

public class LocalFileStorage : IFileStorage
{
    public async Task<string> SaveAsync(IFormFile file)
    {
        //D:\practice\BankSystem\services\CustomerProfileService\CustomerProfileService.Api\uploads
        var folder = "uploads";
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var path = $"{folder}/{Guid.NewGuid()}_{file.FileName}";

        using var stream = File.Create(path);
        await file.CopyToAsync(stream);

        return path;
    }
}