using NotificationService.Application.Interfaces;
using NotificationService.Domain.Models;

namespace NotificationService.Application.Services;

public class NotificationHandler : INotificationHandler
{
    public Task HandleAsync(NotificationEvent notificationEvent)
    {
        Console.WriteLine(
            $"[NOTIFICATION] Customer {notificationEvent.CustomerId} performed {notificationEvent.Type} of {notificationEvent.Amount} AZN at {notificationEvent.Timestamp}");

        return Task.CompletedTask;
    }
}