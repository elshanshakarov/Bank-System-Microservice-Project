using TransactionEventService.Application.Interfaces;
using TransactionEventService.Application.Models;
using TransactionEventService.Domain.Entities;
using TransactionEventService.Domain.Interfaces;

namespace TransactionEventService.Application.Services;

public class TransactionEventService : ITransactionEventService
{
    private readonly ITransactionEventRepository _repo;
    private readonly IEventPublisher _publisher;

    public TransactionEventService(
        ITransactionEventRepository repo,
        IEventPublisher publisher)
    {
        _repo = repo;
        _publisher = publisher;
    }

    public async Task HandleIncomingEventAsync(IncomingTransactionMessage message)
    {
        var evt = new TransactionEvent
        {
            CustomerId = message.CustomerId,
            Type = message.Type,
            Amount = message.Amount,
            Source = message.Source,
            Timestamp = DateTime.UtcNow
        };

        await _repo.AddAsync(evt);

        // Audit event publish (NotificationService üçün)
        await _publisher.PublishAuditEventAsync(new
        {
            evt.EventId,
            evt.CustomerId,
            evt.Type,
            evt.Amount,
            evt.Timestamp
        });
    }
}