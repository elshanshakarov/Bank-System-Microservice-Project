using CustomerProfileService.Domain.Entities;

namespace CustomerProfileService.Domain.Interfaces;

public interface ICustomerProfileRepository
{
    Task AddAsync(CustomerProfile profile);
    Task<CustomerProfile?> GetByIdAsync(int customerId);
}