using Microsoft.AspNetCore.Http;

namespace CustomerProfileService.Application.Interfaces;

public interface IFileStorage
{
    Task<string> SaveAsync(IFormFile file);
}