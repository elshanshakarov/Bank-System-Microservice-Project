using Microsoft.EntityFrameworkCore;
using TransactionEventService.Domain.Entities;

namespace TransactionEventService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<TransactionEvent> TransactionEvents { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}
}