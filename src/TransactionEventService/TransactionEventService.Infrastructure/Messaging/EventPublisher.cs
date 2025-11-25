using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using TransactionEventService.Domain.Interfaces;

namespace TransactionEventService.Infrastructure.Messaging;

public class EventPublisher : IEventPublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventPublisher()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare("audit_events", durable: true, exclusive: false, autoDelete: false);
    }

    public Task PublishAuditEventAsync(object message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        _channel.BasicPublish("", "audit_events", null, body);

        return Task.CompletedTask;
    }
}