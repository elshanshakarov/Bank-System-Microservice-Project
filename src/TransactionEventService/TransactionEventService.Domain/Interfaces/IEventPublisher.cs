namespace TransactionEventService.Domain.Interfaces;

public interface IEventPublisher
{
    Task PublishAuditEventAsync(object message);
}