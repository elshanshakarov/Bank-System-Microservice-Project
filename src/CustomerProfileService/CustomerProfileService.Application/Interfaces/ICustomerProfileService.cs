using CustomerProfileService.Application.DTOs;
using CustomerProfileService.Domain.Entities;

namespace CustomerProfileService.Application.Interfaces;

public interface ICustomerProfileService
{
    Task<CustomerProfile> UploadProfileAsync(UploadProfileDto dto);
}