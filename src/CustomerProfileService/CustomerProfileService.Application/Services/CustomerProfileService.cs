using CustomerProfileService.Domain.Entities;
using CustomerProfileService.Domain.Interfaces;
using CustomerProfileService.Application.DTOs;
using CustomerProfileService.Application.Interfaces;

namespace CustomerProfileService.Application.Services;

public class CustomerProfileService: ICustomerProfileService
{
    private readonly ICustomerProfileRepository _repo;
    private readonly IFileStorage _fileStorage;

    public CustomerProfileService(ICustomerProfileRepository repo, IFileStorage fileStorage)
    {
        _repo = repo;
        _fileStorage = fileStorage;
    }

    public async Task<CustomerProfile> UploadProfileAsync(UploadProfileDto dto)
    {
        var filePath = await _fileStorage.SaveAsync(dto.Photo);

        var profile = new CustomerProfile
        {
            Name = dto.Name,
            ContactNumber = dto.ContactNumber,
            Email = dto.Email,
            PhotoUrl = filePath,
            PhotoFormat = dto.Photo.ContentType,
            PhotoSizeKb = dto.Photo.Length / 1024,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(profile);

        return profile;
    }
}