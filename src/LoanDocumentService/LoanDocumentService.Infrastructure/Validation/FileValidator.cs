using LoanDocumentService.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LoanDocumentService.Infrastructure.Validation;

public class FileValidator: IFileValidator
{
    private readonly string[] AllowedFormats = { "application/pdf", "image/jpeg", "image/png" };
    private const long MaxSizeKb = 4096; // 4MB

    public bool IsValidFormat(IFormFile file)
    {
        return AllowedFormats.Contains(file.ContentType);
    }

    public bool IsValidSize(IFormFile file)
    {
        return file.Length / 1024 <= MaxSizeKb;
    }
}