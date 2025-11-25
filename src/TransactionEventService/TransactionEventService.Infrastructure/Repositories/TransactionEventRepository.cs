using TransactionEventService.Domain.Entities;
using TransactionEventService.Domain.Interfaces;
using TransactionEventService.Infrastructure.Data;

namespace TransactionEventService.Infrastructure.Repositories;

public class TransactionEventRepository : ITransactionEventRepository
{
    private readonly AppDbContext _db;

    public TransactionEventRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TransactionEvent evt)
    {
        _db.TransactionEvents.Add(evt);
        await _db.SaveChangesAsync();
    }
}