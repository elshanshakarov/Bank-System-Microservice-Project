using Microsoft.AspNetCore.Http;

namespace CustomerProfileService.Application.DTOs;

public class UploadProfileDto
{
    public IFormFile Photo { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
}