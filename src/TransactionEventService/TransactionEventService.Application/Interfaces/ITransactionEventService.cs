using TransactionEventService.Application.Models;

namespace TransactionEventService.Application.Interfaces;

public interface ITransactionEventService
{
    Task HandleIncomingEventAsync(IncomingTransactionMessage message);
}