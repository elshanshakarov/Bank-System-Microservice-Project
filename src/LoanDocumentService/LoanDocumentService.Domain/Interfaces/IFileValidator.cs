using Microsoft.AspNetCore.Http;

namespace LoanDocumentService.Domain.Interfaces;

public interface IFileValidator
{
    bool IsValidFormat(IFormFile file);
    bool IsValidSize(IFormFile file);
}