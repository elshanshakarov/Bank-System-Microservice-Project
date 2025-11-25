using TransactionEventService.Domain.Entities;

namespace TransactionEventService.Domain.Interfaces;

public interface ITransactionEventRepository
{
    Task AddAsync(TransactionEvent evt);
}