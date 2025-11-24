using CustomerProfileService.Domain.Entities;
using CustomerProfileService.Domain.Interfaces;
using CustomerProfileService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerProfileService.Infrastructure.Repositories;

public class CustomerProfileRepository : ICustomerProfileRepository
{
    private readonly AppDbContext _db;

    public CustomerProfileRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(CustomerProfile profile)
    {
        _db.CustomerProfiles.Add(profile);
        await _db.SaveChangesAsync();
    }

    public async Task<CustomerProfile?> GetByIdAsync(int customerId)
    {
        return await _db.CustomerProfiles.FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}