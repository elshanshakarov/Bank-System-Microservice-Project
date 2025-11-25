using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TransactionEventService.Application.Interfaces;
using TransactionEventService.Application.Models;


namespace TransactionEventService.Infrastructure.Messaging;

public class RabbitMqConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private IConnection _connection;
    private IModel _channel;

    public RabbitMqConsumer(IServiceScopeFactory scopeFactory)
    {
        //_scopeFactory = scopeFactory;

        try
        {
            Console.WriteLine("Connecting to RabbitMQ...");
            _scopeFactory = scopeFactory;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare("transaction_events", durable: true, exclusive: false, autoDelete: false);

            Console.WriteLine("RabbitMqConsumer constructor completed");
        }
        catch (Exception ex)
        {
            Console.WriteLine("RabbitMqConsumer ERROR: " + ex);
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            using var scope = _scopeFactory.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<ITransactionEventService>();

            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var message = JsonSerializer.Deserialize<IncomingTransactionMessage>(json);

            if (message != null)
                await service.HandleIncomingEventAsync(message);

            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume("transaction_events", autoAck: false, consumer);

        return Task.Delay(Timeout.Infinite, stoppingToken);
    }
}