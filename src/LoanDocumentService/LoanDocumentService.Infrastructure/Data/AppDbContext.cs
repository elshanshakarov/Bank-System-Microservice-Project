using LoanDocumentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanDocumentService.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public DbSet<LoanDocument> LoanDocuments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanDocument>()
            .HasKey(c => c.DocumentId); // Id sahəsini primary key kimi təyin edir
    }
}