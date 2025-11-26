using NotificationService.Application.Interfaces;
using NotificationService.Application.Services;
using NotificationService.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<INotificationHandler, NotificationHandler>();
builder.Services.AddHostedService<RabbitMqConsumer>();

var app = builder.Build();
app.MapGet("/", () => "Notification Service is running...");
app.Run();