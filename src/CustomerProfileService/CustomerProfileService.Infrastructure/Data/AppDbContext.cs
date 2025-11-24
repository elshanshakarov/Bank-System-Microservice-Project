using Microsoft.EntityFrameworkCore;
using CustomerProfileService.Domain.Entities;

namespace CustomerProfileService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerProfile>()
            .HasKey(c => c.CustomerId); // Id sahəsini primary key kimi təyin edir
    }
}