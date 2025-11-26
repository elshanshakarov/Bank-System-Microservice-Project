using NotificationService.Domain.Models;

namespace NotificationService.Application.Interfaces;

public interface INotificationHandler
{
    Task HandleAsync(NotificationEvent notificationEvent);
}