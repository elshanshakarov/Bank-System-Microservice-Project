using Microsoft.AspNetCore.Http;

namespace LoanDocumentService.Application.Interfaces;

public interface IFileStorage
{
    Task<string> SaveAsync(IFormFile file);
}