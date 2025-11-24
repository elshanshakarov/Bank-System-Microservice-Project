using LoanDocumentService.Domain.Entities;
using LoanDocumentService.Domain.Interfaces;
using LoanDocumentService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LoanDocumentService.Infrastructure.Repositories;

public class LoanDocumentRepository: ILoanDocumentRepository
{
    private readonly AppDbContext _db;

    public LoanDocumentRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(LoanDocument doc)
    {
        _db.LoanDocuments.Add(doc);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<LoanDocument>> GetByCustomerIdAsync(int customerId)
    {
        return await _db.LoanDocuments
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();
    }
}