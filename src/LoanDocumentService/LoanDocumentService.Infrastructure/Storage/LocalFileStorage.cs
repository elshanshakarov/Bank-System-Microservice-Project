using LoanDocumentService.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LoanDocumentService.Infrastructure.Storage;

public class LocalFileStorage: IFileStorage
{
    public async Task<string> SaveAsync(IFormFile file)
    {
        var folder = "loan_documents"; //D:\practice\BankSystem\services\LoanDocumentService\LoanDocumentService.Api\loan_documents
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var path = $"{folder}/{Guid.NewGuid()}_{file.FileName}";

        using var stream = File.Create(path);
        await file.CopyToAsync(stream);

        return path;
    }
}